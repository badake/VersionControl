using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {

        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.WriteFile;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;

                if (!fileName.EndsWith(".txt"))
                {
                    fileName = fileName + ".txt";
                }

                try
                {
                    using (TextWriter tw = new StreamWriter(fileName))
                    {
                        foreach (var u in users)
                        {
                            string row = string.Format("{0};{1}", u.ID, u.FullName);

                            tw.WriteLine(row);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Hiba történt: {0}", ex.Message), "Hiba", MessageBoxButtons.OK);
                }
            }
        }
    }
}
