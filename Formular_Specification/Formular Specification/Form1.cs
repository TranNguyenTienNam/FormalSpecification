using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tbStatus.Clear();
            CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>()
            { { "CompilerVersion", tbFramework.Text } });
            CompilerParameters parameters = new CompilerParameters();
            parameters.OutputAssembly = "test.exe";
            parameters.GenerateExecutable = true;
            CompilerResults results = csc.CompileAssemblyFromSource(parameters, tbSource.Text);
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

        private void exiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
