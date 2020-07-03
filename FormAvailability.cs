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
    public partial class FormAvailability : Form
    {
        public FormAvailability()
        {
            InitializeComponent();
            ShowDrugs();
            ShowPharms();
            ShowAvalibility();
        }

        private void ShowAvalibility()
        {
            listViewAval.Items.Clear();
            foreach (Availability avail in Program.DB.Availability)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    avail.id.ToString(),
                    $"{avail.Drug.name}({avail.Drug.fabricator})",
                    $"{avail.Pharmacy.name}({avail.Pharmacy.address})",
                    avail.count.ToString(),
                    avail.price.ToString()
                });
                item.Tag = avail;
                listViewAval.Items.Add(item);
            }
            listViewAval.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void ShowDrugs()
        {
            foreach (Drug drug in Program.DB.Drug)
            {
                string item = $"{drug.id}. {drug.name}({drug.fabricator})";
                comboBoxDrugs.Items.Add(item);
            }
        }
        private void ShowPharms()
        {
            foreach (Pharmacy pharmacy in Program.DB.Pharmacy)
            {
                string item = $"{pharmacy.id}. {pharmacy.name}({pharmacy.address})";
                comboBoxPharms.Items.Add(item);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxDrugs.SelectedItem != null &&
                comboBoxPharms.SelectedItem != null &&
                numericUpDownPrice.Value != 0)
            {
                Availability avail = new Availability();
                avail.drugID = Convert.ToInt32(comboBoxDrugs.SelectedItem
                    .ToString().Split('.')[0]);
                avail.pharID = Convert.ToInt32(comboBoxPharms.SelectedItem
                    .ToString().Split('.')[0]);
                avail.count = Convert.ToInt32(numericUpDownCount.Value);
                avail.price = Convert.ToDouble(numericUpDownPrice.Value);
                Program.DB.Availability.Add(avail);
                Program.DB.SaveChanges();
                ShowAvalibility();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewAval.SelectedItems.Count == 1)
            {
                if (comboBoxDrugs.SelectedItem != null &&
                    comboBoxPharms.SelectedItem != null &&
                    numericUpDownPrice.Value != 0)
                {
                    Availability avail = listViewAval.SelectedItems[0].Tag as Availability;
                    avail.drugID = Convert.ToInt32(comboBoxDrugs.SelectedItem
                        .ToString().Split('.')[0]);
                    avail.pharID = Convert.ToInt32(comboBoxPharms.SelectedItem
                        .ToString().Split('.')[0]);
                    avail.count = Convert.ToInt32(numericUpDownCount.Value);
                    avail.price = Convert.ToDouble(numericUpDownPrice.Value);
                    Program.DB.SaveChanges();
                    ShowAvalibility();
                }
                else
                {
                    MessageBox.Show("Заполните все поля!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (listViewAval.SelectedItems.Count == 1)
            {
                try
                {
                    Availability avail = listViewAval.SelectedItems[0].Tag as Availability;
                    Program.DB.Availability.Remove(avail);
                    Program.DB.SaveChanges();
                    ShowAvalibility();

                    comboBoxDrugs.SelectedIndex = -1;
                    comboBoxPharms.SelectedIndex = -1;
                    numericUpDownCount.Value = 0;
                    numericUpDownPrice.Value = 0;
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, возможно она используется!",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void listViewAval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAval.SelectedItems.Count == 1)
            {
                Availability avail = listViewAval.SelectedItems[0].Tag as Availability;
                comboBoxDrugs.SelectedIndex = comboBoxDrugs
                    .FindString(avail.drugID.ToString());
                comboBoxPharms.SelectedIndex = comboBoxPharms
                    .FindString(avail.pharID.ToString());
                numericUpDownCount.Value = avail.count;
                numericUpDownPrice.Value = Convert.ToDecimal(avail.price);
            }
        }
    }
}
