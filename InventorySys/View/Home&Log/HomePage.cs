using InventorySys.Model;
using InventorySys.View.Home_Log;
using InventorySys.View.Product;
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

namespace InventorySys.View
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        bool toggle = false;
        string start;
        public int emp_id { get; set; }
        public string app = "Mini Mart Inventory Management System";

        void btnStyle(object sender)
        {
            foreach (Control control in pnSidebar.Controls)
            {
                control.BackColor = Color.FromArgb(52, 58, 64);
                control.Font = new Font("Poppins", 11.5f, FontStyle.Regular);
            }
            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(73, 78, 83);
            click.Font = new Font("Poppins", 12f, FontStyle.Bold);
            btnMenu.BackColor = Color.FromArgb(4, 15, 34);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("D");
            lbTime.Text = DateTime.Now.ToString("T");

            int timeout = Convert.ToInt16(start) + 1;
        }

        private void tmToggle_Tick(object sender, EventArgs e)
        {
            if (!toggle)
            {
                if (pnSidebar.Width > 50)
                {
                    pnSidebar.Width -= 5;
                    foreach (Control control in pnSidebar.Controls)
                        control.Text = "";

                    if (pnSidebar.Width <= 50)
                    {
                        tmToggle.Enabled = false;
                        toggle = true;
                    }
                }
            }
            if (toggle)
            {
                if (pnSidebar.Width <= 170)
                {
                    pnSidebar.Width += 5;
                    if (pnSidebar.Width >= 170)
                    {
                        tmToggle.Enabled = false;
                        toggle = false;

                        btnMenu.Text = "Menu";
                        btnDash.Text = "Dashboard";
                        btnPro.Text = "Product";
                    }
                }
            }
        }

        void LogRecord()
        {
            using (SqlConnection conn = new SqlConnection(db.conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO tbl_logrecord (emp_id, login) VALUES (@id, @log)", conn);
                cmd.Parameters.AddWithValue("@id",emp_id);
                cmd.Parameters.AddWithValue("@log", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //if(PubCls.CheckName("app", db.conStr) == "0")
            //{
            //    AppName app = new AppName();
            //    if (app.ShowDialog() == DialogResult.OK)
            //        lbAppname.Text = this.app;
            //}
            //else 
            //    lbAppname.Text=PubCls.CheckName(app, db.conStr);
            
            LogRecord();
            btnStyle(btnDash);
            LogPage log = new LogPage();
            ProductPage product = new ProductPage();
            product.TopLevel = false;
            product.Dock = DockStyle.Fill;
            pnMaster.Controls.Add(product);
            product.Show();
            product.BringToFront();
            //if (log.ShowDialog() == DialogResult.OK)
            //{

            //}
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            tmToggle.Enabled = true;
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            btnStyle(btnDash);
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            btnStyle(btnPro);
        }

        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(db.conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO tbl_logrecord (emp_id, logout) VALUES (@id, @log)", conn);
                cmd.Parameters.AddWithValue("@id", emp_id);
                cmd.Parameters.AddWithValue("@log", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
