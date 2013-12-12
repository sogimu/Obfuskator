using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    class StringConst
    {
        private string _text = "";
        private int _indexIntoText = -1;
        private ItemForVar _item = null;
        
        public StringConst(string text, int indexIntoText)
        {
            this._text = text;
            this._indexIntoText = indexIntoText;
            this._item = new ItemForVar(null, null, -1, "string", indexIntoText);
            
            int letterPos = 0;
            foreach(char letter in this.GetText())
            {
                this._item.SetCellByIndex( letterPos, (int)letter );
                letterPos++;
            }

        }

        public string GetText() {
            return this._text;
        }

        public int GetLength()
        {
            return this._text.ToString().Length;
        }

        public int GetIndexIntoText()
        {
            return this._indexIntoText - 1;
        }

        public ItemForVar GetItemForVar()
        {
            return this._item;
        }

    }
}
