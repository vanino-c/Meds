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
    public partial class FormPharmacy : Form
    {
        public FormPharmacy()
        {
            InitializeComponent();
            ShowPharms();
        }

        private void ShowPharms()
        {
            listViewPhar.Items.Clear();
            foreach (Pharmacy pharmacy in Program.DB.Pharmacy)
            {
                ListViewItem item = new ListViewItem(new string[]{ 
                    pharmacy.id.ToString(),
                    pharmacy.name,
                    pharmacy.address,
                    pharmacy.email,
                    pharmacy.number
                });
                item.Tag = pharmacy;
                listViewPhar.Items.Add(item);
            }
            listViewPhar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxAddress.Text != "" && 
                textBoxEmail.Text != "" && textBoxNumber.Text != "")
            {
                Pharmacy pharmacy = new Pharmacy();
                pharmacy.name = textBoxName.Text;
                pharmacy.address = textBoxAddress.Text;
                pharmacy.email = textBoxEmail.Text;
                pharmacy.number = textBoxNumber.Text;
                Program.DB.Pharmacy.Add(pharmacy);
                Program.DB.SaveChanges();
                ShowPharms();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewPhar.SelectedItems.Count == 1)
            {
                if (textBoxName.Text != "" && textBoxAddress.Text != "" &&
                    textBoxEmail.Text != "" && textBoxNumber.Text != "")
                {
                    Pharmacy pharmacy = listViewPhar.SelectedItems[0].Tag as Pharmacy;
                    pharmacy.name = textBoxName.Text;
                    pharmacy.address = textBoxAddress.Text;
                    pharmacy.email = textBoxEmail.Text;
                    pharmacy.number = textBoxNumber.Text;
                    Program.DB.SaveChanges();
                    ShowPharms();
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
            if (listViewPhar.SelectedItems.Count == 1)
            {
                try
                {
                    Pharmacy pharmacy = listViewPhar.SelectedItems[0].Tag as Pharmacy;
                    Program.DB.Pharmacy.Remove(pharmacy);
                    Program.DB.SaveChanges();
                    ShowPharms();

                    textBoxName.Text = "";
                    textBoxAddress.Text = "";
                    textBoxEmail.Text = "";
                    textBoxNumber.Text = "";
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, возможно она используется!", 
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void listViewPhar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPhar.SelectedItems.Count == 1)
            {
                Pharmacy pharmacy = listViewPhar.SelectedItems[0].Tag as Pharmacy;
                textBoxName.Text = pharmacy.name;
                textBoxAddress.Text = pharmacy.address;
                textBoxEmail.Text = pharmacy.email;
                textBoxNumber.Text = pharmacy.number;
            }
        }
    }
}
