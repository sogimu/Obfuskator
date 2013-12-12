using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    class IntConst
    {
        private int _value = 0;
        private int _indexIntoText = -1;
        private ItemForVar _item = null;
        
        public IntConst(int value, int indexIntoText)
        {
            this._value = value;
            this._indexIntoText = indexIntoText;
            this._item = new ItemForVar(null, null, -1, "int", indexIntoText);

            int letterPos = 0;
            this._item.SetCellByIndex(letterPos, this.GetValue());
            
        }

        public int GetValue() {
            return this._value;
        }

        public int GetLength()
        {
            return this._value.ToString().Length;
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
