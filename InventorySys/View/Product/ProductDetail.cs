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

namespace InventorySys.View.Product
{
    public partial class ProductDetail : Form
    {
        public ProductDetail()
        {
            InitializeComponent();
        }

        public string pro_id { get; set; }

        private void ProductDetail_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(db.conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT p.pro_id, ISNULL(p.pro_photo, 0 )AS photo, p.pro_name, ISNULL(c.name, 0) AS cat, ISNULL(b.name, 0) AS bra, ISNULL(p.pro_qty, 0) AS qty, ISNULL(p.pro_price, 0) AS price, ISNULL(s.name, 0) AS status FROM tbl_product p LEFT JOIN tbl_procate c ON p.cat_id = c.id LEFT JOIN tbl_probrand b ON p.bra_id = b.id LEFT JOIN tbl_prostatus s ON p.pro_id = s.id WHERE p.pro_id = {pro_id}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pcbItem.Image = PubCls.CheckImg(reader[1].ToString());
                    lbName.Text = reader[2].ToString();
                    lbCate.Text = reader[3].ToString();
                    lbBrand.Text = reader[4].ToString();
                    lbqty.Text = reader[5].ToString() + " pcs";
                    lbPrice.Text = reader[6].ToString();
                    lbStatus.Text = reader[7].ToString();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
