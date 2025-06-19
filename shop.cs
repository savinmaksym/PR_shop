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
        int permission; // 1 - user, 2 - admin
        public static shop Instance;
        public shop(string username, int status)
        {
            permission = status; 
            InitializeComponent();
            Instance = this;
            label_shop_username.Text = username;
        }
        private void shop_Load(object sender, EventArgs e)
        {
            LoadProducts();
            if(permission == 2)
            {
                label_admin_panel.Visible = true;
            }
            else
            {
                label_admin_panel.Visible = false;
            }
        }
        // Додайте властивість Amount до класу Product:
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public int Amount { get; set; }
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
                Height = 260,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Зображення
            PictureBox picture = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 130,
                Height = 100,
                ImageLocation = product.ImageUrl,
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
                Text = product.Price.ToString("C"),
                AutoSize = false,
                Width = 130,
                Top = 170,
                Left = 10,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // Кількість (amount)
            Label amountLabel = new Label
            {
                Text = $"Залишилось: {product.Amount}",
                AutoSize = false,
                Width = 130,
                Height = 20,
                Top = 195,
                Left = 10,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };

            // Кнопка "Додати в корзину"
            Button addToCartButton = new Button
            {
                Text = "Додати в корзину",
                Width = 130,
                Height = 25,
                Top = 220,
                Left = 10
            };
            addToCartButton.Click += (s, e) =>
            {
                // TODO: Додати логіку додавання в корзину
                MessageBox.Show($"Товар \"{product.Name}\" додано в корзину!");
            };

            panel.Controls.Add(picture);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(amountLabel);
            panel.Controls.Add(addToCartButton);

            return panel;
        }


        public async void LoadProducts()
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
                decimal price = 0;
                if (doc.fields["price"]?.doubleValue != null)
                    price = Convert.ToDecimal(doc.fields["price"].doubleValue);
                else if (doc.fields["price"]?.integerValue != null)
                    price = Convert.ToDecimal(doc.fields["price"].integerValue);
                string imageUrl = doc.fields["image_url"]?.stringValue ?? "";

                int amount = 0;
                if (doc.fields["amount"]?.integerValue != null)
                    amount = int.Parse(doc.fields["amount"].integerValue);

                products.Add(new Product
                {
                    Name = name,
                    Price = price,
                    ImageUrl = imageUrl,
                    Amount = amount
                });
            }

            // Показ товарів
            flowLayoutPanel.Controls.Clear();
            foreach (var product in products)
            {
                flowLayoutPanel.Controls.Add(CreateProductCard(product));
            }
        }



        private void go_to_admin_panel()
        {
            admin_panel adminPanel = new admin_panel();
            adminPanel.ShowDialog();
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

        private void label1_Click(object sender, EventArgs e)
        {
            go_to_admin_panel();
        }
    }
}
