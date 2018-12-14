using CrystalDecisions.CrystalReports.Engine;
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

namespace Stock.ReportsForm
{
    public partial class ProductsList : Stimulsoft.Controls.Win.DotNetBar.Metro.MetroForm
    {
        ReportDocument rd = new ReportDocument();
        public ProductsList()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ProductsList_Load(object sender, EventArgs e)
        {
            rd.Load(@"E:\CodeBase\StockRepo\Stock\Stock\Stock\Reports\Products.rpt");
            SqlConnection conn = StockMain.conn;
            if(conn.State!=ConnectionState.Closed)
                conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from [Products]",conn);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            rd.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rd;
            conn.Close();

        }
    }
}
