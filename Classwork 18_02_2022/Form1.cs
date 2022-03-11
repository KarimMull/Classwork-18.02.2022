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
    public partial class Form1 : Form
    {
        Add_Human add_human = new Add_Human();
        public string filename_datagrid = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Web_search_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(WEBtextbox.Text);
        }

        private void button_select_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename_datagrid = ofd.FileName;
            }
        }

        private void button_open_form_Click(object sender, EventArgs e)
        {
            add_human.Show();
        }

        private void button_update_table_Click(object sender, EventArgs e)
        {
            if (filename_datagrid != "")
            {
                dataGridView1.Visible = true;
                dataGridView1.Rows.Clear();
                foreach (string line in File.ReadAllLines(filename_datagrid, Encoding.GetEncoding(1251)))
                {
                    string[] array = line.Split();
                    dataGridView1.Rows.Add(array);
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран");
            }
        }

        private void Click_tree(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (filename_datagrid != "")
            {
                dataGridView1.Visible = true;
                if (e.Node.Text.Equals("09-122"))
                {
                    dataGridView1.Rows.Clear();
                    {
                        foreach (string line in File.ReadLines(filename_datagrid, Encoding.Default))
                        {
                            string[] array = line.Split();
                            dataGridView1.Rows.Add(array);
                        }
                    }
                }
                if (e.Node.Text.Equals("09-121"))
                {
                    dataGridView1.Rows.Clear();
                    foreach (string line in File.ReadLines(filename_datagrid, Encoding.Default))
                    {
                        string[] array = line.Split();
                        dataGridView1.Rows.Add(array);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран");
            }
        }
    }
}
