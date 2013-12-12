using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    class SizeOfTypes
    {
        private Dictionary<string,int> _types = new Dictionary<string, int>();

        public SizeOfTypes()
        {
            this._types["int"] = 1;
            this._types["string"] = 30;
        }

        public int GetSizeOfType(string type) {
            if (this._types.ContainsKey(type))
            {
                return this._types[type];
            }
            else
            {
                throw new Exception("Unknow type!");
            }
        }

    }
}
