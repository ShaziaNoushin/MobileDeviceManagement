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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MobileDevices", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "MobileDevices1");

                    ds.Tables["MobileDevices1"].Columns.Add(new DataColumn("image", typeof(System.Byte[])));
                    var dt = ds.Tables["MobileDevices1"];
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {

                        dt.Rows[i]["image"] = File.ReadAllBytes(Path.Combine(Path.GetFullPath(@"..\..\Pictures"), dt.Rows[i]["Picture"].ToString()));
                    }
                   CrystalReport1 rpt = new CrystalReport1();
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource= rpt;
                    crystalReportViewer1.Refresh();
                }
            }
        }
    }
}
