using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace client2
{
    public partial class client2Form : Form
    {
        public client2Form()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {

            string word = InputTextBox.Text;
            outputLabel.Text = Connection.Connect.ClientConnect(word, 1302).ToString();
        }
    }
}
