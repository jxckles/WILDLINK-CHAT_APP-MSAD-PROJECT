using System;
using System.Windows.Forms;

namespace WILDLINK_CLIENTS
{
    public partial class LoginForm : Form
    {
        private static int openFormsCount = 0;

        public LoginForm()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();

            // Set the PasswordChar property to mask the password with asterisks
            txtLoginPassword.PasswordChar = '*';

            // Attach KeyDown event handlers
            txtschoolID.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            txtLoginPassword.KeyDown += new KeyEventHandler(OnKeyDownHandler);

            // Attach FormClosing event handler
            this.FormClosing += LoginForm_FormClosing;

            // Increment the open forms counter
            openFormsCount++;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Decrement the open forms counter
            openFormsCount--;

            // If there are no other open forms, terminate the application
            if (openFormsCount == 0)
            {
                Application.Exit();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string schoolID = txtschoolID.Text;
            string password = txtLoginPassword.Text;

            // Check if schoolID and password are not null or empty
            if (!string.IsNullOrEmpty(schoolID) && !string.IsNullOrEmpty(password))
            {
                // Attempt to login
                if (DatabaseHelper.LoginUser(schoolID, password))
                {
                    MessageBox.Show("Login successful.");
                    this.Hide();
                    var form1 = new Form1(schoolID);
                    form1.Show();
                }
                else
                {
                    // Show error message if login fails
                    MessageBox.Show("Login failed. Invalid username or password.");
                }
            }
            // If either schoolID or password is null or empty, do nothing
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                btnLogin.PerformClick();   // Simulate a click on the Login button
            }
        }
    }
}
