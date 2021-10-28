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
        static string VM_SYNTAX = "VM";
        static string TT_SYNTAX = "TT";
        #region hight-level generate function 
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
        #endregion
        #region file helper
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
        #endregion
        #region sub-handler
        public static List<string> splitInputToThreePart(string input)
        {
            input = input.Trim();
            int bodyIndexStart = input.IndexOf("pre");
            int tailIndexStart = input.IndexOf("post");

            string head = input.Substring(0, bodyIndexStart);
            string body = input.Substring(bodyIndexStart, tailIndexStart - bodyIndexStart);
            string tail = input.Substring(tailIndexStart, input.Length - tailIndexStart);

            List<string> result = new List<string>();
            result.Add(head);
            result.Add(body);
            result.Add(tail);

            return result;
        }

        public static string findIndexRepresent(string input)
        {
            string result = "";



            return result;
        }
        public static string removeOpenAndCloseBoundBrackets(string input)
        {
            int firstOpenRoundBracket = input.IndexOf("(");
            int lastCloseRoundBracket = input.LastIndexOf(")");

            string importantContent = input.Substring(firstOpenRoundBracket + 1, lastCloseRoundBracket - firstOpenRoundBracket - 1);
            return importantContent;
        }
        #endregion
        #region router 
        public static string handlePost(string post)
        {
            string result = "";

            post = removeOpenAndCloseBoundBrackets(post);

            int firstIndexVM = post.IndexOf(VM_SYNTAX);
            int lastIndexVM = post.LastIndexOf(VM_SYNTAX);

            int firstIndexTT = post.IndexOf(TT_SYNTAX);
            int lastIndexTT = post.LastIndexOf(TT_SYNTAX);

            string indexRepresent;
            string arrayRepresent;
            string startIndexofIteration;
            string endIndexOfIteration;

            if (firstIndexVM == -1 && firstIndexTT == -1) // no VM and no TT
            {
                result = handleBasicType(post);
            } else if (firstIndexVM != -1) // VM
            {
                if (firstIndexVM == lastIndexVM) // one VM
                {
                    if (firstIndexTT != -1 && firstIndexVM < firstIndexTT) // one VM and one TT
                    {
                        result = handleVMIteration(handleTTIteration(post));
                    } else // only one VM
                    {
                        result = handleVMIteration(post);
                    }
                } else // two VMs
                {
                    result = handleVMIteration(handleVMIteration(post));
                }
            } else if (firstIndexTT != -1) // TT
            {
                if (firstIndexTT == lastIndexTT) // one TT
                {
                    if (firstIndexVM != -1 && firstIndexTT < firstIndexVM) // one TT and one VM
                    {
                        result = handleTTIteration(handleVMIteration(post));
                    } else // only one TT
                    {
                        result = handleTTIteration(post);
                    }
                } else // two TTs
                {
                    result = handleTTIteration(handleTTIteration(post));
                }
            }

            
            
            
            return result;
        }
        #endregion
        #region Handler Genarate Iteration
        public static string handleBasicType(string input)
        {
            return "abc";
        }
        public static string handleVMIteration(string input)
        {
            return input;
        }
        public static string handleTTIteration(string input)
        {
            return "for (int i = 0; i<= n-1; i++)";
        }
        #endregion
    }
}
