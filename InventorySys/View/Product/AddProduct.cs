using InventorySys.Model;
using MiniMartSystem.DotNunServer;
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

namespace InventorySys.View.Product
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        NunCMD com = new NunCMD(db.conStr);
        private string img { get; set; }
        string imgDir = "Product Picture";

        private void AddProduct_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = com.SelectCategory("tbl_procate", "Select Category");
            cbCategory.DisplayMember = "name";
            cbCategory.ValueMember = "id";

            cbBrand.DataSource = com.SelectCategory("tbl_probrand", "Select Brand");
            cbBrand.DisplayMember = "name";
            cbBrand.ValueMember = "id";

            cbStatus.DataSource = com.SelectCategory("tbl_prostatus", "Select Status");
            cbStatus.DisplayMember = "name";
            cbStatus.ValueMember = "id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (PubCls.Validation(txtName, txtPrice))
            {
                if (!isSuccess)
                {
                    using (SqlConnection conn = new SqlConnection(db.conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO tbl_product (pro_photo, pro_name, cat_id, bra_id, pro_price, pro_status, pro_isdelete) VALUES (@pho, @nam, @cat, @bra, @pri, @sta, @del)", conn);
                        cmd.Parameters.AddWithValue("@pho", img);
                        cmd.Parameters.AddWithValue("@nam", txtName.Text);
                        cmd.Parameters.AddWithValue("@cat", cbCategory.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@bra", cbBrand.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@pri", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@sta", cbStatus.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@del", 0);
                        cmd.ExecuteNonQuery();
                        isSuccess = true;
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                    File.Delete(img);
                this.Close();
            }
        }

        private void pcbItem_Click(object sender, EventArgs e)
        {
            img = com.BrowseImage_Location();
            pcbItem.Image = PubCls.CheckImg(img);
            img = com.CopyImage_ToDestination(imgDir, img);
        }
    }
}
