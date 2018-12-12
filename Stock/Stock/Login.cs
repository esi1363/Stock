using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ESFANDIYARI-PC\SQL2016;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter adaptor = new SqlDataAdapter(@"SELECT [Username],[Password] FROM[dbo].[Login] WHERE Username='"+textBox1.Text+"' AND Password='"+textBox2.Text+"'",conn);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            if (dt.Rows.Count==1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();

            }else
            {
                MessageBox.Show("User Not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
        }
    }
}
