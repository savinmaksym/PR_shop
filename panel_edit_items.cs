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
    public partial class panel_edit_items : Form
    {
        public panel_edit_items()
        {
            InitializeComponent();
            LoadProductNamesToComboBox();
        }
        public class ComboBoxItem
        {
            public string Name { get; set; }
            public string DocumentId { get; set; }
            public override string ToString() => Name;
        }


        private async void LoadProductNamesToComboBox()
        {
            string url = "https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/items";
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Помилка завантаження назв товарів.");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();
            var firestoreResponse = JsonConvert.DeserializeObject<FirestoreResponse>(json);

            comboBox_name.Items.Clear();
            foreach (var doc in firestoreResponse.documents)
            {
                string name = doc.fields["name"]?.stringValue ?? "???";
                string docId = doc.name.Split('/').Last(); 
                comboBox_name.Items.Add(new ComboBoxItem { Name = name, DocumentId = docId });
            }
        }

        private async void comboBox_search()
        {
            var selected = comboBox_name.SelectedItem as ComboBoxItem;
            if (selected == null) return;

            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/items/{selected.DocumentId}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Не вдалося отримати товар.");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();
            var doc = JsonConvert.DeserializeObject<FirestoreDocument>(json);

            textBox_name.Text = doc.fields["name"]?.stringValue ?? "";
            textBox_price.Text = (doc.fields["price"]?.doubleValue)?.ToString() ?? "";
            textBox_image_url.Text = doc.fields["image_url"]?.stringValue ?? "";
            textBox_count.Text = (doc.fields["amount"]?.integerValue)?.ToString() ?? "";

            pictureBox.ImageLocation = doc.fields["image_url"]?.stringValue ?? "";
        }

        private async void SaveChanges()
        {
            var selected = comboBox_name.SelectedItem as ComboBoxItem;
            if (selected == null) return;

            string docId = selected.DocumentId;
            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/items/{docId}";

            var body = new
            {
                fields = new Dictionary<string, object>
                {
                    ["name"] = new { stringValue = textBox_name.Text },
                    ["price"] = new { doubleValue = Convert.ToDouble(textBox_price.Text) },
                    ["image_url"] = new { stringValue = textBox_image_url.Text },
                    ["amount"] = new { integerValue = Convert.ToInt32(textBox_count.Text)
                    }
                }
            };

            string json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            var response = await httpClient.PatchAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Товар оновлено.");
                LoadProductNamesToComboBox();
                Instance.LoadProducts();
            }
            else
            {
                MessageBox.Show("Помилка при збереженні.");
            }
        }

        private async void DeleteProduct()
        {
            var selected = comboBox_name.SelectedItem as ComboBoxItem;
            if (selected == null) return;

            string docId = selected.DocumentId;
            string url = $"https://firestore.googleapis.com/v1/projects/pr-shop-20470/databases/(default)/documents/items/{docId}";

            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Товар видалено.");
                LoadProductNamesToComboBox();
                textBox_name.Text = "";
                textBox_price.Text = "";
                textBox_image_url.Text = "";
                textBox_count.Text = "";
                Instance.LoadProducts();
            }
            else
            {
                MessageBox.Show("Помилка при видаленні.");
            }
        }



        private void button_search_Click(object sender, EventArgs e)
        {
            comboBox_search();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }
        private void button_delet_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }
    }
    
}
