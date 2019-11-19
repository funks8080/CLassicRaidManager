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
    public partial class Notes : Form
    {
        public string MemberNotes { get; set; }
        public Notes(string note)
        {
            InitializeComponent();
            MemberNotes = note;
            txtNotes.Text = MemberNotes;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MemberNotes = txtNotes.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
