using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace wordform
{
    public partial class client1Form : Form
    {
        public client1Form()
        {
            InitializeComponent(); 
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        private void Play_Click(object sender, EventArgs e)
        {

            string word = InputTextBox.Text; //ClientConnect(word).ToString();
            outputLabel.Text = Connection.Connect.ClientConnect(word, 1302).ToString();
        }
    }
}
