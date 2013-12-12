using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab1
{
    class FuncCall
    {
        private string _text;
        private int _indexIntoText;

        private string _funcName;
        private List<string> _funcParams;

        public FuncCall(string text, int indexIntoText)
        {
            this._text = text;
            this._indexIntoText = indexIntoText;

            Regex regexToFuncName = new Regex(@"^[a-z,A-Z][a-z,A-Z,0-9]*(?=\()");
            Regex regexToFuncParams = new Regex(@"(?<=[a-z,A-Z][a-z,A-Z,0-9]*\()[\w,\W]*(?=\)\;)");

            this._funcName = regexToFuncName.Match(text).ToString();
            this._funcParams = new List<string>(regexToFuncParams.Match(text).ToString().Split(new char[] {','}));
        }

        public string GetText()
        {
            return this._text;
        }

        public string GetFuncName() {
            return this._funcName;
        }

        public List<string> GetFuncParams() {
            return this._funcParams;
        }

        public int GetIndexIntoText()
        {
            return this._indexIntoText;
        }
    }
}
