using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WILDLINK_CLIENTS
{
    public partial class Form1 : Form
    {
        private readonly string schoolID;
        private HubConnection connection;
        private DateTime lastDisplayedTimestamp;
        private bool isIntentionalDisconnect;
        private bool isFormClosing;
        private static int openFormsCount = 0;

        public Form1(string schoolID)
        {
            InitializeComponent();
            this.schoolID = schoolID ?? throw new ArgumentNullException(nameof(schoolID)); // Ensure schoolID is not null
            txtUsername.Text = schoolID;
            txtUsername.ReadOnly = true;
            lastDisplayedTimestamp = DateTime.MinValue;

            InitializeConnection();

            txtMessage.Enabled = false;
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;

            lstChatBox.HorizontalScrollbar = true;
            lstChatBox.ScrollAlwaysVisible = true;
            txtInterest.Enabled = true;
            this.FormClosing += Form1_FormClosing; // Subscribe to FormClosing event

            // Increment the open forms counter
            openFormsCount++;
        }

        private void InitializeConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7044/chatHub")
                .WithAutomaticReconnect()
                .Build();

            connection.Closed += async (error) =>
            {
                if (!isIntentionalDisconnect)
                {
                    MessageBox.Show($"Connection closed: {error}");
                    await Task.Delay(new Random().Next(0, 5) * 1000);
                    await StartConnection();
                }
            };

            connection.Reconnecting += (error) =>
            {
                // Disable the UI while reconnecting
                if (!isFormClosing)
                {
                    txtMessage.Enabled = false;
                    btnSend.Enabled = false;
                    MessageBox.Show($"Connection lost. Attempting to reconnect: {error.Message}");
                }
                return Task.CompletedTask;
            };

            connection.Reconnected += async (connectionId) =>
            {
                if (!isFormClosing)
                {
                    MessageBox.Show("Reconnected to the server.");
                    // Rejoin the chat after reconnecting
                    if (connectionId != null)
                    {
                        await RejoinChat();
                    }
                }
            };

            StartConnection();
        }

        private async Task StartConnection()
        {
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start connection: {ex.Message}");
            }
        }

        private async Task RejoinChat()
        {
            if (connection.State == HubConnectionState.Connected)
            {
                UserConnection userConnection = new UserConnection
                {
                    ConnectionID = connection.ConnectionId,
                    UserName = schoolID,
                    Interest = txtInterest.Text
                };

                try
                {
                    await connection.InvokeAsync("JoinChat", userConnection);
                    txtMessage.Enabled = true;
                    btnSend.Enabled = true;
                    btnJoin.Enabled = false;
                    btnDisconnect.Enabled = true;
                    txtInterest.Enabled = false;
                    txtUsername.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to rejoin chat: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Connection is not active. Please wait and try again.");
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isFormClosing = true;

            if (connection != null && connection.State == HubConnectionState.Connected)
            {
                isIntentionalDisconnect = true;

                try
                {
                    await connection.StopAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to disconnect: {ex.Message}");
                }
                finally
                {
                    isIntentionalDisconnect = false;
                }
            }

            // Decrement the open forms counter
            openFormsCount--;

            // If there are no other open forms, terminate the application
            if (openFormsCount == 0)
            {
                Application.Exit();
            }
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            if (connection.State != HubConnectionState.Connected)
            {
                await StartConnection();
            }

            if (connection.State == HubConnectionState.Connected)
            {
                await RejoinChat();
            }
            else
            {
                MessageBox.Show("Failed to establish connection. Please try again.");
            }
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                isIntentionalDisconnect = true;

                await connection.StopAsync();

                txtMessage.Enabled = false;
                btnSend.Enabled = false;
                btnJoin.Enabled = true;
                btnDisconnect.Enabled = false;
                txtInterest.Enabled = true;
                txtUsername.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to disconnect: {ex.Message}");
            }
            finally
            {
                isIntentionalDisconnect = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (connection != null)
            {
                connection.On<string, string>("ReceiveMessage", (string user, string message) =>
                {
                    if (isFormClosing) return;

                    DateTime currentTimestamp = DateTime.Now;
                    string displayTime = "";

                    if ((currentTimestamp - lastDisplayedTimestamp).TotalMinutes >= 1)
                    {
                        displayTime = currentTimestamp.ToString("yyyy / MMM / dd hh:mm tt");
                        lastDisplayedTimestamp = currentTimestamp;
                    }

                    if (lstChatBox.InvokeRequired)
                    {
                        lstChatBox.Invoke((MethodInvoker)delegate ()
                        {
                            if (!string.IsNullOrEmpty(displayTime))
                            {
                                lstChatBox.Items.Add("\t\t\t" + displayTime);
                            }
                            lstChatBox.Items.Add($"{user}: {message}");
                            EnsureVisible(lstChatBox);
                        });
                    }
                });
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (connection.State == HubConnectionState.Connected)
            {
                string message = txtMessage.Text;
                string interest = txtInterest.Text;
                if (!string.IsNullOrEmpty(schoolID))
                {
                    connection.InvokeAsync("SendMessage", schoolID, message, interest);
                }
                txtMessage.Clear(); // Clear the message box after sending
            }
            else
            {
                MessageBox.Show("Connection is not active. Please wait and try again.");
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                btnSend.PerformClick(); // Simulate a click on the Send button
            }
        }

        private void EnsureVisible(ListBox listBox)
        {
            listBox.TopIndex = listBox.Items.Count - 1;
        }

        private void btnExportMessage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt";
                saveFileDialog.Title = "Save Chat Messages";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            foreach (var item in lstChatBox.Items)
                            {
                                writer.WriteLine(item.ToString());
                            }
                        }
                        MessageBox.Show("Messages exported successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
                    }
                }
            }
        }
    }

    public class UserConnection
    {
        public string UserName { get; set; }
        public string ConnectionID { get; set; }
        public string Interest { get; set; }
    }
}
