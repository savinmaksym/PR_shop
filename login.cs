using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PR_shop;

namespace PR_shop
{
    public partial class login : Form
    {
        //почав в 8 закінчив в
        public login()
        {
            InitializeComponent();
           
        }
        private void login_Load(object sender, EventArgs e)
        {
           auto_login();
        }
       
       
        private void auto_login()
        {
            string filePath = "login_data.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    textBox_name.Text = lines[0];
                    textBox_password.Text = lines[1];
                    check_login_data(true);
                }
            }
        }


        private async Task check_login_data(bool autologin)
        {
            label_login_error1.Visible = false;
            label_login_error2.Visible = false;
            if (autologin) goto Skip;
            if (!func.check_textBoxes(label_login_error1, label_login_error2, textBox_name, textBox_password))
            {
                return;
            }
            Skip:
            string username = textBox_name.Text.ToLower();
            string password = textBox_password.Text;
            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users/{username}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    // Користувача не знайдено
                    label_login_error1.Text = "Користувача не знайдено.";
                    label_login_error1.Visible = true;
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                JObject userDoc = JObject.Parse(json);

                string storedHash = userDoc["fields"]?["password"]?["stringValue"]?.ToString();
                if (string.IsNullOrEmpty(storedHash)) return;
               
              
                int perm = userDoc["fields"]?["permissionLevel"]?["integerValue"]?.Value<int>() ?? 0;
                if (perm == 0)
                {
                    MessageBox.Show("Ваш акаунт заблоковано. Зверніться до адміністрації магазину.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               

                if (BCrypt.Net.BCrypt.Verify(password, storedHash) || (autologin && password == storedHash))
                {
                    // Пароль вірний, користувач може увійт
                    
                    if (checkBox_save_data.Checked && !autologin) func.save_login_data(username, storedHash);
                    func.go_to_shop(textBox_name, this, perm);
                    
                }else
                {
                    // Пароль невірний
                    label_login_error2.Text = "Невірний пароль.";
                    label_login_error2.Visible = true;
                }

            }


        }
        


        private void go_to_registr()
        {
            registr regForm = new registr();
            this.Hide(); 
            regForm.FormClosed += (s, args) => this.Close(); 
            regForm.Show(); 
        }

      
        private void label_login_registr_MouseClick(object sender, MouseEventArgs e)
        {
            go_to_registr();
        }

        private void button_login_login_Click(object sender, EventArgs e)
        {
            check_login_data(false);
        }

    }

   
}
