using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using PR_shop;

namespace PR_shop
{
    public partial class registr : Form
    {
       int default_permission = 1; // 1 - user, 2 - admin (0-banned)
        public registr()
        {
            InitializeComponent();
        }
        private void registr_Load(object sender, EventArgs e)
        {

        }

        private bool check_username_exists(string username)
        {
            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users/{username}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                return response.IsSuccessStatusCode; // Якщо користувач існує, повертає true
            }
        }


        private async Task registr_user()
        {
            if (check_username_exists(textBox_name.Text.ToLower()))
            {
                label_registr_error1.Text = "Користувач з таким ім'ям вже існує.";
                label_registr_error1.Visible = true;
                return;
            }
            else
            {
                label_registr_error1.Visible = false;
            }
            if (func.check_textBoxes(label_registr_error1,label_registr_error2, textBox_name, textBox_password) == false)
            {
                return;
            }

            string username = textBox_name.Text.ToLower();
            string password = textBox_password.Text;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users?documentId={username}";

            var client = new HttpClient();
            var json = $@"
        {{
        ""fields"": {{
        ""password"": {{ ""stringValue"": ""{passwordHash}"" }},
        ""permissionLevel"": {{ ""integerValue"": ""{default_permission}"" }}
        }}
        }}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(url, content);
            if (checkBox_save_data.Checked) func.save_login_data(username, passwordHash);
            func.go_to_shop(textBox_name, this, default_permission);
        }
     
       

        private void go_to_login()
        {
            login logForm = new login();
            this.Hide(); 
            logForm.FormClosed += (s, args) => this.Close();
            logForm.Show(); 
        }










        private void label_registr_login_Click(object sender, EventArgs e)
        {
           go_to_login();
        }
        private void button_registr_registr_Click(object sender, EventArgs e)
        {
            registr_user();
        }
    }
}
