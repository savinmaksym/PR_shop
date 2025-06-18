using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PR_shop
{
    public partial class login : Form
    {
        //3 ������ ������� �����������
        public login()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {
           
        }
       



        private async Task check_login_data()
        {
            label_login_error1.Visible = false;
            label_login_error2.Visible = false;

            if (!check_textBoxes())
            {
                return;
            }
            string username = textBox_name.Text.ToLower();
            string password = textBox_password.Text;
            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users/{username}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    // ����������� �� ��������
                    label_login_error1.Text = "����������� �� ��������.";
                    label_login_error1.Visible = true;
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                JObject userDoc = JObject.Parse(json);

                string storedHash = userDoc["fields"]?["password"]?["stringValue"]?.ToString();
                if (string.IsNullOrEmpty(storedHash)) return;

                if(BCrypt.Net.BCrypt.Verify(password, storedHash))
                {
                    // ������ �����, ���������� ���� �����
                    go_to_shop();
                }else
                {
                    // ������ �������
                    label_login_error2.Text = "������� ������.";
                    label_login_error2.Visible = true;
                }

            }


        }
        


        private bool check_textBoxes()
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                label_login_error1.Text = "���� ����� ������ ��� ��'�.";
                label_login_error1.Visible = true;
                return false;
            }
            else if (textBox_name.Text.Length < 3 || textBox_name.Text.Length > 20)
            {
                label_login_error1.Text = "��'� ������� ���� �� 3 �� 20 �������.";
                label_login_error1.Visible = true;
                return false;
            }
            else if (!textBox_name.Text.All(char.IsLetterOrDigit))
            {
                label_login_error1.Text = "��'� ������� ������ ����� ����� � ����� �� ����.";
                label_login_error1.Visible = true;
                return false;
            }
            else
            {
                label_login_error1.Visible = false;
            }



            if (string.IsNullOrWhiteSpace(textBox_password.Text))
            {
                label_login_error2.Text = "���� ����� ������ ��� ������.";
                label_login_error2.Visible = true;
                return false;
            }
            else if (textBox_password.Text.Length < 4 || textBox_password.Text.Length > 10)
            {
                label_login_error2.Text = "������ ������� ���� �� 4 �� 10 �������.";
                label_login_error2.Visible = true;
                return false;
            }
            else if (!textBox_password.Text.All(char.IsLetterOrDigit))
            {
                label_login_error2.Text = "������ ������� ������ ����� ����� � ����� �� ����.";
                label_login_error2.Visible = true;
                return false;
            }
            else
            {
                label_login_error2.Visible = false;
            }

            return true;
        }

        private void go_to_registr()
        {
            registr regForm = new registr();
            this.Hide(); 
            regForm.FormClosed += (s, args) => this.Close(); 
            regForm.Show(); 
        }

        private void go_to_shop()
        {
            shop shopForm = new shop();
            this.Hide();
            shopForm.FormClosed += (s, args) => this.Close(); 
            shopForm.Show();
        }

       

        private void label_login_registr_MouseClick(object sender, MouseEventArgs e)
        {
            go_to_registr();
        }

        private void button_login_login_Click(object sender, EventArgs e)
        {
            check_login_data();
        }

    }

   
}
