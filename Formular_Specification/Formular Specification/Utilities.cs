using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Utilities
    {
        public static string generateCSCode(string specificationSource)
        {
            //logic
            return specificationSource;
        }
        public static string generateVBCode(string specificationSource)
        {
            //logic
            return specificationSource;
        }
        public static string getFileNameWithoutExtension(string fileName)
        {
            string[] splitedFileName = fileName.Split('.');
            return splitedFileName[0];
        }
        public static void writeContentToSave(string fullPath, string content)
        {
            File.WriteAllText(fullPath, content);
        }
        public static void createAFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))  // if it doesn't exist, create
                    Directory.CreateDirectory(path);
            }
            catch 
            {
                MessageBox.Show("Please generate code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }          
        }
    }
}
