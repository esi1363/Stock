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
    public partial class StockList : Stimulsoft.Controls.Win.DotNetBar.Metro.MetroForm
    {
        ReportDocument rd = new ReportDocument();
        public StockList()
        {
            InitializeComponent();
        }

        private void StockList_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rd.Load(@"E:\CodeBase\StockRepo\Stock\Stock\Stock\Reports\Stocks.rpt");
            SqlConnection conn = StockMain.conn;
            if (conn.State != ConnectionState.Closed)
                conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from [Stock] Where Cast(TransDate as Date) Between '"+dateTimePicker1.Value.ToString("yyyy/MM/dd") +"' and '"+dateTimePicker2.Value.ToString("yyyy/MM/dd") +"'", conn);
            DataTable dt = new DataTable();
            adaptor.Fill(ds,"Stock" );
            rd.SetDataSource(ds);
            rd.SetParameterValue("@FromDate", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            rd.SetParameterValue("@ToDate", dateTimePicker2.Value.ToString("yyyy/MM/dd"));
            crystalReportViewer1.ReportSource = rd;
            conn.Close();
        }
    }
}
