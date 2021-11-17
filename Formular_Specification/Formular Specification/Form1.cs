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
        public static string EXTENSION_COMPILE_NAME = "exe";
        public static string TEMP_EXECUTE_FILE_NAME = "temp" + EXTENSION_COMPILE_NAME.ToUpper() + "File";
        public static string DEFAULT_NEW_NAME_FILE = "NewSpecificationFile";
        public static string DEFAUTL_NEW_GENERATED_FOLDER = "Generated";
        public static string DEFAULT_SLASH = "\\";
        public static string EXTENSION_CS_FILE = ".cs";
        public static string EXTENSION_VB_FILE = ".vb";

        public string openedSourcePath = "";
        public string openedSourceName = "";
        public string generatedCSContent = "";
        public string generatedVBContent = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (tbGeneratedCode.Text == "")
            {
                MessageBox.Show("Please generate code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                string outputAddress = openedSourcePath + DEFAULT_SLASH + (tbOutputName.Text == "" ? TEMP_EXECUTE_FILE_NAME:tbOutputName.Text) + "." + EXTENSION_COMPILE_NAME;
                tbStatus.Clear();
                CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>()
                { { "CompilerVersion", FRAME_WORK_VERSION } });
                CompilerParameters parameters = new CompilerParameters();
                parameters.OutputAssembly = outputAddress;
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

                }
                Process.Start(outputAddress);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(tbSource?.Text == "")
            {
                MessageBox.Show("Source hasn't to empty", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                //Generate specification to specific program language
                //generatedCSContent = Utilities.generateCSCode(tbSource.Text);
                //generatedVBContent = Utilities.generateVBCode(tbSource.Text);

                //tbGeneratedCode.Text = radioCS.Checked ? generatedCSContent : generatedVBContent;
                tbGeneratedCode.Text = "";
                ChangeColor();
            }
        }

        private void exiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newWindow = new Form1();
            newWindow.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileContent = String.Empty; // content of source file
            #region Init OpenDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select file to open";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            #endregion
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path and name of specified file
                openedSourcePath = Path.GetDirectoryName(openFileDialog.FileName);
                openedSourceName = openFileDialog.SafeFileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                tbSource.Text = fileContent; // insert source in to editor
                tbOutputName.Text = Utilities.getFileNameWithoutExtension(openedSourceName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tbGeneratedCode.Text == "")
            {
                MessageBox.Show("Please generate code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (openedSourceName == "" && openedSourcePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save text Files";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = DEFAULT_NEW_NAME_FILE;
                // Set validate names and check file exists to false otherwise windows will
                // not let you select "Folder Selection."
                // Always default to Folder Selection.
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(saveFileDialog.FileName);
                    string path = Path.GetDirectoryName(saveFileDialog.FileName); // get path of new specification file
                    string generatedPathFolder = path + DEFAULT_SLASH + DEFAUTL_NEW_GENERATED_FOLDER + fileName;
                    string generatedCSFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName) 
                        + EXTENSION_CS_FILE; // set full path for generated CS file
                    string generatedVBFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName)
                       + EXTENSION_VB_FILE; // set full path for generated CS file

                    //write content
                    Utilities.writeContentToSave(saveFileDialog.FileName, tbSource.Text);
                    Utilities.createAFolder(generatedPathFolder); //create a folder for generated file
                    Utilities.writeContentToSave(generatedCSFullPath, tbGeneratedCode.Text);
                    Utilities.writeContentToSave(generatedVBFullPath, tbGeneratedCode.Text);

                    MessageBox.Show("Save completed", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbOutputName.Text = fileName;

                }
            }
            else
            {
                string generatedPathFolder = openedSourcePath + DEFAULT_SLASH + DEFAUTL_NEW_GENERATED_FOLDER + openedSourceName;
                string generatedCSFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(openedSourceName)
                    + EXTENSION_CS_FILE; // set full path for generated CS file
                string generatedVBFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(openedSourceName)
                   + EXTENSION_VB_FILE; // set full path for generated CS file

                //write content
                Utilities.writeContentToSave(Path.Combine(openedSourcePath,openedSourceName), tbSource.Text);
                Utilities.createAFolder(generatedPathFolder);
                Utilities.writeContentToSave(generatedCSFullPath, tbGeneratedCode.Text);
                Utilities.writeContentToSave(generatedVBFullPath, tbGeneratedCode.Text);

                MessageBox.Show("Save completed", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save text Files";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = DEFAULT_NEW_NAME_FILE;
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            // Always default to Folder Selection.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(saveFileDialog.FileName);
                string path = Path.GetDirectoryName(saveFileDialog.FileName); // get path of new specification file
                string generatedPathFolder = path + DEFAULT_SLASH + DEFAUTL_NEW_GENERATED_FOLDER + fileName;
                string generatedCSFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName)
                    + EXTENSION_CS_FILE; // set full path for generated CS file
                string generatedVBFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName)
                   + EXTENSION_VB_FILE; // set full path for generated CS file

                //write content
                Utilities.writeContentToSave(saveFileDialog.FileName, tbSource.Text);
                Utilities.createAFolder(generatedPathFolder); //create a folder for generated file
                Utilities.writeContentToSave(generatedCSFullPath, tbGeneratedCode.Text);
                Utilities.writeContentToSave(generatedVBFullPath, tbGeneratedCode.Text);

                MessageBox.Show("Save completed", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbOutputName.Text = fileName;

            }
        }

        #region Change text color
        void ChangeColor()
        {
            string temp = Utilities.generateCSCode(tbSource.Text);

            string[] temps = temp.Split(new char[] { '~' });
            foreach (var split in temps)
            {
                if (split.Contains("Console") || split.Contains("Program") ||
                    split.Contains("Exception"))
                    tbGeneratedCode.SelectionColor = Color.Green;
                else if (split.Contains("return") || split.Contains("for") ||
                    split.Contains("if") || split.Contains("else") ||
                    split.Contains("continue")) 
                    tbGeneratedCode.SelectionColor = Color.Pink;
                else if (split.Contains("using") || split.Contains("namespace") ||
                    split.Contains("static") || split.Contains("new") ||
                    split.Contains("public") || split.Contains("class") ||
                    split.Contains("ref") || split.Contains("int") ||
                    split.Contains("float") || split.Contains("string") ||
                    split.Contains("bool") || split.Contains("void") ||
                    split.Contains("true") || split.Contains("false") ||
                    split.Contains("throw")) 
                    tbGeneratedCode.SelectionColor = Color.Blue;
                else if (split.Contains("\""))
                    tbGeneratedCode.SelectionColor = Color.Orange;
                else if (split.Contains("Nhap_") || split.Contains("Xuat_") ||
                    split.Contains("KiemTra_") || split.Contains("XuLy_") ||
                    split.Contains("WriteLine") || split.Contains("ReadLine") ||
                    split.Contains("Main"))
                    tbGeneratedCode.SelectionColor = Color.Yellow;
                else tbGeneratedCode.SelectionColor = Color.White;
                tbGeneratedCode.AppendText(split);
            }
        }
        #endregion
    }
}
