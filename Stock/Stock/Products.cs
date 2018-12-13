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
    public partial class frmProducts : Stimulsoft.Controls.Win.DotNetBar.Metro.MetroForm
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            tbCode.Focus();
            cmbStatus.SelectedIndex = 0;
            ReloadProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                InsertOrUpdate(Int32.Parse(tbCode.Text.Trim()));
                ReloadProducts();
                btnAddUpdate.Text = "Add";
                ResetControls(); 
            }
            else
            {
                MessageBox.Show("Please fill all fields.", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCode.Focus();
            }
        }

        private void InsertOrUpdate(int key)
        {
            String query = "";
            if (Validation())
            {
                if (IsExistsProduct(key))
                {
                    query = @"UPDATE [Products]   SET  [ProductName] = '" +
                        tbName.Text + "',[ProductStatus] = '" + ((cmbStatus.SelectedIndex == 0) ? true : false)
                        + "' WHERE [ProductCode] = " + key + "";
                }
                else
                {
                    query = @"INSERT INTO [dbo].[Products] ([ProductCode],[ProductName],[ProductStatus]) VALUES
                    ('" + tbCode.Text + "','" + tbName.Text.Trim() + "' ,'" +
                        ((cmbStatus.SelectedIndex == 0) ? true : false) + "')";
                }
                StockMain.conn.Open();
                SqlCommand cmdNewProduct = new SqlCommand(query, StockMain.conn);
                cmdNewProduct.ExecuteNonQuery();
                StockMain.conn.Close();
            }else
            {
                MessageBox.Show("Please fill all fields.", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCode.Focus();
            }
        }

        private bool IsExistsProduct(int key)
        {
            SqlDataAdapter adaptor = new SqlDataAdapter(@"SELECT 1 FROM [Products] WHERE [ProductCode]="+key+"", StockMain.conn);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else return false;
        }

        private void ReloadProducts()
        {
            SqlDataAdapter adaptor = new SqlDataAdapter(@"SELECT [ProductCode],[ProductName],[ProductStatus] FROM [dbo].[Products] ", StockMain.conn);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            dgvProducts.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = dgvProducts.Rows.Add();
                dgvProducts.Rows[n].Cells[0].Value = row["ProductCode"].ToString();
                dgvProducts.Rows[n].Cells[1].Value = row["ProductName"].ToString();
                dgvProducts.Rows[n].Cells[2].Value = (((bool)row["ProductStatus"])? "Active":"Deactive");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                tbCode.Text = dgvProducts.SelectedRows[0].Cells[0].Value.ToString();
                tbName.Text = dgvProducts.SelectedRows[0].Cells[1].Value.ToString();
                cmbStatus.SelectedIndex = (((dgvProducts.SelectedRows[0].Cells[2].Value.ToString()=="Active")? 0:1));
                btnAddUpdate.Text = "Update";
            }
            catch (Exception)
            {
                MessageBox.Show("Does not exist such record.", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ResetControls()
        {
            tbCode.Clear();
            tbName.Clear();
            cmbStatus.SelectedIndex = 0;
            tbCode.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            String query = "";
            DialogResult dr = MessageBox.Show("Are you sure to delete?", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr==DialogResult.Yes)
            {
                if (IsExistsProduct(Int32.Parse(tbCode.Text.Trim())))
                {
                    query = @"DELETE FROM [Products] 
                    WHERE [ProductCode] = '" + tbCode.Text + "'";
                    StockMain.conn.Open();
                    SqlCommand cmdNewProduct = new SqlCommand(query, StockMain.conn);
                    cmdNewProduct.ExecuteNonQuery();
                    StockMain.conn.Close();
                }
                else
                {
                    MessageBox.Show("Does not exist such record.", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ReloadProducts();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        private bool Validation()
        {
            return (!String.IsNullOrEmpty(tbCode.Text) && !String.IsNullOrEmpty(tbName.Text) && cmbStatus.SelectedIndex > -1) ? true : false;
        }
    }
}
