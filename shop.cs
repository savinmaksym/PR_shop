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
using Newtonsoft.Json.Linq;

namespace PR_shop
{
    public partial class shop : Form
    {
        int permission; // 1 - user, 2 - admin
        string username; 
        public static shop Instance;
        public shop(string usern, int status)
        {
            username = usern.ToLower();
            permission = status;
            InitializeComponent();
            Instance = this;
            label_shop_username.Text = username;
        }
        private void shop_Load(object sender, EventArgs e)
        {
            LoadProducts();
            if (permission == 2)
            {
                label_admin_panel.Visible = true;
            }
            else
            {
                label_admin_panel.Visible = false;
            }
        }
        
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public int Amount { get; set; }
            public string Id { get; set; } // айди документа товару
        }
        public class FirestoreResponse
        {
            public List<FirestoreDocument> documents { get; set; }
        }

        public class FirestoreDocument
        {
            public string name { get; set; } // назва документа
            public Dictionary<string, FirestoreField> fields { get; set; }
        }

        public class FirestoreField
        {
            public string stringValue { get; set; }
            public double? doubleValue { get; set; }
            public string integerValue { get; set; }
            public List<FirestoreField> values { get; set; }
            public FirestoreArray arrayValue { get; set; }
        }
        public class FirestoreArray
        {
            public List<FirestoreField> values { get; set; }
        }


        private async void add_to_cart(string productId, string username)
        {
            string projectId = "pr-shop-20470";
            string url = $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents/users/{username}";

            using (var httpClient = new HttpClient())
            {
               
                var getResponse = await httpClient.GetAsync(url);
                if (!getResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Не вдалося отримати документ.");
                    return;
                }

                var json = await getResponse.Content.ReadAsStringAsync();
                var document = JsonConvert.DeserializeObject<FirestoreDocument>(json);

                List<string> cart = new List<string>();
                if (document.fields != null && document.fields.ContainsKey("cart"))
                {
                    var items = document.fields["cart"].arrayValue?.values;
                    if (items != null)
                    {
                        foreach (var item in items)
                        {
                            if (!string.IsNullOrEmpty(item.stringValue))
                                cart.Add(item.stringValue);
                        }
                    }
                }

               
                if (!cart.Contains(productId))
                    cart.Add(productId);

                
                JObject body = new JObject
                {
                    ["fields"] = new JObject
                    {
                        ["cart"] = new JObject
                        {
                            ["arrayValue"] = new JObject
                            {
                                ["values"] = new JArray(
                                    cart.Select(id =>
                                        new JObject
                                        {
                                            ["stringValue"] = id
                                        }
                                    )
                                )
                            }
                        }
                    }
                };

                if (document.fields.ContainsKey("password") && document.fields["password"]?.stringValue != null)
                {
                    body["fields"]["password"] = new JObject
                    {
                        ["stringValue"] = document.fields["password"].stringValue
                    };
                }

                if (document.fields.ContainsKey("permissionLevel") && document.fields["permissionLevel"]?.integerValue != null)
                {
                    body["fields"]["permissionLevel"] = new JObject
                    {
                        ["integerValue"] = document.fields["permissionLevel"].integerValue
                    };
                }

               
                var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                var patchResponse = await httpClient.PatchAsync(url, content);

                if (!patchResponse.IsSuccessStatusCode)
                {
                    string error = await patchResponse.Content.ReadAsStringAsync();
                    MessageBox.Show($"❌ Помилка оновлення:\n{patchResponse.StatusCode}\n{error}");
                }
                else
                {
                    //MessageBox.Show("Додано до корзини.");
                }
            }
        }


        private async Task<bool> IsProductInCart(string productId, string username)
        {
            //string projectId = "pr-shop-20470"; 
            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users/{username}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Не вдалося отримати дані користувача: {response.StatusCode}");
                    return false;
                }

                string json = await response.Content.ReadAsStringAsync();
                var document = JsonConvert.DeserializeObject<FirestoreDocument>(json);

                if (document.fields != null && document.fields.ContainsKey("cart"))
                {
                    var cartValues = document.fields["cart"].arrayValue?.values;
                    if (cartValues != null)
                    {
                        foreach (var item in cartValues)
                        {
                            if (item.stringValue == productId)
                                return true;
                        }
                    }
                }
            }

            return false;
        }





        private async Task<Panel> CreateProductCard(Product product)
        {
            var panel = new Panel
            {
                Width = 150,
                Height = 230,
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
                Height = 20,
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
                Top = 150,
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
                Top = 175,
                Left = 10,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };


            // Кнопка "Додати в корзину"
            bool check = await IsProductInCart(product.Id, username);
            Button addToCartButton = new Button
            {
               
                Enabled = product.Amount > 0 && !check,
                Text = check ? "Вже в корзині" : (product.Amount > 0 ? "Додати в корзину" : "Немає в наявності"),

                Width = 130,
                Height = 25,
                Top = 195,
                Left = 10
            };
            
            addToCartButton.Click += (s, e) =>
            {
                add_to_cart(product.Id, username);
                LoadProducts(); // Оновлюємо список товарів після додавання
                //MessageBox.Show($"Товар \"{product.Name}\" додано в корзину!");
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

                string id = doc.name.Split('/').Last(); // Отримуємо ID документа

                products.Add(new Product
                {
                    Name = name,
                    Price = price,
                    ImageUrl = imageUrl,
                    Amount = amount,
                    Id = id
                });
            }

            // Показ товарів
            flowLayoutPanel.Controls.Clear();
            foreach (var product in products)
            {
                flowLayoutPanel.Controls.Add(await CreateProductCard(product));
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

        private void go_to_cart()
        {
            cart cartForm = new cart(username);
            cartForm.ShowDialog();
        }







        private void pictureBox1_Click(object sender, EventArgs e)
        {
            exit_to_login();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            go_to_admin_panel();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            go_to_cart();
        }
    }
}
