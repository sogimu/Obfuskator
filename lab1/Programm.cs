using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab1
{
    class Programm
    {
        static public Func FindFunc(int index, string text)
        {
            Regex regexToFindFunc = new Regex(@"static\s+void\s[a-z,A-Z]*\s?\(.*\)\s*\{[a-z,A-Z,\d,\s,"",'=',';','+','.','(',')',//]*}");
            Match funcMatch = regexToFindFunc.Match(text, index);
            if (funcMatch.Success)
            {
                string funcText = funcMatch.Value;
                Func func = new Func( funcText, funcMatch.Index);

                return func;

            }
            else
            {
                return null;
            }
        }

        static public IntConst FindIntConst(int index, string text)
        {
            Regex regexToFindIntConsts = new Regex(@"(?<=[\s,;,+,-,\,*,\,,'(',')'])[\d]+(?=[\s,;,+,-,\,*,\,,'(',')'])");
            Match intConstsMatch = regexToFindIntConsts.Match(text, index);
            if (intConstsMatch.Success)
            {
                string value = intConstsMatch.Value;

                IntConst newIntConst = new IntConst(Int32.Parse(intConstsMatch.ToString()), intConstsMatch.Index);

                return newIntConst;

            }
            else
            {
                return null;
            }


        }

        static public StringConst FindStringConst(int index, string text)
        {
            if (index < text.Length)
            {
                Regex regexToFindStringConsts = new Regex(@"(?<="")[\w,\W]*?(?="")");
                Match stringConstsMatch = regexToFindStringConsts.Match(text, index);
                if (stringConstsMatch.Success)
                {
                    string value = stringConstsMatch.Value;

                    StringConst newStringConst = new StringConst(stringConstsMatch.Value, stringConstsMatch.Index);

                    return newStringConst;

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }


        }

        static public VarInit FindVarInit(int index, string text)
        {
            if (index < text.Length)
            {
                Regex regexToFindVarInit = new Regex(@"(int|string)\s*[a-z,A-Z][a-z,A-Z,0-9]*(\;|\,|\s*)");
                Match varInitMatch = regexToFindVarInit.Match(text, index);
                if (varInitMatch.Success)
                {
                    string varInitText = varInitMatch.Value;

                    VarInit varInit = new VarInit(varInitText,varInitMatch.Index);

                    return varInit;

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        static public Assignment FindAssignment(int index, string text)
        {
            if (index < text.Length)
            {
                Regex regexToFindAssignment = new Regex(@"[a-z,A-Z][a-z,A-Z,0-9]*\s*=\s*[\s,\*,\(,\),\+,\-,\\,a-z,A-Z,0-9]*;");
                Match assignmentMatch = regexToFindAssignment.Match(text, index);
                if (assignmentMatch.Success)
                {
                    string assignmentText = assignmentMatch.Value;

                    Assignment assignment = new Assignment(assignmentText, assignmentMatch.Index);

                    return assignment;

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        static public FuncCall FindFuncCall(int index, string text)
        {
            Regex regexToFindFuncCall = new Regex(@"[a-z,A-Z][a-z,A-Z,0-9]*\s*\(.*\)\;");
            Match funcCallMatch = regexToFindFuncCall.Match(text, index);
            if (funcCallMatch.Success)
            {

                return new FuncCall(funcCallMatch.Value, funcCallMatch.Index);
            }
            else
            {

                return null;
            }
        }

    }
}
