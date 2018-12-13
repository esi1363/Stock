using Stock.ReportsForm;
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
    public partial class StockMain : Stimulsoft.Controls.Win.DotNetBar.Metro.MetroForm
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
            Stocks stocks = new Stocks();
            stocks.MdiParent = this;
            stocks.Show();
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsList pr = new ProductsList();
            pr.MdiParent = this;
            pr.Show();
        }

        private void stockListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockList sr = new StockList();
            sr.MdiParent = this;
            sr.Show();
        }
    }
}
