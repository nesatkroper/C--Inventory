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
    public partial class AppName : Form
    {
        public AppName()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(db.conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO app (name) VALUES({txtName.Text})", conn);
                cmd.ExecuteNonQuery();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
