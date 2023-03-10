using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace compiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "c | *.c";
            DialogResult dr = op.ShowDialog();

            if(dr==DialogResult.OK)
            {
                string path = op.FileName;
                StreamReader sr = new StreamReader(path);
                string data = sr.ReadToEnd();
                richtext.Text = data;
                sr.Close();


                

                filename.Text = Path.GetFileName(path);
                directory.Text = path;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr = sfd.ShowDialog();
            if(dr==DialogResult.OK)
            {
                string path = sfd.FileName;
                File.WriteAllLines(path,richtext.Lines);
            }
           
           
        }

       

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process pcom = new Process();
            //  pcom.StartInfo.FileName = "javac";
            pcom.StartInfo.FileName = "gcc.exe";
            string path = "C:\\MinGW\\bin\\add.c";
            pcom.StartInfo.WorkingDirectory = "C:\\MinGW\\bin";
            pcom.StartInfo.Arguments = path ;   //filename.Text;

            pcom.StartInfo.CreateNoWindow = true;
            pcom.StartInfo.UseShellExecute = false;
            pcom.StartInfo.RedirectStandardError = true;
            pcom.StartInfo.RedirectStandardOutput = true;

            pcom.Start();
            pcom.WaitForExit();

            string error = pcom.StandardError.ReadToEnd();
            string output = pcom.StandardOutput.ReadToEnd();

            if (error!="")
            {
                richcompiler.Text = error;
                //MessageBox.Show("compile error");
            }
            else
            {
               richcompiler.Text = output;
                richcompiler.Text = "Compilation done";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void filename_Click(object sender, EventArgs e)
        {
            
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process pcom = new Process();
            //  pcom.StartInfo.FileName = "javac";
            pcom.StartInfo.FileName = "a.exe";
           
            pcom.StartInfo.WorkingDirectory = "C:\\MinGW\\bin";
             //filename.Text;

            pcom.StartInfo.CreateNoWindow = true;
            pcom.StartInfo.UseShellExecute = false;
            pcom.StartInfo.RedirectStandardError = true;
            pcom.StartInfo.RedirectStandardOutput = true;

            pcom.Start();
            pcom.WaitForExit();

            string error = pcom.StandardError.ReadToEnd();
            string output = pcom.StandardOutput.ReadToEnd();

            if (error != "")
            {
                richcompiler.Text = error;
                //MessageBox.Show("compile error");
            }
            else
            {
                richcompiler.Text = output;

            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path1 = "C:\\MinGW\\bin\\add.c";
            File.WriteAllLines(path1,richtext.Lines);
        }

        private void richtext_TextChanged(object sender, EventArgs e)
        {
            int c = richtext.Lines.Count();
            lines.Text = c.ToString();

        }
    }
}
