using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Xe
{
    public class Database
    {
        public SqlConnection cnn;

        public string connectionString = @"Data Source = ADMIN\SQLEXPRESS; Initial Catalog = INSTOP; Integrated Security = True; Encrypt = False";

        public void connectDB()
        {
            cnn = new SqlConnection(connectionString);

            try
            {
                if (cnn != null && cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool insert(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        public DataTable getAll(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return dt;
        }

        public bool update(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        public bool delete(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }
    }
}
