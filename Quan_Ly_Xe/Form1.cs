using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Xe
{
    public partial class FormManagementCar : Form
    {
        Ticket ticket = new Ticket();

        public FormManagementCar()
        {
            InitializeComponent();
            dgvTicketMain.DataSource = ticket.GetAll();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát không?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                Application.Exit();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                try
                {
                    ticket.Id = long.Parse(txtID.Text);
                    ticket.Delete(ticket);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            txtLicensePlates.Clear();
            txtSeller.Clear();
            txtBuyer.Clear();
            txtItem.Clear();

            txtLicensePlates.Focus();
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            formSeachStatistical form = new formSeachStatistical();
            form.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            /*string sql = "INSERT INTO users (name, age, address) VALUES(N'" + txtName.Text + "', " + txtAge.Text + ", '" + txtAddress.Text + "')";

            command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();


            if (validate())
            {
                try
                {
                    db.connectDB();
                    string sql = "INSERT INTO tickets(license_plates, seller, buyer, item, total_weight, total_vehicle, total_item, status, is_deleted, created_at, updated_at)" +
                        " VALUES('" + txtLicensePlates.Text + "', '" + txtSeller.Text + "', '" + txtBuyer.Text + "', '" + txtItem.Text + "', " + int.Parse(txtTotalWeight.Text) + ", " + int.Parse(txtTotalVehicle.Text) + ", " + int.Parse(txtTotalItem.Text) + ", 1, 0, " + DateTime.Now + ", " + DateTime.Now + ");";
                    db.insert(sql.ToString());
                    refreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }*/
        }

        private bool validate()
        {
            if (string.IsNullOrEmpty(txtLicensePlates.Text))
            {
                MessageBox.Show("Biển số xe không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicensePlates.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSeller.Text))
            {
                MessageBox.Show("Người bán không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeller.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtBuyer.Text))
            {
                MessageBox.Show("Người mua không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuyer.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtItem.Text))
            {
                MessageBox.Show("Loại hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItem.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTotalWeight.Text) && string.IsNullOrEmpty(txtTotalVehicle.Text))
            {
                MessageBox.Show("Trọng lượng tổng hoặc trọng lượng bì xe không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItem.Focus();
                return false;
            }

            return true;
        }

        private void FormManagementCar_Load(object sender, EventArgs e)
        {
            
        }
    }
}
