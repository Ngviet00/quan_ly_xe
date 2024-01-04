using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Xe
{
    public partial class FormManagementCar : Form
    {
        public FormManagementCar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void FormManagementCar_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát không?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                Application.Exit();
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
            save();
            refreshData();
        }

        private void save()
        {
            if (string.IsNullOrEmpty(txtLicensePlates.Text))
            {
                MessageBox.Show("Biển số xe không được để trống!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicensePlates.Focus();
            }
            else if (string.IsNullOrEmpty(txtSeller.Text))
            {
                MessageBox.Show("Người bán không được để trống!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSeller.Focus();
            }
            else if (string.IsNullOrEmpty(txtBuyer.Text))
            {
                MessageBox.Show("Người mua không được để trống!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuyer.Focus();
            }
            else if (string.IsNullOrEmpty(txtItem.Text))
            {
                MessageBox.Show("Loại hàng không được để trống!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItem.Focus();
            }
        }
    }
}
