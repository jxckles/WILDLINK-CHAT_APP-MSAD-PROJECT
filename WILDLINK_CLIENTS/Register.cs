using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WILDLINK_CLIENTS
{
    public partial class RegisterForm : Form
    {
        private static int openFormsCount = 0;
        public RegisterForm()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();

            // Attach FormClosing event handler
            this.FormClosing += Register_FormClosing;

            // Increment the open forms counter
            openFormsCount++;
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
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
            string collegeEmail = txtCollegeEmail.Text;
            string schoolID = txtSchool_ID.Text;
            string password = txtRegisterPassword.Text;
            string confirmPassword = txtRegisterConfirmPassword.Text;

            if (!Regex.IsMatch(collegeEmail, @"^[a-zA-Z]+\.[a-zA-Z]+@cit\.edu$"))
            {
                MessageBox.Show("Invalid college email format.");
                return;
            }

            if (DatabaseHelper.EmailExists(collegeEmail))
            {
                MessageBox.Show("This email is already registered.");
                return;
            }

            // Check if the school ID matches the format 12-3456-789
            if (!Regex.IsMatch(schoolID, @"^\d{2}-\d{4}-\d{3}$"))
            {
                MessageBox.Show("Invalid School ID format. It must be in the format 12-3456-789.");
                return;
            }

            if (DatabaseHelper.SchoolIDExists(schoolID))
            {
                MessageBox.Show("This school ID is already registered.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (DatabaseHelper.RegisterUser(schoolID, collegeEmail, password))
            {
                MessageBox.Show("Registration successful.");
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Registration failed. School ID or email might already be registered.");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
        }


    }
}
