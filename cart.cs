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
using static PR_shop.shop;

namespace PR_shop
{
    public partial class cart : Form
    {
        string username;
        public cart(string usern)
        {
            username = usern.ToLower();
            InitializeComponent();
        }

        private void cart_Load(object sender, EventArgs e)
        {
            LoadCartFromFirestore(username);
        }
        public class CartItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
        }


        private async void LoadCartFromFirestore(string username)
        {
            string userUrl = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users/{username}";
            string itemBaseUrl = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/items";

            var httpClient = new HttpClient();

            HttpResponseMessage userResponse = await httpClient.GetAsync(userUrl);
            if (!userResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("Не вдалося отримати дані користувача.");
                return;
            }

            string userJson = await userResponse.Content.ReadAsStringAsync();
            var userDoc = JsonConvert.DeserializeObject<FirestoreDocument>(userJson);

           
            var cart = new List<string>();

            if (userDoc.fields != null && userDoc.fields.ContainsKey("cart"))
            {
                var cartValues = userDoc.fields["cart"]?.arrayValue?.values;
                if (cartValues != null)
                {
                    foreach (var item in cartValues)
                    {
                        if (!string.IsNullOrEmpty(item.stringValue))
                            cart.Add(item.stringValue);
                    }
                }
            }

            if (cart.Count == 0)
            {
                //MessageBox.Show("Корзина порожня.");
                return;
            }

            flowLayoutPanel.Controls.Clear();

            foreach (var productId in cart)
            {
                string productUrl = $"{itemBaseUrl}/{productId}";
                HttpResponseMessage productResponse = await httpClient.GetAsync(productUrl);
                if (!productResponse.IsSuccessStatusCode)
                    continue;

                string productJson = await productResponse.Content.ReadAsStringAsync();
                var doc = JsonConvert.DeserializeObject<FirestoreDocument>(productJson);

                decimal price = 0;
                if (doc.fields["price"]?.doubleValue != null)
                    price = Convert.ToDecimal(doc.fields["price"].doubleValue);
                else if (doc.fields["price"]?.integerValue != null)
                    price = Convert.ToDecimal(doc.fields["price"].integerValue);

                string name = doc.fields["name"]?.stringValue ?? "???";
                string image = doc.fields["image_url"]?.stringValue ?? "";

                var item = new CartItem
                {
                    Id = productId,
                    Name = name,
                    Price = price,
                    ImageUrl = image
                };

                flowLayoutPanel.Controls.Add(CreateCartItemCard(item));
            }
        }
        private Control CreateCartItemCard(CartItem item)
        {
            var panel = new Panel
            {
                Width = 300,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            var pictureBox = new PictureBox
            {
                Width = 100,
                Height = 100,
                ImageLocation = item.ImageUrl,
                SizeMode = PictureBoxSizeMode.Zoom,
                Left = 10,
                Top = 10
            };

            var labelName = new Label
            {
                Text = item.Name,
                Left = 120,
                Top = 10,
                Width = 160,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var labelPrice = new Label
            {
                Text = $"Ціна: {item.Price} грн",
                Left = 120,
                Top = 40,
                Width = 160
            };

            var quantitySelector = new NumericUpDown
            {
                Left = 120,
                Top = 70,
                Width = 60,
                Minimum = 1,
                Maximum = 100,
                Value = 1
            };

            var buttonDel = new Button
            {
                Text = "Видалити",
                Left = 190,
                Top = 70,
                Width = 80,
                Height = 25
            };

            buttonDel.Click += async (s, e) =>
            {
                RemoveItemFromCart(item, panel);
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(labelName);
            panel.Controls.Add(labelPrice);
            panel.Controls.Add(quantitySelector);
            panel.Controls.Add(buttonDel);

            return panel;
        }

        private async Task RemoveItemFromCart(CartItem item, Panel panel)
        {
            string userUrl = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users/{username}";
            var httpClient = new HttpClient();

            HttpResponseMessage getResponse = await httpClient.GetAsync(userUrl);
            if (!getResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("Не вдалося отримати дані користувача.");
                return;
            }

            string json = await getResponse.Content.ReadAsStringAsync();
            var userDoc = JsonConvert.DeserializeObject<FirestoreDocument>(json);

            var cart = new List<string>();
            if (userDoc.fields != null && userDoc.fields.ContainsKey("cart"))
            {
                var cartItems = userDoc.fields["cart"].arrayValue?.values;
                if (cartItems != null)
                {
                    foreach (var cartItem in cartItems)
                    {
                        if (!string.IsNullOrEmpty(cartItem.stringValue))
                            cart.Add(cartItem.stringValue);
                    }
                }
            }

            if (!cart.Contains(item.Id))
                return;

            cart.Remove(item.Id);

            var updateFields = new Dictionary<string, object>();

            // зберігаємо password
            if (userDoc.fields.ContainsKey("password") && userDoc.fields["password"].stringValue != null)
            {
                updateFields["password"] = new { stringValue = userDoc.fields["password"].stringValue };
            }

            // зберігаємо permissionLevel
            if (userDoc.fields.ContainsKey("permissionLevel"))
            {
                if (userDoc.fields["permissionLevel"].integerValue != null)
                {
                    updateFields["permissionLevel"] = new { integerValue = userDoc.fields["permissionLevel"].integerValue };
                }
                else if (userDoc.fields["permissionLevel"].stringValue != null)
                {
                    updateFields["permissionLevel"] = new { stringValue = userDoc.fields["permissionLevel"].stringValue };
                }
            }

            // оновлюємо cart
            updateFields["cart"] = new
            {
                arrayValue = new
                {
                    values = cart.Select(id => new { stringValue = id }).ToArray()
                }
            };

            var updateBody = new { fields = updateFields };
            string updateJson = JsonConvert.SerializeObject(updateBody);
            var content = new StringContent(updateJson, Encoding.UTF8, "application/json");

            // 5. Відправляємо PATCH-запит
            HttpResponseMessage patchResponse = await httpClient.PatchAsync(userUrl, content);
            if (patchResponse.IsSuccessStatusCode)
            {
                flowLayoutPanel.Controls.Remove(panel); // прибираємо товар з UI

                if (shop.Instance != null && !shop.Instance.IsDisposed)
                {
                    shop.Instance.LoadProducts(); // оновлюємо магазин
                }
            }
            else
            {
                string error = await patchResponse.Content.ReadAsStringAsync();
                MessageBox.Show($"Помилка при видаленні з корзини:\n{patchResponse.StatusCode}\n{error}");
            }
        }


        private async void clear_cart()
        {
            string userUrl = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/users/{username}";
            var httpClient = new HttpClient();

            HttpResponseMessage getResponse = await httpClient.GetAsync(userUrl);
            if (!getResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("Не вдалося отримати дані користувача.");
                return;
            }

            string userJson = await getResponse.Content.ReadAsStringAsync();
            var userDoc = JsonConvert.DeserializeObject<FirestoreDocument>(userJson);

            if (userDoc.fields == null)
            {
                MessageBox.Show("Документ не містить полів.");
                return;
            }

            var updateFields = new Dictionary<string, object>();

            if (userDoc.fields.ContainsKey("password") && userDoc.fields["password"].stringValue != null)
            {
                updateFields["password"] = new
                {
                    stringValue = userDoc.fields["password"].stringValue
                };
            }

            if (userDoc.fields.ContainsKey("permissionLevel"))
            {
                if (userDoc.fields["permissionLevel"].integerValue != null)
                {
                    updateFields["permissionLevel"] = new
                    {
                        integerValue = userDoc.fields["permissionLevel"].integerValue
                    };
                }
                else if (userDoc.fields["permissionLevel"].stringValue != null)
                {
                    updateFields["permissionLevel"] = new
                    {
                        stringValue = userDoc.fields["permissionLevel"].stringValue
                    };
                }
            }

            // очищаємо cart
            updateFields["cart"] = new
            {
                arrayValue = new
                {
                    values = new object[] { }
                }
            };

            //Відправляємо PATCH
            var updateBody = new { fields = updateFields };
            string json = JsonConvert.SerializeObject(updateBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage patchResponse = await httpClient.PatchAsync(userUrl, content);
            if (patchResponse.IsSuccessStatusCode)
            {
                flowLayoutPanel.Controls.Clear();
                LoadCartFromFirestore(username);

                if (shop.Instance != null && !shop.Instance.IsDisposed)
                {
                    shop.Instance.LoadProducts();
                }
            }
            else
            {
                string error = await patchResponse.Content.ReadAsStringAsync();
                MessageBox.Show($"Помилка при оновленні корзини:\n{patchResponse.StatusCode}\n{error}");
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            clear_cart();
        }
    }
}
