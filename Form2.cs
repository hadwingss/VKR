using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VKR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginTXT = textBox1.Text;
            string passwordTXT = textBox2.Text;

            string connStr = "server=pma.sdlik.ru;port=62002;user=st_17;database=is_17_EKZ;password=123456789;";
            MySqlConnection conn;
            conn = new MySqlConnection(connStr);
            conn.Open();
            string querySql = $"SELECT COUNT(*) FROM vkrrr WHERE log_users='{loginTXT}' AND pass_users='{passwordTXT}'and enable_users=1";
            MySqlCommand authCom = new MySqlCommand(querySql, conn);
            string result = authCom.ExecuteScalar().ToString();

            if (Convert.ToInt32(result) > 0)
            {
                MessageBox.Show($"Авторизация пользователя:{loginTXT} успешна.");
                this.Close();
            }
            else
            {
                MessageBox.Show($"Авторизация пользователя:{loginTXT} не удалась.");
                Application.Exit();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
