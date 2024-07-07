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
    public partial class EditProduct : Form
    {
        public EditProduct()
        {
            InitializeComponent();
        }

        NunCMD com = new NunCMD(db.conStr);
        public string pro_id { get; set; }
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

            using (SqlConnection conn = new SqlConnection(db.conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM tbl_product WHERE pro_id = {pro_id}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    img = reader[1].ToString();
                    pcbItem.Image = PubCls.CheckImg(reader[1].ToString());
                    txtName.Text = reader[2].ToString();
                    txtPrice.Text = reader[6].ToString();
                    cbCategory.SelectedValue = reader[3].ToString();
                    cbBrand.SelectedValue = reader[4].ToString();
                    cbStatus.SelectedValue = reader[7].ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (!isSuccess)
            {
                using (SqlConnection conn = new SqlConnection(db.conStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tbl_product SET pro_photo = @pho, pro_name = @nam, cat_id = @cat, bra_id = @bra, pro_price = @pri, pro_status = @sta WHERE pro_id = @id", conn);
                    cmd.Parameters.AddWithValue("@pho", img);
                    cmd.Parameters.AddWithValue("@nam", txtName.Text);
                    cmd.Parameters.AddWithValue("@cat", cbCategory.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@bra", cbBrand.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@pri", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@sta", cbStatus.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@id", pro_id);
                    cmd.ExecuteNonQuery();
                    isSuccess = true;
                    DialogResult = DialogResult.OK;
                }
            }
            else
                File.Delete(img);
            this.Close();
        }

        private void pcbItem_Click(object sender, EventArgs e)
        {
            img = com.BrowseImage_Location();
            pcbItem.Image = PubCls.CheckImg(img);
            img = com.CopyImage_ToDestination(imgDir, img);
        }
    }
}
