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

namespace Classwork_18_02_2022
{
    public partial class Add_Human : Form
    {
        public string filename = "";
        public bool IsFileChanged;
        public Add_Human()
        {
            InitializeComponent();
        }

        public void Save(string _filename)
        {

            if (_filename == "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _filename = sfd.FileName;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(_filename);
                sw.Write(textBox_name.Text + ' ' + textBox_age.Text + ' ' + textBox_description.Text + '\n');
                sw.Close();
                filename = _filename;
                IsFileChanged = false;

            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(filename != "")
            {
                Save(filename);
            }
            else 
            {
                MessageBox.Show("Не удалось сохранить файл");
            }
        }

        private void button_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
        }
    }
}
