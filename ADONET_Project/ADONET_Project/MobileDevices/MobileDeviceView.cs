﻿using System;
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

namespace ADONET_Project.MobileDevices
{
    public partial class MobileDeviceView : Form
    {
        public MobileDeviceView()
        {
            InitializeComponent();
        }

        private void MobileDeviceView_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MobileDevices", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.Columns.Add(new DataColumn("image", typeof(System.Byte[])));
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {

                        dt.Rows[i]["image"] = File.ReadAllBytes(Path.Combine(Path.GetFullPath(@"..\..\Pictures"), dt.Rows[i]["Picture"].ToString()));
                    }
                    this.dataGridView1.AutoGenerateColumns = false;
                    this.dataGridView1.DataSource = dt;
                    //this.dataGridView1.Rows[0].MinimumHeight = 200;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
