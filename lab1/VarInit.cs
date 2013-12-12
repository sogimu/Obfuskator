using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab1
{
    class VarInit
    {
        private string _text;
        private string _name;
        private string _type;
        private int _indexIntoText = -1;
        private ItemForVar _item = null;

        public VarInit(string text, int indexIntoText)
        {
            this._text = text;
            this._indexIntoText = indexIntoText;

            Regex regexToType = new Regex(@"^(int|string)");
            Regex regexToName = new Regex(@"(?<=(string|int)\s+)[a-z,A-Z]+[0-9,a-z,A-Z]*(?=(\;|\,|\s*))");

            this._name = regexToName.Match(text).ToString();
            this._type = regexToType.Match(text).ToString();

            this._item = new ItemForVar(null, this.GetName(), -1, this.GetType(), indexIntoText);
        }

        public string GetText()
        {
            return this._text;
        }

        public string GetName() {
            return this._name;
        }

        public string GetType() {
            return this._type;
        }

        public int GetIndexIntoText()
        {
            return this._indexIntoText;
        }

        public ItemForVar GetItemForVar()
        {
            return this._item;
        }
    }
}
