using RemoteService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintainProducts
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        HttpClient client = new HttpClient();
        string baseUri = "http://localhost:65508/api/product/";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                HttpResponseMessage resp = client.GetAsync(baseUri).Result;
                resp.EnsureSuccessStatusCode();
                List<Product> proList = resp.Content.ReadAsAsync<List<Product>>().Result;
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = proList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                int ProductID = int.Parse(txtProductID.Text);
                string ProductName = txtProductName.Text;
                float Price = float.Parse(txtUnitPrice.Text);
                int Quantity = int.Parse(txtQuantity.Text);
                Product p = new Product()
                {
                    ProductID = ProductID,
                    ProductName = ProductName,
                    Quantity = Quantity,
                    UnitPrice = Price
                };
                HttpResponseMessage resp = client.PostAsJsonAsync(baseUri, p).Result;
                resp.EnsureSuccessStatusCode();
                MessageBox.Show("Product is saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int ProductID = int.Parse(txtProductID.Text);
                HttpResponseMessage resp = client.DeleteAsync(baseUri + ProductID).Result;
                resp.EnsureSuccessStatusCode();
                MessageBox.Show("Delete Successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int ProductID = int.Parse(txtProductID.Text);
                HttpResponseMessage resp = client.GetAsync(baseUri + ProductID).Result;
                resp.EnsureSuccessStatusCode();
                Product p = resp.Content.ReadAsAsync<Product>().Result;
                if (p == null)
                {
                    MessageBox.Show("Product not found!");
                }
                else
                {
                    txtProductName.Text = p.ProductName;
                    txtQuantity.Text = p.Quantity.ToString();
                    txtUnitPrice.Text = p.UnitPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            dgvProducts.DataSource = null;
        }
    }
}
