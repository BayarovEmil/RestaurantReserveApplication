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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = ofd.FileName;

                pictureBox1.Image = Image.FromFile(selectedImagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Şəkili PictureBox-a uyğunlaşdır
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string foodName = name.Text;
            string foodPrice = price.Text;
            string foodQuantity = quantity.Text;
            string imagePath = "C:\\path\\to\\your\\image.jpg";

            if (pictureBox1.Image != null)
            {
                string tempImagePath = Path.Combine(Path.GetTempPath(), $"{foodName}.jpg");
                pictureBox1.Image.Save(tempImagePath);
                imagePath = tempImagePath;
            }

            string foodData = $"{foodName}:{foodPrice}:{foodQuantity}:{imagePath};";
            string dataFilePath = "C:\\Users\\LENOVO\\Desktop\\FoodData.txt";

            File.AppendAllText(dataFilePath, foodData);
            MessageBox.Show("Food added successfully");

            name.Clear();
            price.Text = String.Empty;
            quantity.Text = String.Empty;
            pictureBox1.Image = null;
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
