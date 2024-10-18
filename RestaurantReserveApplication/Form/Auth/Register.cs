using Newtonsoft.Json;
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
    public partial class Register : Form
    {
        DataTable dataTable = new DataTable();
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = "C:\\Users\\LENOVO\\Desktop\\myDB.txt";
            //using(StreamWriter sw = new StreamWriter(path,true))
            //{
            //    sw.WriteLine(nameText.Text+ ": " + emailText.Text+":"+passwordText.Text+";");
            //    sw.Close();
            //}
            dataTable.Rows.Add(nameText.Text);
            string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
            File.WriteAllText(path, json);

            string readJson = File.ReadAllText(path);
            DataTable data = JsonConvert.DeserializeObject<DataTable>(readJson);

            MessageBox.Show("User registered successfully!");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
