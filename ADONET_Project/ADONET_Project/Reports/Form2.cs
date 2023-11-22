using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET_Project.Reports
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MobileDevices", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "MobileDevices");
                    da.SelectCommand.CommandText = "SELECT * FROM OrderItems";
                    da.Fill(ds, "OrderItems");

                    CrystalReport2 rpt = new CrystalReport2();
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                }
            }
        }
    }
}
