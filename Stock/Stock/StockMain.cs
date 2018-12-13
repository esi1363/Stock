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
        public static SqlConnection conn = Connection.GetConnection();
        
        public StockMain()
        {
            InitializeComponent();
        }

        private void StockMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit application?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }else
            {
            }
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
