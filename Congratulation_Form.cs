using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint_Game
{
    public partial class Congratulation_Form : Form
    {
        public Congratulation_Form()
        {
            InitializeComponent();
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void Rety_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void Congratulation_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
                DialogResult = DialogResult.Abort;
        }

        private void Congratulation_Form_Shown(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
        }
    }
}
