using InventorySys.Model;
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

namespace InventorySys.View.Home_Log
{
    public partial class LogPage : Form
    {
        public LogPage()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                if (PubCls.Validation(txtUser, txtPass))
                {
                    using (SqlConnection conn = new SqlConnection(db.conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT emp_id FROM tbl_user WHERE usr_us = @usr AND usr_pass = @pas", conn);
                        cmd.Parameters.AddWithValue("@usr", txtUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@pas", txtPass.Text.Trim());
                        HomePage page = new HomePage();
                        page.emp_id = 9;
                        //page.emp_id = Convert.ToInt16(cmd.ExecuteScalar().ToString());
                    }

                    using (SqlConnection conn = new SqlConnection(db.conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS count FROM tbl_user WHERE usr_us = @usr AND usr_pass = @pas", conn);
                        cmd.Parameters.AddWithValue("@usr", txtUser.Text.Trim());
                        cmd.Parameters.AddWithValue("@pas", txtPass.Text.Trim());
                        int count = Convert.ToInt16(cmd.ExecuteScalar().ToString());
                        if (count > 0)
                        {
                            this.Close();
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username and Password");
                            PubCls.ClearTxt(txtUser, txtPass);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtUser.Text == "Username")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text != "" && txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Username";
                txtUser.ForeColor = Color.Gray;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Password";
                txtPass.ForeColor = Color.Gray;
            }
        }
    }
}
