using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace testapibuoi6
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiUrl = "http://localhost:5277/api/products"; // Thay b?ng URL th?c t? c?a b?n

        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonGet_Click(object sender, EventArgs e)
        {
            try
            {
                var products = await httpClient.GetFromJsonAsync<List<Product>>(apiUrl);
                dataGridView1.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi l?y d? li?u: " + ex.Message);
            }
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            var newProduct = new Product
            {
                Name = textBoxName.Text,
                Price = decimal.Parse(textBoxPrice.Text),
                Description = textBoxDescription.Text
            };

            var response = await httpClient.PostAsJsonAsync(apiUrl, newProduct);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm thành công!");
                buttonGet.PerformClick(); // Refresh
            }
            else
            {
                MessageBox.Show("Thêm th?t b?i!");
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBoxId.Text);
            var updateProduct = new Product
            {
                Id = id,
                Name = textBoxName.Text,
                Price = decimal.Parse(textBoxPrice.Text),
                Description = textBoxDescription.Text
            };

            var response = await httpClient.PutAsJsonAsync($"{apiUrl}/{id}", updateProduct);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("C?p nh?t thành công!");
                buttonGet.PerformClick();
            }
            else
            {
                MessageBox.Show("C?p nh?t th?t b?i!");
            }
        }
        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nh?p t? khóa ?? tìm ki?m.");
                return;
            }

            try
            {
                var searchUrl = $"{apiUrl}/search?name={Uri.EscapeDataString(keyword)}";
                var products = await httpClient.GetFromJsonAsync<List<Product>>(searchUrl);
                dataGridView1.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi tìm ki?m: " + ex.Message);
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBoxId.Text);
            var response = await httpClient.DeleteAsync($"{apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Xoá thành công!");
                buttonGet.PerformClick();
            }
            else
            {
                MessageBox.Show("Xoá th?t b?i!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
