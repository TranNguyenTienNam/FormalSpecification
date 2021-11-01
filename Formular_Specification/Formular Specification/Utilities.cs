using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Utilities
    {
        static string DIFFERENCE_OF_ARRAY_INDEX = "-1";
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
            string[] splitedArray = input.Split(' ');

            result = splitedArray[1];

            return result;
        }
        public static string removeOpenAndCloseBoundBrackets(string input)
        {
            int firstOpenRoundBracket = input.IndexOf("(");
            int lastCloseRoundBracket = input.LastIndexOf(")");

            string importantContent = input.Substring(firstOpenRoundBracket + 1, lastCloseRoundBracket - firstOpenRoundBracket - 1);
            return importantContent;
        }
        public static string exportExecuteLogicInIteration(string input)
        {
            return input.Replace('(', '[').Replace(')', ']');
        }
        public static string findStringOfStartAndEndIndex(string input)
        {
            int startBracketIndex = input.IndexOf('{');
            int endBracketIndex = input.IndexOf('}');
            return input.Substring(startBracketIndex + 1, endBracketIndex - startBracketIndex - 1);
        }
        public static List<string> splitInputToHeaderAndExecuteOfIteration(string input)
        {
            List<string> result = new List<string>();

            int breakPoint = findBreakPointOfHeaderAndExecuteOfIteration(input);

            result.Add(input.Substring(0, breakPoint).Trim());
            result.Add(input.Substring(breakPoint + 1, input.Length - breakPoint - 1).Trim());

            return result;
        }
        public static int findBreakPointOfHeaderAndExecuteOfIteration(string input)
        {
            int firstIndexCloseBracket = input.IndexOf("}");
            return input.Substring(firstIndexCloseBracket, input.Length - firstIndexCloseBracket).IndexOf(".") + firstIndexCloseBracket;
        }
        public static string handleExcuteOfIteration(string input)
        {
            string result = "";

            if (input.IndexOf("for") == -1) // one iteration
            {
                result = "\nif(!" + exportExecuteLogicInIteration(input) + ")" 
                    + "\n{" + "\n\tbreak;" + "\n}";
                result = Regex.Replace(result, @"\r\n?|\n", "\n\t");
            } else // two iteration
            {
                result = Regex.Replace(input, @"\r\n?|\n", "\n\t");
            }
            return result;
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

            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(post);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

            if (firstIndexVM == -1 && firstIndexTT == -1) // no VM and no TT
            {
                result = handleBasicType(post);
            } else if (firstIndexVM != -1) // VM
            {
                if (firstIndexVM == lastIndexVM) // one VM
                {
                    if (firstIndexTT != -1 && firstIndexVM < firstIndexTT) // one VM and one TT
                    {
                        //result = handleVMIteration(handleTTIteration(post));
                    } else // only one VM
                    {
                        result = handleVMIteration(headerOfIteration, excuteOfIteration);
                    }
                } else // two VMs
                {
                    List<string> sub_splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(excuteOfIteration);
                    string sub_headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
                    string sub_excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

                    result = handleVMIteration(headerOfIteration, handleVMIteration(sub_headerOfIteration, sub_excuteOfIteration));
                }
            } else if (firstIndexTT != -1) // TT
            {
                if (firstIndexTT == lastIndexTT) // one TT
                {
                    if (firstIndexVM != -1 && firstIndexTT < firstIndexVM) // one TT and one VM
                    {
                        //result = handleTTIteration(handleVMIteration(post));
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
        public static string handleVMIteration(string headerOfIteration, string excuteOfIteration)
        {
            string[] splitedArray = findStringOfStartAndEndIndex(headerOfIteration).Split(new char[] { '.', '.' });
            string indexRepresent = findIndexRepresent(headerOfIteration);
            string arrayRepresent = "a"; // function provided by Tien Nam
            string startIndexofIteration = splitedArray[0] + DIFFERENCE_OF_ARRAY_INDEX;
            string endIndexOfIteration = splitedArray[splitedArray.Length - 1];

            string beginLineCode = $"int {indexRepresent};";
            string endLineCode = $"\nif({indexRepresent}=={endIndexOfIteration})" + "\n{" + "\n\treturn true;" + "\n} "
                + "else" + "\n{" + "\n\treturn false;" + "\n} ";
            return beginLineCode
                + $"\nfor (int {indexRepresent} = {startIndexofIteration}; {indexRepresent} <= {endIndexOfIteration + DIFFERENCE_OF_ARRAY_INDEX}; {indexRepresent}++)"
                + "\n{" + handleExcuteOfIteration(excuteOfIteration) +  "\n}"
                + endLineCode;
        }
        public static string handleTTIteration(string input)
        {
            return findIndexRepresent(input);
        }
        #endregion
    }
}
