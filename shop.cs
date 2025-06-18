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
    public partial class shop : Form
    {
        public shop(string username)
        {
            InitializeComponent();
            label_shop_username.Text = username;
        }
        private void shop_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; } 
        }
        public class FirestoreResponse
        {
            public List<FirestoreDocument> documents { get; set; }
        }

        public class FirestoreDocument
        {
            public Dictionary<string, FirestoreField> fields { get; set; }
        }

        public class FirestoreField
        {
            public string stringValue { get; set; }
            public double? doubleValue { get; set; }
            public string integerValue { get; set; }
        }



        private Panel CreateProductCard(Product product)
        {
            var panel = new Panel
            {
                Width = 150,
                Height = 220,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Зображення
            PictureBox picture = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 130,
                Height = 100,
                ImageLocation = product.ImageUrl, // або .Image = product.ImageData;
                Top = 10,
                Left = 10
            };

            // Назва
            Label nameLabel = new Label
            {
                Text = product.Name,
                AutoSize = false,
                Width = 130,
                Height = 40,
                Top = 120,
                Left = 10,
                TextAlign = ContentAlignment.TopCenter
            };

            // Ціна
            Label priceLabel = new Label
            {
                Text = product.Price.ToString("C"), // формат валюти
                AutoSize = false,
                Width = 130,
                Top = 170,
                Left = 10,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            panel.Controls.Add(picture);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);

            return panel;
        }


        private async void LoadProducts()
        {
            string projectId = "pr-shop-20470";
            string url = $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents/items";

            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Помилка завантаження товарів з Firestore.");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();
            var firestoreResponse = JsonConvert.DeserializeObject<FirestoreResponse>(json);

            var products = new List<Product>();

            foreach (var doc in firestoreResponse.documents)
            {
                string name = doc.fields["name"]?.stringValue ?? "???";
                //decimal price = Convert.ToDecimal(doc.fields["price"]?.doubleValue ?? 0);
                decimal price = 0;
                if (doc.fields["price"]?.doubleValue != null)
                    price = Convert.ToDecimal(doc.fields["price"].doubleValue);
                else if (doc.fields["price"]?.integerValue != null)
                    price = Convert.ToDecimal(doc.fields["price"].integerValue);
                string imageUrl = doc.fields["image_url"]?.stringValue ?? "";

                products.Add(new Product
                {
                    Name = name,
                    Price = price,
                    ImageUrl = imageUrl
                });
            }

            // Показ товарів
            flowLayoutPanel.Controls.Clear();
            foreach (var product in products)
            {
                flowLayoutPanel.Controls.Add(CreateProductCard(product));
            }
        }







        private void exit_to_login()
        {
            string filePath = "login_data.txt";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            login loginForm = new login();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            exit_to_login();
        }
    }
}
