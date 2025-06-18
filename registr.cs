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

namespace PR_shop
{
    public partial class registr : Form
    {
       
        public registr()
        {
            InitializeComponent();
        }
        private void registr_Load(object sender, EventArgs e)
        {

        }




        private async Task registr_user()
        {
            if (check_textBoxes() == false)
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
        ""permissionLevel"": {{ ""integerValue"": ""1"" }}
        }}
        }}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(url, content);

            go_to_shop();
        }

        private void go_to_shop()
        {
            shop shopForm = new shop();
            this.Hide();
            shopForm.FormClosed += (s, args) => this.Close(); 
            shopForm.Show();
        }
     
        private bool check_textBoxes()
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                label_registr_error1.Text = "Будь ласка введіть своє ім'я.";
                label_registr_error1.Visible = true;
                return false;
            }else if (textBox_name.Text.Length < 3 || textBox_name.Text.Length > 20)
            {
                label_registr_error1.Text = "Ім'я повинно бути від 3 до 20 символів.";
                label_registr_error1.Visible = true;
                return false;
            }
            else if (!textBox_name.Text.All(char.IsLetterOrDigit))
            {
                label_registr_error1.Text = "Ім'я повинно містити тільки букви і цифри на англ.";
                label_registr_error1.Visible = true;
                return false;
            }
            else
            {
                label_registr_error1.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textBox_password.Text))
            {
                label_registr_error2.Text = "Будь ласка введіть свій пароль.";
                label_registr_error2.Visible = true;
                return false;
            }else if (textBox_password.Text.Length < 4 || textBox_password.Text.Length > 10)
            {
                label_registr_error2.Text = "Пароль повинен бути від 4 до 10 символів.";
                label_registr_error2.Visible = true;
                return false;
            }
            else if (!textBox_password.Text.All(char.IsLetterOrDigit))
            {
                label_registr_error2.Text = "Пароль повинен містити тільки букви і цифри на англ.";
                label_registr_error2.Visible = true;
                return false;
            }
            else
            {
                label_registr_error2.Visible = false;
            }

            return true;
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
