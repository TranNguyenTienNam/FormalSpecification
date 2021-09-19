using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string FRAME_WORK_VERSION = "v4.0";

        public string sourcePath = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(tbGeneratedCode?.Text == "")
            {
                MessageBox.Show("Source hasn't to empty", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                tbStatus.Clear();
                CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>()
            { { "CompilerVersion", FRAME_WORK_VERSION } });
                CompilerParameters parameters = new CompilerParameters();
                parameters.OutputAssembly = "test.exe";
                parameters.GenerateExecutable = true;
                CompilerResults results = csc.CompileAssemblyFromSource(parameters, tbGeneratedCode.Text);
                if (results.Errors.HasErrors)
                {
                    results.Errors.Cast<CompilerError>().ToList().ForEach(
                        error => tbStatus.Text += error.ErrorText + "\r\n");
                }
                else
                {
                    tbStatus.Text = "-----Build Succeeded-----";
                    Process.Start(Application.StartupPath + "/" + tbOutput.Text);
                }
            }
        }

        private void exiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("abc");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileContent = String.Empty; // content of source file
            #region Init OpenDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            #endregion
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                sourcePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                tbGeneratedCode.Text = fileContent; // insert source in to editor
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
