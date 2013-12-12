using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab1
{
    class Assignment
    {
        private string _text;
        private string _variabaleName;
        private string _rightText;
        private int _indexIntoText = -1;

        public Assignment(string text, int indexIntoText)
        {
            this._text = text;
            this._indexIntoText = indexIntoText;

            Regex regexToVaribale = new Regex(@"^[a-z,A-Z][a-z,A-Z,0-9]*");
            Regex regexToRightText = new Regex(@"(?<=[a-z,A-Z][a-z,A-Z,0-9]*\s*=\s*)[\w,\W]*(?=\;)");

            this._variabaleName = regexToVaribale.Match(text).ToString();
            this._rightText = regexToRightText.Match(text).ToString();
        }

        public string GetText()
        {
            return this._text;
        }

        public string GetVaribaleName() {
            return this._variabaleName;
        }

        public string GetRightText() {
            return this._rightText;
        }

        public int GetIndexIntoText()
        {
            return this._indexIntoText;
        }

    }
}
