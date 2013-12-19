using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab1
{
    class Varibale
    {
        private string _text;
        private int _indexIntoText = -1;

        public Varibale(string text, int indexIntoText)
        {
            this._text = text;
            this._indexIntoText = indexIntoText;
        }

        public string GetText()
        {
            return this._text;
        }

        public int GetIndexIntoText()
        {
            return this._indexIntoText;
        }

    }
}
