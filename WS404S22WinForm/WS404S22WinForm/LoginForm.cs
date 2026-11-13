using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;
using WS404S22WinForm.DTO;

namespace WS404S22WinForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 10 && textBox1.Text.All(char.IsDigit))
            {
                // Handle valid input
                Login(textBox1.Text, textBox2.Text);
            }
            else
            {
                MessageBox.Show("Please Enter a valid 10-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void Login(string user, string password)
        {

            try
            {
                var reposnse = await APi.client.PostAsJsonAsync("auth/login",
                    new { nationalCode = user, password = password });




                if (reposnse.IsSuccessStatusCode)
                {
                    APi.UserId = await reposnse.Content.ReadFromJsonAsync<int>();

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if(reposnse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("NationalCode or Username is weong...");
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your credentials.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Somthing went Wrong");
            }

        }
    }
}
