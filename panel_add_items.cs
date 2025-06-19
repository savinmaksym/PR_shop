using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_shop
{
    public partial class panel_add_items : Form
    {
        public panel_add_items()
        {
            InitializeComponent();
        }

        private async void add_item_to_database()
        {
            string itemName = textBox_name.Text;
            string itemImageUrl = textBox_image_url.Text;
            decimal itemPrice;
            int itemAmount;

            // Перевірка ціни
            if (!decimal.TryParse(textBox_price.Text, out itemPrice))
            {
                MessageBox.Show("Ціна вказана неправильно.");
                return;
            }

            if (!int.TryParse(textBox_amount.Text, out itemAmount))
            {
                MessageBox.Show("кількість вказана неправильно.");
                return;
            }

            var requestBody = new
            {
                fields = new
                {
                    name = new { stringValue = itemName },
                    price = new { doubleValue = itemPrice },
                    image_url = new { stringValue = itemImageUrl },
                    amount = new { integerValue = itemAmount }
                }
            };

            string json = JsonConvert.SerializeObject(requestBody);


            string projectId = "pr-shop-20470";
            string url = $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents/items";

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Товар успішно додано до бази даних!");
                    textBox_name.Clear();
                    textBox_image_url.Clear();
                    textBox_price.Clear();
                    textBox_amount.Clear();
                    if (shop.Instance != null && !shop.Instance.IsDisposed)
                    {
                        shop.Instance.LoadProducts();
                    }
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Помилка при додаванні товару: {response.StatusCode}\n\n{error}");
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            add_item_to_database();
        }

        private void panel_add_items_Load(object sender, EventArgs e)
        {

        }
    }
}
