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

namespace RLCLabFormCore
{
    public partial class Form2 : Form
    {
        string type;
        Form1 form1;
        public Form2(string type, Form1 form1)
        {
            InitializeComponent();
            this.type = type;
            this.form1 = form1;

            if (type == "STRATEGY") 
            {
                saveFileDialog1.DefaultExt = "json";
                string fileName = "StrategyCreate.txt";
                var Configsfs = new FileStream(fileName, FileMode.Open);
                TextReader Configsreader = new StreamReader(Configsfs);
                createSomeStuffTextBox.Text = Configsreader.ReadToEnd();
                Configsfs.Close();
                comboBox1.Visible = false;
            }

            if (type == "BILL")
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, createSomeStuffTextBox.Text);
            if (type == "STRATEGY") form1.Configsfs = new FileStream(filename, FileMode.Open);
            if (type == "BILL") 
            { 
                form1.Billfs = new FileStream(filename, FileMode.Open); 
                form1.formatinput = saveFileDialog1.DefaultExt;
            }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = "";
            if (comboBox1.SelectedIndex == 0) 
            {
                fileName = "BillInfoYAML.txt";
                saveFileDialog1.DefaultExt = "yaml";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                fileName = "BillInfoTXT.txt";
                saveFileDialog1.DefaultExt = "txt";
            }
            var Filefs = new FileStream(fileName, FileMode.Open);
            TextReader Filereader = new StreamReader(Filefs);
            createSomeStuffTextBox.Text = Filereader.ReadToEnd();
            Filefs.Close();
        }
    }
}
