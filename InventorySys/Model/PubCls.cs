using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySys.Model
{
    public class PubCls
    {
        public static bool Validation(TextBox txt_1, TextBox txt_2)
        {
            bool result = false;
            if (txt_1.Text != "" && txt_2.Text != "")
                result = true;
            else
                MessageBox.Show($"{txt_1.Name} is blank or {txt_2.Name} is blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return result;
        }

        public static bool Validation(TextBox txt_1, TextBox txt_2, TextBox txt_3)
        {
            bool result = false;
            if (txt_1.Text != "" && txt_2.Text != "" && txt_3.Text != "")
                result = true;
            else
                MessageBox.Show($"{txt_1.Name} is blank or {txt_2.Name} is blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return result;
        }


        public static Image CheckImg(string imgLocat = "0")
        {
            FileStream stream;
            MemoryStream photoStm = new MemoryStream();

            if (imgLocat != "0")
                stream = new FileStream(imgLocat, FileMode.Open);
            else
                stream = new FileStream(Path.Combine(Application.StartupPath, "DefaultImg", "default.png"), FileMode.Open);

            stream.CopyTo(photoStm);
            stream.Close();

            return Image.FromStream(photoStm);
        }


        public static void ClearTxt(TextBox txt_1)
        {
            TextBox[] txt = { txt_1 };
            foreach (TextBox b in txt)
                b.Clear();
        }
        public static void ClearTxt(TextBox txt_1, TextBox txt_2)
        {
            TextBox[] txt = { txt_1, txt_2 };
            foreach (TextBox b in txt)
                b.Clear();
        }
        public static void ClearTxt(TextBox txt_1, TextBox txt_2, TextBox txt_3)
        {
            TextBox[] txt = { txt_1, txt_2, txt_3 };
            foreach (TextBox b in txt)
                b.Clear();
        }


        public static string CheckName(string table_app, string constr)
        {
            string name = "";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT ISNULL(name, 0) AS name FROM {table_app}", conn);
                name = cmd.ExecuteScalar().ToString();
            }
            return name;
        }
    }
}
