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
        public static string TEMP_EXECUTE_FILE_NAME = "NewSpecificationFile";
        public static string DEFAULT_NEW_NAME_FILE = "NewSpecificationFile";
        public static string DEFAUTL_NEW_GENERATED_FOLDER = "Generated";
        public static string DEFAULT_SLASH = "\\";
        public static string EXTENSION_CS_FILE = ".cs";
        public static string EXTENSION_VB_FILE = ".vb";
        public static string EXTENSION_TXT_FILE = ".txt";
        public static string EXTENSION_EXE_FILE = ".exe";

        public string sourcePath = String.Empty;

        private Stack<string> _editingHistory = new Stack<string>();

        private Stack<string> _undoHistory = new Stack<string>();

        public string openedSourcePath = "";
        public string openedSourceName = "";
        public string savedPath = "";
        public string generatedCSContent = "";
        public string generatedVBContent = "";
        public string generatedCSContentColored = "";
        public string generatedVBContentColored = "";
        public string compileExeFileAddress = "";
        public string defaultClassName = "Program";
        public Form1()
        {
            InitializeComponent();

            _editingHistory.Push(tbSource.Text);
            toolStripBtnRedo.Enabled = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
           startProject(compileExeFileAddress);
        }
        private string compileProject()
        {
            if (tbGeneratedCode.Text == "")
            {
                MessageBox.Show("Please generate code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception();
            }
            else
            {
                string outputAddress = (tbOutputName.Text == "" ? TEMP_EXECUTE_FILE_NAME : tbOutputName.Text) + "." + EXTENSION_COMPILE_NAME;
                tbStatus.Clear();
                CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>()
                { { "CompilerVersion", FRAME_WORK_VERSION } });
                CompilerParameters parameters = new CompilerParameters();
                parameters.OutputAssembly = outputAddress;
                parameters.GenerateExecutable = true;
                CompilerResults results = csc.CompileAssemblyFromSource(parameters, generatedCSContentColored);
                if (results.Errors.HasErrors)
                {
                    results.Errors.Cast<CompilerError>().ToList().ForEach(
                        error => tbStatus.Text += error.ErrorText + "\r\n");
                    throw new Exception();
                }
                else
                {
                    tbStatus.Text = "-----Build Succeeded-----";

                }
                return outputAddress;
            }

        }
        private void startProject(string outputAddress)
        {
            Process.Start(outputAddress);
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
                try
                {
                    ChangeColor();
                    compileExeFileAddress = compileProject();
                } catch (Exception ex)
                {
                    MessageBox.Show("Syntax error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbGeneratedCode.Text = "";
                    tbStatus.Text = "";
                }
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
            string oldGenaratePath = "";
            btnGenerate_Click(btnGenerate, new EventArgs());
            if (compileExeFileAddress == "")
            {
                return;
            }
            if (/*savedPath == ""*/true)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save files";
                //saveFileDialog.DefaultExt = "txt";
                //saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = tbOutputName.Text == "" ? DEFAULT_NEW_NAME_FILE : tbOutputName.Text;
                // Set validate names and check file exists to false otherwise windows will
                // not let you select "Folder Selection."
                // Always default to Folder Selection.
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(saveFileDialog.FileName);
                    string path = Path.GetDirectoryName(saveFileDialog.FileName); // get path of new specification file
                    string generatedPathFolder = path + DEFAULT_SLASH /*+ DEFAUTL_NEW_GENERATED_FOLDER*/ + fileName;
                    string generatedCSFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName) 
                        + EXTENSION_CS_FILE; // set full path for generated CS file
                    string generatedVBFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName)
                       + EXTENSION_VB_FILE; // set full path for generated CS file
                    string generatedTXTFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName)
                       + EXTENSION_TXT_FILE; // set full path for generated CS file
                    string generatedEXEFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(fileName)
                       + EXTENSION_EXE_FILE; // set full path for generated CS file

                    //write content
                    Utilities.createAFolder(generatedPathFolder); //create a folder for generated file
                    Utilities.writeContentToSave(generatedTXTFullPath, tbSource.Text);
                    Utilities.writeContentToSave(generatedCSFullPath, generatedCSContentColored);
                    Utilities.writeContentToSave(generatedVBFullPath, generatedVBContentColored);
                    Utilities.copyFile(compileExeFileAddress, generatedEXEFullPath);

                    MessageBox.Show("Save completed", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbOutputName.Text = fileName;
                    savedPath = path;
                    oldGenaratePath = generatedPathFolder;
                }
            }
            //else
            //{
            //    if (oldGenaratePath != "")
            //        Utilities.deleteFolder(oldGenaratePath);
            //    string generatedPathFolder = savedPath + DEFAULT_SLASH + tbOutputName.Text;
            //    string generatedCSFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(tbOutputName.Text)
            //        + EXTENSION_CS_FILE; // set full path for generated CS file
            //    string generatedVBFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(tbOutputName.Text)
            //       + EXTENSION_VB_FILE; // set full path for generated CS file
            //    string generatedTXTFullPath = generatedPathFolder + DEFAULT_SLASH + Utilities.getFileNameWithoutExtension(tbOutputName.Text)
            //           + EXTENSION_TXT_FILE; // set full path for generated CS file

            //    //write content
            //    Utilities.createAFolder(generatedPathFolder);
            //    Utilities.writeContentToSave(generatedTXTFullPath, tbSource.Text);
            //    Utilities.writeContentToSave(generatedCSFullPath, generatedCSContentColored);
            //    Utilities.writeContentToSave(generatedVBFullPath, generatedVBContentColored);

            //    MessageBox.Show("Save completed", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
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

        private void toolStripBtnCopy_Click(object sender, EventArgs e)
        {
            if (tbSource.SelectionLength > 0) tbSource.Copy();
        }

        private void toolStripBtnCut_Click(object sender, EventArgs e)
        {
            if (tbSource.SelectedText != "") tbSource.Cut();
        }

        private void toolStripBtnParse_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (tbSource.SelectionLength > 0)
                {
                    tbSource.SelectionStart = tbSource.SelectionStart + tbSource.SelectionLength;
                }
                tbSource.Paste();
            }
        }

        private void toolStripBtnUndo_Click(object sender, EventArgs e)
        {
            _undoHistory.Push(_editingHistory.Pop());
            toolStripBtnRedo.Enabled = true;
            tbSource.Text = _editingHistory.Peek();
            toolStripBtnUndo.Enabled = _editingHistory.Count > 1;
        }

        private void toolStripBtnRedo_Click(object sender, EventArgs e)
        {
            _editingHistory.Push(_undoHistory.Pop());
            toolStripBtnRedo.Enabled = _undoHistory.Count > 0;
            tbSource.Text = _editingHistory.Peek();
            toolStripBtnUndo.Enabled = true;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbSource.SelectionLength > 0) tbSource.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbSource.SelectedText != "") tbSource.Cut();
        }

        private void parseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (tbSource.SelectionLength > 0)
                {
                    tbSource.SelectionStart = tbSource.SelectionStart + tbSource.SelectionLength;
                }
                tbSource.Paste();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _undoHistory.Push(_editingHistory.Pop());
            toolStripBtnRedo.Enabled = true;
            tbSource.Text = _editingHistory.Peek();
            toolStripBtnUndo.Enabled = _editingHistory.Count > 1;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _editingHistory.Push(_undoHistory.Pop());
            toolStripBtnRedo.Enabled = _undoHistory.Count > 0;
            tbSource.Text = _editingHistory.Peek();
            toolStripBtnUndo.Enabled = true;
        }

        private void tbSource_TextChanged(object sender, EventArgs e)
        {
            if (tbSource.Text != _editingHistory.Peek())
            {
                RecordEdit();
            }
        }

        private void RecordEdit()
        {
            _editingHistory.Push(tbSource.Text);
            toolStripBtnUndo.Enabled = true;
            _undoHistory.Clear();
            toolStripBtnRedo.Enabled = false;
        }

        #region Change text color
        void ChangeColor()
        {
            Utilities.className = tbClassName.Text == "" ? defaultClassName : tbClassName.Text;
            UtilitiesVB.className = tbClassName.Text == "" ? defaultClassName : tbClassName.Text;
            generatedCSContent = Utilities.generateCSCode(tbSource.Text);
            generatedVBContent = Utilities.generateVBCode(tbSource.Text);

            string temp = radioCS.Checked ? generatedCSContent : generatedVBContent;
            string[] temps = temp.Split(new char[] { '~' });

            if (radioCS.Checked == true)
            {
                // C#
                foreach (var split in temps)
                {
                    if (split.Contains("Console") || split.Contains(Utilities.className) ||
                        split.Contains("Exception"))
                        tbGeneratedCode.SelectionColor = Color.Green;
                    else if (split.Contains("return") || split.Contains("for") ||
                        split.Contains("if") || split.Contains("else") ||
                        split.Contains("continue") || split.Contains("goto"))
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
                        split.Contains("Main") || split.Contains("Parse"))
                        tbGeneratedCode.SelectionColor = Color.Yellow;
                    else tbGeneratedCode.SelectionColor = Color.White;
                    tbGeneratedCode.AppendText(split);
                }
            }
            else
            {
                // VB
                foreach (var split in temps)
                {
                    if (split.Contains("Imports") || split.Contains("Namespace") ||
                        split.Contains("Public") || split.Contains("Class") ||
                        split.Contains("Sub") || split.Contains("Function") ||
                        split.Contains("End Sub") || split.Contains("End Function") ||
                        split.Contains("End Class") || split.Contains("End Namespace") ||
                        split.Contains("True") || split.Contains("False") ||
                        split.Contains("ByRef") || split.Contains("ByVal") ||
                        split.Contains("Single") || split.Contains("Integer") ||
                        split.Contains("String") || split.Contains("Boolean") ||
                        split.Contains("Dim") || split.Contains("Shared") ||
                        split.Contains("AndAlso") || split.Contains("Throw") ||
                        split.Contains("New") || split.Contains("As") ||
                        split.Contains("Not") || split.Contains("GoTo"))
                        tbGeneratedCode.SelectionColor = Color.Blue;
                    else if (split.Contains("Return") || split.Contains("For") ||
                        split.Contains("If") || split.Contains("Else") ||
                        split.Contains("End If") || split.Contains("Next") ||
                        split.Contains("To") ||
                        split.Contains("Continue") || split.Contains("Then"))
                        tbGeneratedCode.SelectionColor = Color.Pink;
                    else if (split.Contains("Nhap_") || split.Contains("Xuat_") ||
                        split.Contains("KiemTra_") || split.Contains("XuLy_") ||
                        split.Contains("WriteLine") || split.Contains("ReadLine") ||
                        split.Contains("Main") || split.Contains("Parse"))
                        tbGeneratedCode.SelectionColor = Color.Yellow;
                    else if (split.Contains("\""))
                        tbGeneratedCode.SelectionColor = Color.Orange;
                    else if (split.Contains("Console") || split.Contains(UtilitiesVB.className) ||
                        split.Contains("Exception"))
                        tbGeneratedCode.SelectionColor = Color.Green;
                    else tbGeneratedCode.SelectionColor = Color.White;
                    tbGeneratedCode.AppendText(split);
                }
            }

            #region C# fixed
            string temp2 = generatedCSContent;
            string[] temps2 = temp2.Split(new char[] { '~' });
            generatedCSContentColored = "";
            foreach (var split in temps2)
            {
                generatedCSContentColored += split;
            }

            temp2 = generatedVBContent;
            temps2 = temp2.Split(new char[] { '~' });
            generatedVBContentColored = "";
            foreach (var split in temps2)
            {
                generatedVBContentColored += split;
            }

            #endregion
        }
        #endregion
    }
}
