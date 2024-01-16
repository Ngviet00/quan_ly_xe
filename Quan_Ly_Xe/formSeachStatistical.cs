using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Xe
{
    public partial class formSeachStatistical : Form
    {
        public formSeachStatistical()
        {
            InitializeComponent();
        }

        private void formSeachStatistical_Load(object sender, EventArgs e)
        {
            configTimeCombobox();
        }

        private void btnSearchStatiscal_Click(object sender, EventArgs e)
        {

        }

        private void configTimeCombobox()
        {
            string currentDay = DateTime.Now.ToString("dd");
            string currentMonth = DateTime.Now.ToString("MM");
            string currentYear = DateTime.Now.ToString("yyyy");

            int temp = 0;

            for (int i = 1; i <= 31; i++)
            {
                string j = i < 10 ? "0" + i.ToString() : i.ToString();
                cbxDay1.Items.Add(j);
                cbxDay2.Items.Add(j);
                cbxDay3.Items.Add(j);

                if (currentDay == j)
                {
                    temp = i - 1;
                }
            }

            cbxDay1.SelectedIndex = temp;
            cbxDay2.SelectedIndex = temp;
            cbxDay3.SelectedIndex = temp;


            for (int i = 1; i <= 12; i++)
            {
                string j = i < 10 ? "0" + i.ToString() : i.ToString();
                cbxMonth1.Items.Add(j);
                cbxMonth2.Items.Add(j);
                cbxMonth3.Items.Add(j);

                if (currentMonth == j)
                {
                    temp = i - 1;
                }
            }

            cbxMonth1.SelectedIndex = temp;
            cbxMonth2.SelectedIndex = temp;
            cbxMonth3.SelectedIndex = temp;

            //get current year
            for (int i = 2010; i <= int.Parse(currentYear); i++)
            {
                cbxYear1.Items.Add(i.ToString());
                cbxYear2.Items.Add(i.ToString());
                cbxYear3.Items.Add(i.ToString());

                if (currentYear == i.ToString())
                {
                    cbxYear1.Text = i.ToString();
                    cbxYear2.Text = i.ToString();
                    cbxYear3.Text = i.ToString();
                }
            }
        }

        private void cbFindByLicensePlates_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFindByLicensePlates.Checked)
            {
                txtSearchLicensePlate.ReadOnly = false;
            } else
            {
                txtSearchLicensePlate.ReadOnly = true;
                txtSearchLicensePlate.Text = string.Empty;
            }
        }

        private void cbFindBySeller_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFindBySeller.Checked)
            {
                txtSeller.ReadOnly = false;
            }
            else
            {
                txtSeller.ReadOnly = true;
                txtSeller.Text = string.Empty;
            }
        }

        private void cbFindByBuyer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFindByBuyer.Checked)
            {
                txtBuyer.ReadOnly = false;
            }
            else
            {
                txtBuyer.ReadOnly = true;
                txtBuyer.Text = string.Empty;
            }
        }

        private void cbFindByItem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFindByItem.Checked)
            {
                txtItem.ReadOnly = false;
            }
            else
            {
                txtItem.ReadOnly = true;
                txtItem.Text = string.Empty;
            }
        }
    }
}
