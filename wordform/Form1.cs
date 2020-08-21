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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private static List<string> LoadWordsList()
        {
            List<string> ValidWords = new List<string>();

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\words.txt");
            foreach (var w in File.ReadAllLines(path))
            {
                ValidWords.Add(w);
            }

            return ValidWords;
        }
        public static Boolean CheckWord(String input)
        {
            List<string> vwords = LoadWordsList();
            Boolean found = false;
            foreach (string word in vwords)
            {
                if (input.ToLower() == word.ToLower())
                {
                    found = true;

                }
            }
            return found;
        }


        private void Play_Click(object sender, EventArgs e)
        {
            string word = InputTextBox.Text;
            outputLabel.Text = CheckWord(word).ToString();
        }
    }
}
