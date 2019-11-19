using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicWowCharacterManager
{
    public partial class AddNew : Form
    {
        public string Type { get; set; }
        public string ElementName { get; set; }
        public string Description { get; set; }
        public AddNew()
        {
            InitializeComponent();
            FillTypes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Type = cbType.SelectedItem.ToString();
            ElementName = txtName.Text;
            Description = txtDescription.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FillTypes()
        {
            cbType.Items.Add("Rank");
            cbType.Items.Add("Raid Role");
            cbType.Items.Add("Raid Group");
            cbType.Items.Add("Item Type");
            cbType.Items.Add("Item Rarity");
            cbType.Items.Add("Profession");
            cbType.SelectedIndex = 0;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedItem.ToString() == "Raid Role" || cbType.SelectedItem.ToString() == "Rank")
            {
                txtDescription.Enabled = true;
            }
            else
            {
                txtDescription.Text = "";
                txtDescription.Enabled = false;
            }
                
        }
    }
}
