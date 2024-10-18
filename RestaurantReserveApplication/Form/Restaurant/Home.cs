using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantReserveApplication
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            LoadFoods();
        }

        private void LoadFoods()
        {
            string dataFilePath = "C:\\Users\\LENOVO\\Desktop\\FoodData.txt";
            DataTable dt = new DataTable();

            dt.Columns.Add("Food Name", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Image Path", typeof(string));

            if (File.Exists(dataFilePath))
            {
                string[] lines = File.ReadAllLines(dataFilePath);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length >= 4)
                    {
                        string foodName = parts[0].Trim();
                        decimal price = decimal.Parse(parts[1].Trim());
                        int quantity = int.Parse(parts[2].Trim());
                        string imagePath = parts[3].Trim().TrimEnd(';');

                        dt.Rows.Add(foodName, price, quantity, imagePath);
                    }
                }
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Image Path"].Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string foodName = dataGridView1.Rows[e.RowIndex].Cells["Food Name"].Value.ToString();
                string price = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                string quantity = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                string imagePath = dataGridView1.Rows[e.RowIndex].Cells["Image Path"].Value.ToString();

                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Şəkil tapılmadı!");
                }

                textBox1.Text = foodName;
                label2.Text = $"Ad: {foodName}";
                label3.Text = $"Qiymət: {price}";
                label4.Text = $"Miqdar: {quantity}";
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
