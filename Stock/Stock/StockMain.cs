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
    public partial class StockMain : Form
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=ESFANDIYARI-PC\SQL2016;Initial Catalog=Stock;Integrated Security=True");
        
        public StockMain()
        {
            InitializeComponent();
        }

        private void StockMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts pro = new frmProducts();
            pro.MdiParent = this;   
            pro.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
