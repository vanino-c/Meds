using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDrug_Click(object sender, EventArgs e)
        {
            FormDrugs drugs = new FormDrugs();
            drugs.ShowDialog();
        }

        private void buttonPhar_Click(object sender, EventArgs e)
        {
            FormPharmacy pharmacy = new FormPharmacy();
            pharmacy.ShowDialog();
        }

        private void buttonAval_Click(object sender, EventArgs e)
        {
            FormAvailability availability = new FormAvailability();
            availability.ShowDialog();
        }
    }
}
