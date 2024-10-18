using System;
using System.IO;
using System.Windows.Forms;

namespace RestaurantReserveApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            string path = "C:\\Users\\LENOVO\\Desktop\\myDB.txt";

            if (email=="admin" && password == "12345")
            {
                AdminPanel admin = new AdminPanel();
                admin.Show();
                this.Close();
            }
            bool isFound = false;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length > 0)
                        {
                           string[] userInfo = parts[0].Split(':');

                            if (userInfo.Length == 3) 
                            {
                                string emailf = userInfo[1].Trim();
                                string passwordf = userInfo[2].Trim();

                                if (emailf == email && passwordf == password)
                                {
                                    isFound = true;
                                    MessageBox.Show("User logged in successfully!");
                                    Home home = new Home();
                                    home.Show();
                                    this.Close();

                                    break;
                                }
                            }
                        }
                    }
                }

                if (!isFound)
                {
                    MessageBox.Show("Email və ya parol səhvdir.", "Xəta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xəta baş verdi: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
