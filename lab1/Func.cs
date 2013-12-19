using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace lab1
{
    class Func
    {
        private string _funcText = "";
        private string _nameText = "";
        private string _bodyText = "";
        private string _funcParamsText = "";

        private int _indexName = 0;
        private int _indexBody = 0;
        private int _indexFuncParams = 0;
        private int _indexFuncIntoText = 0;

        private List<ItemForVar> _params = new List<ItemForVar>();
        
        public Func(string funcText, int index)
        {
            Regex regexToFindFuncName = new Regex(@"(?<=void\s+)[a-z,A-Z]+[a-z,A-Z,0-9]*");
           // Regex regexToFindFuncBody = new Regex(@"(?<={)\s[\w,(,);,:,\s,|,\/,\*,\+,\=,\[,\],\.,\!,\-,\%,\&,"", \?, \\]*}");//ничего ненаходило
            Regex regexToFindFuncBody = new Regex(@"(?<={)\s[\w,(,);,:,\s,|,\/,\*,\+,\=,\[,\],\.,\!,\-,\%,&,>,<,\?,""]*");

            Regex regexToFindFuncParams = new Regex(@"(?<=void\s+[a-z, A-Z][a-z,A-Z,0-9]*\s*\(\s*)[\W,\w

6


]*(?=\)\s*{)");

            Match name = regexToFindFuncName.Match(funcText);
            Match body = regexToFindFuncBody.Match(funcText);
            Match funcParams = regexToFindFuncParams.Match(funcText);

            
            this._funcText = funcText;
            this._nameText = name.Value;
            this._bodyText = body.Value;
            this._funcParamsText = funcParams.Value;


            this._indexName = name.Index;
            this._indexBody = body.Index;
            this._indexFuncParams = funcParams.Index;
            this._indexFuncIntoText = index;
        }

        public string GetFuncText()
        {
            return this._funcText;
        }

        public string GetName() {
            return this._nameText;
        }

        public string GetBody() {
            return this._bodyText;
        }

        public string GetFuncParamsText()
        {
            return this._funcParamsText;
        }

        public int GetIndexBody()
        {
            return this._indexBody;
        }

        public int GetIndexName()
        {
            return this._indexName;
        }

        public int GetIndexFuncParams()
        {
            return this._indexFuncParams;
        }

        public int GetIndexFuncIntoText()
        {
            return this._indexFuncIntoText;
        }
    }
}
