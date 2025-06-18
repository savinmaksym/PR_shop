using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_shop
{
    public static class func
    {
        public static void save_login_data(string name, string password)
        {
            // Збереження даних входу в файл
            string filePath = "login_data.txt";
            using (StreamWriter writer = new StreamWriter(filePath, false)) 
            {
                writer.WriteLine(name);
                writer.WriteLine(password);
            }
        }



        public static void go_to_shop(TextBox textBox_name, Form e)
        {
            string username = textBox_name.Text.ToLower();
            shop shopForm = new shop(username);
            e.Hide();
            shopForm.ShowDialog();
        }

        public static bool check_textBoxes(Label error1, Label error2, TextBox textBox_name, TextBox textBox_password)
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
               error1.Text = "Будь ласка введіть своє ім'я.";
               error1.Visible = true;
                return false;
            }
            else if (textBox_name.Text.Length < 3 || textBox_name.Text.Length > 20)
            {
                error1.Text = "Ім'я повинно бути від 3 до 20 символів.";
                error1.Visible = true;
                return false;
            }
            else if (!textBox_name.Text.All(char.IsLetterOrDigit))
            {
                error1.Text = "Ім'я повинно містити тільки букви і цифри на англ.";
                error1.Visible = true;
                return false;
            }
            else
            {
                error1.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textBox_password.Text))
            {
                error2.Text = "Будь ласка введіть свій пароль.";
                error2.Visible = true;
                return false;
            }
            else if (textBox_password.Text.Length < 4 || textBox_password.Text.Length > 10)
            {
                error2.Text = "Пароль повинен бути від 4 до 10 символів.";
                error2.Visible = true;
                return false;
            }
            else if (!textBox_password.Text.All(char.IsLetterOrDigit))
            {
                error2.Text = "Пароль повинен містити тільки букви і цифри на англ.";
                error2.Visible = true;
                return false;
            }
            else
            {
                error2.Visible = false;
            }

            return true;
        }
    }
}
