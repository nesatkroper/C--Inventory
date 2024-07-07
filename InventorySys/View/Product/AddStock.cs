using InventorySys.Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventorySys.View.Product
{
    public partial class AddStock : Form
    {
        public AddStock()
        {
            InitializeComponent();
        }

        public string pro_id { get; set; }
        public int emp_id { get; set; }
        private int currentStock { get; set; }

        private void AddStock_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(db.conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT ISNULL(pro_photo, 0 )AS photo, pro_name, ISNULL(pro_qty, 0) AS qty FROM tbl_product WHERE pro_id = {pro_id}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pcbItems.Image = PubCls.CheckImg(reader[0].ToString());
                    lbProduct.Text = reader[1].ToString();
                    lbStock.Text = reader[2].ToString();
                    currentStock = Convert.ToInt16(reader[2].ToString());
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (PubCls.Validation(txtPrice, txtQty))
            {
                using (SqlConnection conn = new SqlConnection(db.conStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_proadd (pro_id, qty, price, date) VALUES (@id, @qty, @pri, @date)", conn);
                    cmd.Parameters.AddWithValue("@id", pro_id);
                    cmd.Parameters.AddWithValue("@qty", txtQty.Text.Trim());
                    cmd.Parameters.AddWithValue("@pri", txtPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("d"));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Success");
                }
                using (SqlConnection conn = new SqlConnection(db.conStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"UPDATE tbl_product SET pro_qty = @stock WHERE pro_id = {pro_id}", conn);
                    cmd.Parameters.AddWithValue("@stock", (currentStock + Convert.ToInt16(txtQty.Text.Trim())));
                    cmd.ExecuteNonQuery();
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
