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
    public partial class FormDrugs : Form
    {
        public FormDrugs()
        {
            InitializeComponent();
            dateTimePicker.Value = DateTime.Today.AddDays(-1);
            ShowDrugs();
        }

        private void ShowDrugs()
        {
            listViewDrugs.Items.Clear();
            foreach (Drug drug in Program.DB.Drug)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    drug.id.ToString(),
                    drug.name,
                    comboBoxType.Items[drug.type].ToString(),
                    drug.dosage,
                    drug.fabricator,
                    drug.date.ToString("dd/MM/yyyy")
                });
                item.Tag = drug;
                listViewDrugs.Items.Add(item);
            }
            listViewDrugs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxDosage.Text != "" &&
                textBoxFabricator.Text != "" && comboBoxType.SelectedItem != null)
            {
                if (dateTimePicker.Value < DateTime.Today)
                {
                    Drug drug = new Drug();
                    drug.name = textBoxName.Text;
                    drug.type = comboBoxType.SelectedIndex;
                    drug.dosage = textBoxDosage.Text;
                    drug.fabricator = textBoxFabricator.Text;
                    drug.date = dateTimePicker.Value;
                    Program.DB.Drug.Add(drug);
                    Program.DB.SaveChanges();
                    ShowDrugs();
                }
                else
                {
                    MessageBox.Show("Дата производства больше текущей даты!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDrugs.SelectedItems.Count == 1)
            {
                if (textBoxName.Text != "" && textBoxDosage.Text != "" &&
                    textBoxFabricator.Text != "" && comboBoxType.SelectedItem != null)
                {
                    if (dateTimePicker.Value < DateTime.Today)
                    {
                        Drug drug = listViewDrugs.SelectedItems[0].Tag as Drug;
                        drug.name = textBoxName.Text;
                        drug.type = comboBoxType.SelectedIndex;
                        drug.dosage = textBoxDosage.Text;
                        drug.fabricator = textBoxFabricator.Text;
                        drug.date = dateTimePicker.Value;
                        Program.DB.SaveChanges();
                        ShowDrugs();
                    }
                    else
                    {
                        MessageBox.Show("Дата производства больше текущей даты!", 
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            if (listViewDrugs.SelectedItems.Count == 1)
            {
                try
                {
                    Drug drug = listViewDrugs.SelectedItems[0].Tag as Drug;
                    Program.DB.Drug.Remove(drug);
                    Program.DB.SaveChanges();
                    ShowDrugs();

                    textBoxName.Text = "";
                    textBoxDosage.Text = "";
                    textBoxFabricator.Text = "";
                    comboBoxType.SelectedIndex = -1;
                    dateTimePicker.Value = DateTime.Today.AddDays(-1);
                    listBoxPharms.Items.Clear();
                    textBoxTotal.Text = "";
                    textBoxMidPrice.Text = "";
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, возможно она используется!", 
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void listViewDrugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDrugs.SelectedItems.Count == 1)
            {
                Drug drug = listViewDrugs.SelectedItems[0].Tag as Drug;
                textBoxName.Text = drug.name;
                textBoxDosage.Text = drug.dosage;
                textBoxFabricator.Text = drug.fabricator;
                comboBoxType.SelectedIndex = drug.type;
                dateTimePicker.Value = drug.date;

                listBoxPharms.Items.Clear();
                textBoxTotal.Text = "";
                textBoxMidPrice.Text = "";
                List<Availability> avails = new List<Availability>();
                foreach (Availability avail in Program.DB.Availability)
                {
                    if (avail.drugID == drug.id)
                    {
                        avails.Add(avail);
                    }
                }
                if (avails.Count > 0)
                {
                    int total = 0;
                    double price = 0;
                    foreach (Availability avail in avails)
                    {
                        listBoxPharms.Items.Add(
                            $"{avail.Pharmacy.name}({avail.Pharmacy.address})"
                        );
                        total += avail.count;
                        price += avail.price;
                    }
                    textBoxTotal.Text = total.ToString();
                    textBoxMidPrice.Text = (price / avails.Count).ToString("0.00");
                }
            }
        }
    }
}
