using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab1
{

    class TextOfProgram
    {
        private string Text = "";
        private List<string> Funcs = new List<string>();
        private List<VarInit> Vars = new List<VarInit>();
        private List<StringConst> StringConsts = new List<StringConst>();
        private List<IntConst> IntConsts = new List<IntConst>();

        private int lastFuncPosition = 0;
        private int lastVarPosition = 0;
        private int lastStringConstPosition = 0;
        private int lastIntConstPosition = 0;

        private string str;

        public TextOfProgram(string text)
        {
            this.Text = text;
            Regex regexToFindFuncs = new Regex(@"void\s[a-z,A-Z]*\s?\(.*\)\s*\{[a-z,A-Z,\d,\s,"",'=',';','+','(',')',//]*}");
            MatchCollection funcsMatches = regexToFindFuncs.Matches(text);
            foreach(Match match in funcsMatches) 
            {
                this.Funcs.Add( match.ToString() );
            }

            Regex regexToFindVariable = new Regex(@"(int|string)\s*[a-z,A-Z][a-z,A-Z,0-9]*;");
            MatchCollection variableMatches = regexToFindVariable.Matches(text);
            foreach (Match match in variableMatches)
            {
                this.Vars.Add( new VarInit(match.ToString(), match.Index ));
            }

            Regex regexToFindStringConsts = new Regex(@"(?<="")[\w,\W]*(?=""\s*;)");
            MatchCollection stringConstsMatches = regexToFindStringConsts.Matches(text);
            foreach (Match match in stringConstsMatches)
            {
                this.StringConsts.Add(new StringConst(match.ToString(), match.Index));
            }

            Regex regexToFindIntConsts = new Regex(@"(?<=[\s,;,+,-,\,*,\,,'(',')'])[\d]+(?=[\s,;,+,-,\,*,\,,'(',')'])");
            MatchCollection intConstsMatches = regexToFindIntConsts.Matches(text);
            foreach (Match match in intConstsMatches)
            {
                this.IntConsts.Add(new IntConst(Int32.Parse(match.ToString()), match.Index));
            }

        }

        public Func GetNextFunc()
        {
            /*if (this.lastFuncPosition < this.Funcs.Count)
            {
                this.lastFuncPosition++;
                string text = this.Funcs[this.lastFuncPosition - 1];

                Regex regexToFindFuncName = new Regex(@"(?<=void)\s[a-z,A-Z]*");
                Regex regexToFindFuncBody = new Regex(@"(?<={)\s[\w,(,);,\s,|,\/,\*,\+,\=,\[,\],\.,\!,\-,\%,""]*");

                //Func func = new Func(regexToFindFuncName.Match(text).ToString(), regexToFindFuncBody.Match(text).ToString(), 0);

                return func;
            }
            else
            {*/
                return null;
            //}
             
        
        
        }

        public VarInit GetNextVarInit()
        {
            if (this.lastVarPosition < this.Vars.Count)
            {
                VarInit varInit = this.Vars[this.lastVarPosition];
                this.lastVarPosition++;
                
                return varInit;
            }
            else
            {
                return null;
            }
            
        }

        public StringConst GetNextStringConst()
        {
            if (this.lastStringConstPosition < this.StringConsts.Count)
            {   
                StringConst stringConst = this.StringConsts[this.lastStringConstPosition];
                this.lastStringConstPosition++;

                return stringConst;
            }
            else
            {
                return null;
            }
            
        }

        public IntConst GetNextIntConst()
        {
            if (this.lastIntConstPosition < this.IntConsts.Count)
            {
                IntConst IntConst = this.IntConsts[this.lastIntConstPosition];
                this.lastIntConstPosition++;

                return IntConst;
            }
            else
            {
                return null;
            }
            
        }
    }
}
