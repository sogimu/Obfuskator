using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    class ItemForVar
    {
        private string _view;
        private string _name;
        private int _indexIntoArray;
        private int _indexIntoText;
        private string _type;
        private bool _paramStatus = false;
        private int _paramIndex = -1;

        private SizeOfTypes _sizeOfTypes = new SizeOfTypes();

        private List<int> _cells;
        
        public ItemForVar(string view, string name, int indexIntoArray, string type, int indexIntoText)
        {
            this._name = name;
            this._view = view;
            this._indexIntoArray = indexIntoArray;
            this._type = type;
            this._indexIntoText = indexIntoText;

            this._cells = new List<int>(this._sizeOfTypes.GetSizeOfType(type));
            for (int i = 0; i < this._sizeOfTypes.GetSizeOfType(type); i++)
            {
                this._cells.Add(-1);
            }
        }

        public string GetName()
        {
            return this._name;
        }

        public string GetView()
        {
            return this._view;
        }

        public int GetIndex()
        {
            return this._indexIntoArray;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public void SetView(string view)
        {
            this._view = view;
        }

        public void SetIndex(int indexIntoArray)
        {
            this._indexIntoArray = indexIntoArray;
        }

        public void SetParamStatus(bool status)
        {
            this._paramStatus = status;
        }

        public void SetParamIndex(int index)
        {
            this._paramIndex = index;
        }

        public int GetSellsCount()
        {
            return this._sizeOfTypes.GetSizeOfType(this.GetType());
            
        }

        public string GetType()
        {
            return this._type;
        }

        public void SetCellByIndex(int index, int value)
        {
            if (index < this.GetSellsCount())
            {
                this._cells[index] = value;
            }
            else
            {
                throw new Exception("Out of range!");
            }
            
        }

        public int GetCellByIndex(int index)
        {
            if (index < this.GetSellsCount())
            {
                return this._cells[index];
            }
            else
            {
                throw new Exception("Out of range!");
            }
        }

        public bool IsParam()
        {
            return this._paramStatus;
        }

        public int GetParamsIndex()
        {
            return this._paramIndex;
        }
    }
}
