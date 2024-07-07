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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySys.View.Product
{
    public partial class ProductPage : Form
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        public int emp_id { get; set; }
        string row;

        void LoadDBData(string expression = "")
        {
            string sql = $"SELECT p.pro_id, ISNULL(p.pro_photo, 0 )AS photo, p.pro_name, ISNULL(c.name, 0) AS cat, ISNULL(b.name, 0) AS bra, ISNULL(p.pro_qty, 0) AS qty, ISNULL(p.pro_price, 0) AS price, ISNULL(p.pro_status, 0) AS status FROM tbl_product p LEFT JOIN tbl_procate c ON p.cat_id = c.id LEFT JOIN tbl_probrand b ON p.bra_id = b.id WHERE pro_isdelete < 1 AND pro_name LIKE '%{expression}%'";

            try
            {
                using (SqlConnection conn = new SqlConnection(db.conStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (cbCate.SelectedIndex > 0)
                    {
                        cmd.CommandText = $"SELECT p.pro_id, ISNULL(p.pro_photo, 0 )AS photo, p.pro_name, ISNULL(c.name, 0) AS cat, ISNULL(b.name, 0) AS bra, ISNULL(p.pro_qty, 0) AS qty, ISNULL(p.pro_price, 0) AS price, ISNULL(p.pro_status, 0) AS status FROM tbl_product p LEFT JOIN tbl_procate c ON p.cat_id = c.id LEFT JOIN tbl_probrand b ON p.bra_id = b.id WHERE pro_isdelete < 1 AND pro_name LIKE '%{expression}%' AND cat_id = @cat";
                        cmd.Parameters.AddWithValue("@cat", cbCate.SelectedValue.ToString());
                    }

                    int no = 1;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dgvPro.Rows.Clear();
                    while (reader.Read())
                    {
                        dgvPro.Rows.Add(
                            no,
                            reader[0],
                            PubCls.CheckImg(reader[1].ToString()),
                            reader[2],
                            reader[3],
                            reader[4],
                            reader[5],
                            reader[6],
                            Image.FromFile(Path.Combine(Application.StartupPath, "AppIcons", "show.png")),
                            Image.FromFile(Path.Combine(Application.StartupPath, "AppIcons", "add.png")),
                            Image.FromFile(Path.Combine(Application.StartupPath, "AppIcons", "edit.png")),
                            Image.FromFile(Path.Combine(Application.StartupPath, "AppIcons", "delete.png")));
                        no++;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ProductPage_Load(object sender, EventArgs e)
        {
            LoadDBData();
            NunCMD cmd = new NunCMD(db.conStr);
            cbCate.DataSource = cmd.SelectCategory("tbl_procate", "All Category");
            cbCate.DisplayMember = "name";
            cbCate.ValueMember = "id";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDBData(txtSearch.Text);
        }

        private void cbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            PubCls.ClearTxt(txtSearch);
            LoadDBData();
        }

        private void dgvPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NunCMD cmd = new NunCMD(db.conStr);
            if (dgvPro.Columns[e.ColumnIndex].Index == 8)
            {
                ProductDetail product = new ProductDetail();
                product.pro_id = dgvPro.Rows[Convert.ToInt16(row)].Cells[1].Value.ToString();
                product.Show();
            }

            if (dgvPro.Columns[e.ColumnIndex].Index == 9)
            {
                AddStock add = new AddStock();
                add.emp_id = this.emp_id;
                add.pro_id = dgvPro.Rows[Convert.ToInt16(row)].Cells[1].Value.ToString();
                if (add.ShowDialog() == DialogResult.OK)
                    LoadDBData();
            }

            if (dgvPro.Columns[e.ColumnIndex].Index == 10)
            {
                EditProduct edit = new EditProduct();
                edit.pro_id = dgvPro.Rows[Convert.ToInt16(row)].Cells[1].Value.ToString();
                if(edit.ShowDialog() == DialogResult.OK)
                    LoadDBData();
            }

            if (dgvPro.Columns[e.ColumnIndex].Index == 11)
            {
                if (MessageBox.Show("Are You Sure Wanna Delete This Record?", "Question...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(db.conStr))
                    {
                        conn.Open();
                        SqlCommand del = new SqlCommand("UPDATE tbl_product SET pro_isdelete = @del WHERE pro_id = @id", conn);
                        del.Parameters.AddWithValue("@del", 1);
                        del.Parameters.AddWithValue("@id", dgvPro.Rows[Convert.ToInt16(row)].Cells[1].Value.ToString());
                        del.ExecuteNonQuery();
                    }
                    LoadDBData();
                }
                else
                    return;
            }
        }

        private void dgvPro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = dgvPro.CurrentRow.Index.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct add = new AddProduct();
            if (add.ShowDialog() == DialogResult.OK)
                LoadDBData();
        }
    }
}
