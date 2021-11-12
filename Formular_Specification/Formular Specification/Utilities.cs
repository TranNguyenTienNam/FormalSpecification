﻿using System;
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
            string result = "";

            List<string> threePartSplited = splitInputToThreePart(specificationSource);

            string titlePart = threePartSplited[0].Replace("\n", "").Replace("\t", "").Trim();
            string prePart = threePartSplited[1];
            string postPart = handlePost(threePartSplited[2]);

            string title = null;
            List<KeyValuePair<string, string>> inputs = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> output = new KeyValuePair<string, string>();

            HandlingTitleLine(titlePart, ref title, ref inputs, ref output);

            string condition = null;
            HandlingPreLine(prePart, ref condition);

            GeneratingInputFunction(ref result, title, inputs);
            GeneratingCheckFunction(ref result, title, inputs, condition);
            GeneratingOutputFunction(ref result, title, output);
            GeneratingHandlingFunction(ref result, title, inputs, postPart, output);
            GeneratingMainFunction(ref result, title, inputs, output);

            result = GenerateAll(result);
            return result;
        }
        public static string generateVBCode(string specificationSource)
        {
            string result = "";
            List<string> threePartSplited = splitInputToThreePart(specificationSource);

            result = handlePost(threePartSplited[2]);

            return result;
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
        #region if type
        public static string handleInputType(string input)
        {
            string result = "";
            string[] splitedIfCondition = input.Replace("||", "|").Split('|');
            if(splitedIfCondition.Length == 1)
            {
                splitedIfCondition[0] = splitedIfCondition[0].Replace("&&", "&");
                if (splitedIfCondition[0].Split('&').Length == 1)
                {

                } else
                {
                    splitedIfCondition[0] = removeOpenAndCloseBoundBrackets(splitedIfCondition[0]);
                }         
                result += handleCondition(splitedIfCondition[0]);
            } else
            {
                for(int i = 0; i< splitedIfCondition.Length; i++)
                {
                    splitedIfCondition[i] = removeOpenAndCloseBoundBrackets(splitedIfCondition[i]).Replace("&&","&");
                    result += handleCondition(splitedIfCondition[i]);
                }
            }

            if (result.IndexOf("if") != -1)
                result += " else throw new Exception();";

            return result;
        }
        public static string handleCondition(string input)
        {
            string result = "";

            string[] splitedIfCondition = input.Split('&');

            if(splitedIfCondition.Length == 1)
            {
                return handleReturnConditionLogic(splitedIfCondition[0]);
            } else
            {
                result = "\n" + "if( " + splitedIfCondition[1].Trim();
                for (int i = 2; i< splitedIfCondition.Length; i++)
                {
                    splitedIfCondition[i] = splitedIfCondition[i].Trim();
                    result += " && " + splitedIfCondition[i];
                }
                result += " )\n{\n\t" + handleReturnConditionLogic(splitedIfCondition[0]) + "\n}";
            }

            return result;
        }
        public static string handleReturnConditionLogic(string input)
        {
            string result = "";

            input = removeOpenAndCloseBoundBrackets(input);
            string[] splitedReturnConditionLogic = input.Split('=');

            result = "return " + handleBooleanReturn(splitedReturnConditionLogic[1])+ ";" ;

            return result;
        }
        public static string handleBooleanReturn(string input)
        {
            string result = "";
            input = input.Trim();

            if(input.ToLower() == "false")
            {
                return "false";
            } else if (input.ToLower() == "true")
            {
                return "true";
            } else
            {
                result = input;
            }

            return result;
        }
        #endregion
        #region iteration type
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
        //public static string handleExcuteOfIteration(string input)
        //{
        //    string result = "";

        //    result = "\nif(!" + exportExecuteLogicInIteration(input) + ")"
        //        + "\n{" + "\n\tbreak;" + "\n}";
        //    result = Regex.Replace(result, @"\r\n?|\n", "\n\t");
        //    return result;
        //}
        public static string findRepresentArrayName(string input)
        {
            string result = "";

            input.Trim();
            int indexOfFirstOpenBounder = input.IndexOf("(");
            result = input.Substring(0, indexOfFirstOpenBounder);

            return result;
        }
        #endregion
        #endregion
        #region Handle title and pre part
        public static void HandlingTitleLine(string line, ref string title, ref List<KeyValuePair<string, string>> inputs, ref KeyValuePair<string, string> output)
        {
            title = line.Replace(" ", "").Split('(', ')')[0];

            string input = line.Replace(" ", "").Split('(', ')')[1];
            foreach (var _input in input.Split(','))
            {
                string var = _input.Split(':')[0];
                string type = GetTypes(_input.Split(':')[1]);
                inputs.Add(new KeyValuePair<string, string>(var, type));
            }

            string _output = line.Replace(" ", "").Split('(', ')')[2];
            string outputVar = _output.Replace("\n", "").Replace("\t", "").Split(':')[0];
            string outputType = GetTypes(_output.Split(':')[1]);
            output = new KeyValuePair<string, string>(outputVar, outputType);
        }

        public static void HandlingPreLine(string line, ref string condition)
        {
            if (line.Replace("\n", "").Replace("\t", "").Trim().Remove(0, 3).Length == 0)
                condition = "|true|";
            else
            {
                condition += line.Replace(" ", "").Remove(0, 3);
                condition = condition.Remove(condition.Length - 1);
            }
        }

        public static void GeneratingInputFunction(ref string generateCode, string title, List<KeyValuePair<string, string>> inputs)
        {
            string paras = null;
            string code = null;

            bool isArray = false;
            foreach (var input in inputs)
            {
                paras += string.Format("|ref| |{0}| |{1}|", input.Value, input.Key);
                if (input.Key != inputs.Last().Key) paras += "|,| ";

                if (input.Value == "|int||[]|" || input.Value == "|float||[]|") isArray = true;
            }

            if (isArray == false)
            {
                foreach (var input in inputs)
                {
                    code += string.Format("\t|Console|.|WriteLine|(|\"Nhap {0}:\"|);\n", input.Key);
                    code += string.Format("\t{0} = |{1}|.|Parse|(|Console|.|ReadLine|());\n", input.Key, input.Value);
                }
            }
            else
            {
                string loopsVar = null;
                string arrVar = null;
                string arrType = null;
                foreach (var input in inputs)
                {
                    if (input.Value == "int")
                    {
                        string pre = null;
                        pre += string.Format("\t|Console|.|WriteLine|(|\"Nhap so phan tu {0} cua day:\"|);\n", input.Key);
                        pre += string.Format("\t{0} = |int|.|Parse|(|Console|.|ReadLine|());\n", input.Key);
                        code = pre + code;

                        loopsVar = input.Key;
                    }
                    else
                    {
                        arrVar = input.Key;
                        arrType = input.Value.Split('[', ']')[0];
                    }
                }

                code += string.Format("\t{0} = |new| {1}[{2}];\n", arrVar, arrType, loopsVar);
                code += string.Format("\tfor (|int| i = 0; i < {0}; i++)\n\t{{\n", loopsVar);
                code += string.Format("\t\t|Console|.|WriteLine|(|\"Nhap phan tu {1}[{{0}}]:\"|, i);\n", loopsVar, arrVar);
                code += string.Format("\t\t{0}[i] = {1}.|Parse|(|Console|.|ReadLine|());\n\t}}\n", arrVar, arrType);
            }

            generateCode += string.Format("|public| |void| |Nhap_{0}|(|{1}|)|\n{{\n{2}}}\n\n", title, paras, code);
        }

        public static void GeneratingCheckFunction(ref string generateCode, string title, List<KeyValuePair<string, string>> inputs, string condition)
        {
            string paras = null;
            foreach (var input in inputs)
            {
                paras += string.Format("|{0}| |{1}|", input.Value, input.Key);
                if (input.Key != inputs.Last().Key) paras += ", ";
            }
            generateCode += string.Format("|public| |bool| |KiemTra_{0}|({1})\n{{\n\t|return| {2};\n}}\n\n", title, paras, condition);
        }

        public static void GeneratingMainFunction(ref string generateCode, string title, List<KeyValuePair<string, string>> inputs, KeyValuePair<string, string> output)
        {
            string code = null;
            string paras = null;
            string ref_paras = null;
            foreach (var input in inputs)
            {
                code += string.Format("\t|{0}| |{1} =| |{2}|;\n", input.Value, input.Key, GetInitializeValue(input.Value));

                paras += string.Format("{0}", input.Key);
                ref_paras += string.Format("|ref| |{0}|", input.Key);

                if (input.Key != inputs.Last().Key)
                {
                    paras += ", ";
                    ref_paras += ", ";
                }
            }
            code += string.Format("\t|{0}| |{1} = {2};|\n", output.Value, output.Key, GetInitializeValue(output.Value));
            code += string.Format("\t|Program| p = |new| |Program|();\n");
            code += string.Format("\tp.|Nhap_{0}|({1});\n", title, ref_paras);
            code += string.Format("\t|if| (p.|KiemTra_{0}|({1}))\n\t{{\n\t\t{2} = p.|XuLy_{0}|({1});\n\t\tp.|Xuat_{0}|({2});\n\t}}\n", title, paras, output.Key);
            code += string.Format("\t|else|\n\t\t|Console|.|WriteLine|(|\"Thong tin nhap khong hop le!\"|);\n");
            code += string.Format("\t|Console|.|ReadLine|();\n");

            generateCode += string.Format("|public| |static| |void| |Main|(|string|[] args)\n{{|\n{0}|}}|", code);
        }

        public static string GetTypes(string typeFL)
        {
            switch (typeFL)
            {
                case "N":
                    return "int";
                case "N*":
                    return "|int||[]|";
                case "Z":
                    return "int";
                case "Z*":
                    return "|int||[]|";
                case "R":
                    return "float";
                case "R*":
                    return "|float||[]|";
                case "B":
                    return "bool";
                case "char*":
                    return "string";
                default:
                    Console.WriteLine("This type {0} is invalid!", typeFL);
                    return null;
            }
        }

        public static string GetInitializeValue(string type)
        {
            switch (type)
            {
                case "int":
                    return "0";
                case "float":
                    return "0";
                case "bool":
                    return "false";
                default:
                    return "null";
            }
        }

        public static void GeneratingOutputFunction(ref string generateCode, string title, KeyValuePair<string, string> output)
        {
            string code = null;
            code = string.Format("\t|Console|.|WriteLine|(|\"Ket qua la: {{0}}\"|, {0});\n", output.Key);

            generateCode += string.Format("|public| |void| |Xuat_{0}|(|{1}| |{2}|)\n{{\n{3}}}\n\n", title, output.Value, output.Key, code);
        }

        public static void GeneratingHandlingFunction(ref string result, string title, List<KeyValuePair<string, string>> inputs, string postPart, KeyValuePair<string, string> output)
        {
            string paras = null;
            foreach (var input in inputs)
            {
                paras += string.Format("|{0}| |{1}|", input.Value, input.Key);
                if (input.Key != inputs.Last().Key) paras += "|,| ";
            }

            postPart = Regex.Replace(postPart, @"\r\n?|\n", "\n\t"); // TODO: Tab

            result += string.Format("|public| {0} |XuLy_{1}||(|{2}|)|\n|{{|\n{3}\n|}}|\n", output.Value, title, paras, postPart);
        }
        #endregion
        #region router 
        public static string handlePost(string input)
        {
            string result = "";

            string post = removeOpenAndCloseBoundBrackets(input);

            int firstIndexVM = post.IndexOf(VM_SYNTAX);
            int lastIndexVM = post.LastIndexOf(VM_SYNTAX);

            int firstIndexTT = post.IndexOf(TT_SYNTAX);
            int lastIndexTT = post.LastIndexOf(TT_SYNTAX);


            if (firstIndexVM == -1 && firstIndexTT == -1) // no VM and no TT
            {
                result = handleInputType("(" + post + ")");
                return result;
            }

            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(post);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];
            if (firstIndexVM != -1) // VM
            {
                if (firstIndexVM == lastIndexVM) // one VM
                {
                    if (firstIndexTT != -1) // one VM and one TT
                    {
                        if (firstIndexTT < firstIndexVM)
                        {
                            List<string> handled = handleTTVMIteration(post);
                            result = handled[0] + handled[1] + handled[2];
                        }
                        else
                        {
                            List<string> handled = handleVMTTIteration(post);
                            result = handled[0] + handled[1] + handled[2];
                        }
                    }
                    else // only one VM
                    {
                        List<string> handled = handleVMIteration(post, "return false;", DIFFERENCE_OF_ARRAY_INDEX);
                        result = handled[0] + handled[1] + handled[2];
                    }
                }
                else // two VMs
                {
                    List<string> handled = handleVMVMIteration(post);
                    result = handled[0] + handled[1] + handled[2];
                }
            }
            else if (firstIndexTT != -1) // TT
            {
                if (firstIndexTT == lastIndexTT) // one TT
                {
                    if (firstIndexVM != -1 && firstIndexTT < firstIndexVM) // one TT and one VM
                    {
                        List<string> handled = handleTTVMIteration(post);
                        result = handled[0] + handled[1] + handled[2];
                    }
                    else // only one TT
                    {
                        List<string> handled = handleTTIteration(post, "return true;", DIFFERENCE_OF_ARRAY_INDEX);
                        result = handled[0] + handled[1] + handled[2];
                    }
                }
                else // two TTs
                {
                    List<string> handled = handleTTTTIteration(post);
                    result = handled[0] + handled[1] + handled[2];
                }
            }




            return result;
        }
        #endregion
        #region AddNamespace
        public static string GenerateAll(string input)
        {
            input = Regex.Replace(input, @"\r\n?|\n", "\n\t");
            string generateCode = null;
            generateCode += "|using| System;\n";
            string _namespace = "FormalSpecification";
            generateCode += string.Format("|namespace| |{0}|\n|{{|\n|public| |class| |Program|\n{{\n{1}\n}}\n}}", _namespace, input);
            return generateCode;
        }
        #endregion
        #region Handler Genarate Iteration
        public static List<string> handleVMIteration(string input, string breakPointString, string differenceArrayIndex)
        {
            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(input);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

            List<string> result = new List<string>();

            string[] splitedArray = findStringOfStartAndEndIndex(headerOfIteration).Split(new char[] { '.', '.' });
            string indexRepresent = findIndexRepresent(headerOfIteration);
            string arrayRepresent = findRepresentArrayName(excuteOfIteration); // function provided by Tien Nam
            string startIndexofIteration = splitedArray[0] + differenceArrayIndex;
            string endIndexOfIteration = splitedArray[splitedArray.Length - 1];

            string declarePart = $"|int| {indexRepresent};";
            string bodyPart = "";
            string returnPart = $"\n|return| true;";
            string executeCodeString = "\nif(!(" + exportExecuteLogicInIteration(excuteOfIteration) + "))"
                + "\n{" + $"\n\t{breakPointString}" + "\n}";
            executeCodeString = Regex.Replace(executeCodeString, @"\r\n?|\n", "\n\t");

            bodyPart = $"\nfor ({indexRepresent} = {startIndexofIteration}; {indexRepresent} <= {endIndexOfIteration + DIFFERENCE_OF_ARRAY_INDEX}; {indexRepresent}++)"
                + "\n{" + executeCodeString + "\n}";

            result.Add(declarePart);
            result.Add(bodyPart);
            result.Add(returnPart);

            return result;
        }
        public static List<string> handleTTIteration(string input, string breakPointString, string differenceArrayIndex)
        {
            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(input);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

            List<string> result = new List<string>();

            string[] splitedArray = findStringOfStartAndEndIndex(headerOfIteration).Split(new char[] { '.', '.' });
            string indexRepresent = findIndexRepresent(headerOfIteration);
            string arrayRepresent = "a"; // function provided by Tien Nam
            string startIndexofIteration = splitedArray[0] + differenceArrayIndex;
            string endIndexOfIteration = splitedArray[splitedArray.Length - 1];

            string declarePart = $"|int| {indexRepresent};";
            string bodyPart = "";
            string returnPart = $"\n|return| false;";
            string executeCodeString = "\n|if|(" + exportExecuteLogicInIteration(excuteOfIteration) + ")"
                + "\n{" + $"\n\t{breakPointString}" + "\n}";
            executeCodeString = Regex.Replace(executeCodeString, @"\r\n?|\n", "\n\t");

            bodyPart = $"\nfor ({indexRepresent} = {startIndexofIteration}; {indexRepresent} <= {endIndexOfIteration + DIFFERENCE_OF_ARRAY_INDEX}; {indexRepresent}++)"
                + "\n{" + executeCodeString + "\n}";

            result.Add(declarePart);
            result.Add(bodyPart);
            result.Add(returnPart);

            return result;
        }
        public static List<string> handleVMVMIteration(string input)
        {

            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(input);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

            List<string> result = new List<string>();

            string[] splitedArray = findStringOfStartAndEndIndex(headerOfIteration).Split(new char[] { '.', '.' });
            string indexRepresent = findIndexRepresent(headerOfIteration);
            string arrayRepresent = "a"; // function provided by Tien Nam
            string startIndexofIteration = splitedArray[0] + DIFFERENCE_OF_ARRAY_INDEX;
            string endIndexOfIteration = splitedArray[splitedArray.Length - 1];

            string declarePart = $"|int| {indexRepresent};";
            string bodyPart = "";
            string returnPart = $"\n|return| true;";

            List<string> handledVMIteration = handleVMIteration(excuteOfIteration, "return false;", "");
            string executeCodeString = "\n" + handledVMIteration[0] + handledVMIteration[1];
            executeCodeString = Regex.Replace(executeCodeString, @"\r\n?|\n", "\n\t");

            bodyPart = $"\nfor ({indexRepresent} = {startIndexofIteration}; {indexRepresent} <= {endIndexOfIteration + DIFFERENCE_OF_ARRAY_INDEX}; {indexRepresent}++)"
                + "\n{" + executeCodeString + "\n}";

            result.Add(declarePart);
            result.Add(bodyPart);
            result.Add(returnPart);

            return result;
        }
        public static List<string> handleVMTTIteration(string input)
        {
            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(input);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

            List<string> result = new List<string>();

            string[] splitedArray = findStringOfStartAndEndIndex(headerOfIteration).Split(new char[] { '.', '.' });
            string indexRepresent = findIndexRepresent(headerOfIteration);
            string arrayRepresent = "a"; // function provided by Tien Nam
            string startIndexofIteration = splitedArray[0] + DIFFERENCE_OF_ARRAY_INDEX;
            string endIndexOfIteration = splitedArray[splitedArray.Length - 1];

            string declarePart = $"|int| {indexRepresent};";
            string bodyPart = "";
            string returnPart = $"\n|return| true;";

            List<string> handledTTIteration = handleTTIteration(excuteOfIteration, "goto breakPoint;", "");
            string executeCodeString = "\n" + handledTTIteration[0] + handledTTIteration[1] + handledTTIteration[2] + "\nbreakPoint: continue;";
            executeCodeString = Regex.Replace(executeCodeString, @"\r\n?|\n", "\n\t");

            bodyPart = $"\nfor ({indexRepresent} = {startIndexofIteration}; {indexRepresent} <= {endIndexOfIteration + DIFFERENCE_OF_ARRAY_INDEX}; {indexRepresent}++)"
                + "\n{" + executeCodeString + "\n}";

            result.Add(declarePart);
            result.Add(bodyPart);
            result.Add(returnPart);

            return result;
        }
        public static List<string> handleTTVMIteration(string input)
        {
            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(input);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

            List<string> result = new List<string>();

            string[] splitedArray = findStringOfStartAndEndIndex(headerOfIteration).Split(new char[] { '.', '.' });
            string indexRepresent = findIndexRepresent(headerOfIteration);
            string arrayRepresent = "a"; // function provided by Tien Nam
            string startIndexofIteration = splitedArray[0] + DIFFERENCE_OF_ARRAY_INDEX;
            string endIndexOfIteration = splitedArray[splitedArray.Length - 1];

            string declarePart = $"int {indexRepresent};";
            string bodyPart = "";
            string returnPart = $"\n|return| true;";

            List<string> handledVMIteration = handleVMIteration(excuteOfIteration, "goto breakPoint;", "");
            string executeCodeString = "\n" + handledVMIteration[0] + handledVMIteration[1] + handledVMIteration[2] + "\nbreakPoint: continue;";
            executeCodeString = Regex.Replace(executeCodeString, @"\r\n?|\n", "\n\t");

            bodyPart = $"\nfor ({indexRepresent} = {startIndexofIteration}; {indexRepresent} <= {endIndexOfIteration + DIFFERENCE_OF_ARRAY_INDEX}; {indexRepresent}++)"
                + "\n{" + executeCodeString + "\n}";

            result.Add(declarePart);
            result.Add(bodyPart);
            result.Add(returnPart);

            return result;
        }
        public static List<string> handleTTTTIteration(string input)
        {
            List<string> splitedOfHeaderAndExecuteLogicIteration = splitInputToHeaderAndExecuteOfIteration(input);
            string headerOfIteration = splitedOfHeaderAndExecuteLogicIteration[0];
            string excuteOfIteration = splitedOfHeaderAndExecuteLogicIteration[1];

            List<string> result = new List<string>();

            string[] splitedArray = findStringOfStartAndEndIndex(headerOfIteration).Split(new char[] { '.', '.' });
            string indexRepresent = findIndexRepresent(headerOfIteration);
            string arrayRepresent = "a"; // function provided by Tien Nam
            string startIndexofIteration = splitedArray[0] + DIFFERENCE_OF_ARRAY_INDEX;
            string endIndexOfIteration = splitedArray[splitedArray.Length - 1];

            string declarePart = $"int {indexRepresent};";
            string bodyPart = "";
            string returnPart = $"\n|return| false;";

            List<string> handledTTIteration = handleTTIteration(excuteOfIteration, "return true;", "");
            string executeCodeString = "\n" + handledTTIteration[0] + handledTTIteration[1];
            executeCodeString = Regex.Replace(executeCodeString, @"\r\n?|\n", "\n\t");

            bodyPart = $"\nfor ({indexRepresent} = {startIndexofIteration}; {indexRepresent} <= {endIndexOfIteration + DIFFERENCE_OF_ARRAY_INDEX}; {indexRepresent}++)"
                + "\n{" + executeCodeString + "\n}";

            result.Add(declarePart);
            result.Add(bodyPart);
            result.Add(returnPart);

            return result;
        }
        #endregion
    }
}
