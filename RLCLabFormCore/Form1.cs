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
using ClassLibraryForRefactoring;
using Newtonsoft.Json;


namespace RLCLabFormCore
{
    public partial class Form1 : Form
    {
        public FileStream Configsfs;
        public FileStream Billfs;
        public string formatinput;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Config files (*.json)|*.json";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            Configsfs = new FileStream(filename, FileMode.Open);
            /*Configsreader = new StreamReader(Configsfs);
            Configsfs.Close();*/
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("STRATEGY", this);
            form2.Show();
        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("BILL", this);
            form2.Show();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (Configsfs == null || Billfs == null) { MessageBox.Show("Выберите или создайте стратегию или чек!"); return; }
            var Billreader = new StreamReader(Billfs);
            var Configsreader = new StreamReader(Configsfs);
            AllConfigs someconfigs = JsonConvert.DeserializeObject<AllConfigs>(Configsreader.ReadToEnd());
            FileSourceFactory sourceFactory = new FileSourceFactory();
            BillFactory billFactory = new BillFactory(sourceFactory.Create(formatinput.ToUpper(), someconfigs));
            var b = billFactory.CreateBill(Billreader);
            var result = "";
            if(comboBox1.SelectedIndex == 0) result = new BillGenerator(new TxtView(), b).GetBill().Replace("\n", "\r\n");
            if (comboBox1.SelectedIndex == 1) result = new BillGenerator(new HtmlView(), b).GetBill().Replace("\n", "\r\n");
            resultTextBox.Text = result;
            Configsreader = null;
            Billreader = null;
            Configsfs.Close();
            Billfs.Close();
            Configsfs = null;
            Billfs = null;
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Config files (*.yaml;*.txt)|*.yaml;*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            if (filename.Split('.')[1].Contains("yaml")) formatinput = "yaml";
            if (filename.Split('.')[1].Contains("txt")) formatinput = "txt";
            Billfs = new FileStream(filename, FileMode.Open);
            /*Billreader = new StreamReader(Billfs);
            Billfs.Close();*/
        }
    }
}
