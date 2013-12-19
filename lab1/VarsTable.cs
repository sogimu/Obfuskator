using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    class VarsTable
    {
        private int _lastCellIndex = 0;
        private List<ItemForVar> _varItemList = new List<ItemForVar>();

        private List<int> _finalArray = new List<int>();

        private SizeOfTypes _sizeOfTypes = new SizeOfTypes();

        public int AddVar(ItemForVar item)
        {
            int newIndex = this.GetNewCellIndex(item.GetType());
            item.SetIndex( newIndex );
            this._varItemList.Add(item);
            this.AddItemToFinalArray(item);

            return newIndex;
        }

        public void AddItemToFinalArray(ItemForVar item)
        {
            for (int i = 0; i < item.GetSellsCount(); i++)
            {
                this._finalArray.Add(item.GetCellByIndex(i));
            }
        }

        public ItemForVar GetItem(string name, string view)
        {
            foreach (ItemForVar item in this._varItemList)
            {
                if (item.GetName() == name && item.GetView() == view)
                {
                    return item;
                }
            }

            return null;
        }

        public ItemForVar GetVarByNameAndView(string name, string view)
        {
            foreach (var item in this.GetVarItemList())
            {
                if ((item.GetName() == name) && (item.GetView() == view))
                {
                    return item;
                }
            }

            throw new Exception("Have not var with this name and view!");
        }

        public List<ItemForVar> GetVarsByView(string view)
        {
            List<ItemForVar> items = new List<ItemForVar>();
            foreach (var item in this.GetVarItemList())
            {
                if (item.GetView() == view)
                {
                    items.Add(item);
                }
            }

            return items;

        }

        public List<ItemForVar> GetVarParamsByView(string view)
        {
            List<ItemForVar> funcParams = new List<ItemForVar>();
            int paramIndex = 0;

            foreach (var i in this.GetVarItemList())
            {
                foreach (var item in this.GetVarItemList())
                {
                    if (item.IsParam() && item.GetView() == view && item.GetParamsIndex() == paramIndex++)
                    {
                        funcParams.Add(item);
                    }
                }
            }

            return funcParams;

        }

        public ItemForVar GetVarByIndex(int index)
        {
            foreach (var item in this.GetVarItemList())
            {
                if (item.GetIndex() == index)
                {
                    return item;
                }
            }

            throw new Exception("Have not var with this index!");
        }

        public int GetLastCellIndex()
        {
            return this._lastCellIndex;
        }

        public int GetNewCellIndex(string type)
        {   
            int currentIndex = this._lastCellIndex++;
            this._lastCellIndex += this._sizeOfTypes.GetSizeOfType(type) - 1;

            return currentIndex;

        }

        public int GetCellsCount()
        {
            return this._lastCellIndex;
        }

        public List<ItemForVar> GetVarItemList()
        {
            return this._varItemList;
        }

        public List<int> GetFinalArray()
        {
            return this._finalArray;
        }

    }
}
