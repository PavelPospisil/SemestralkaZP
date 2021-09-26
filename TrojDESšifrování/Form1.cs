using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TripleDES_File_Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Filter = "All Files|*";
            OD.FileName = "";
            if (OD.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = OD.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            try
            {
                progressBar1.Value = 25;
                TripleDES tDES = new TripleDES(textBox2.Text);
                progressBar1.Value = 50;
                tDES.EncryptFile(textBox1.Text);
                progressBar1.Value = 75;
                GC.Collect();
                string message = "Soubor byl zašifrován";
                progressBar1.Value = 100;
                if (progressBar1.Value == 100)
                {
                    MessageBox.Show(message);
                }
            }
            catch
            {
                progressBar1.Value = 0;
                string message = "Něco se pokazilo. Překontrolujte heslo a vybraný soubor.";
                MessageBox.Show(message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            try
            {
                progressBar1.Value = 25;
                TripleDES tDES = new TripleDES(textBox2.Text);
                progressBar1.Value = 50;
                tDES.DecryptFile(textBox1.Text);
                progressBar1.Value = 75;
                GC.Collect();
                string message = "Soubor byl dešifrován";
                progressBar1.Value = 100;
                if (progressBar1.Value == 100)
                {
                    MessageBox.Show(message);
                }
                
            }
            catch
            {
                progressBar1.Value = 0;
                string message = "Něco se pokazilo. Překontrolujte heslo a vybraný soubor.";
                MessageBox.Show(message);
            }
        }
    }
}
