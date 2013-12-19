using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    class Obfuscator
    {
        private string _nameFuncToRead = "fr(";
        private string _nameFuncToWrite = "fw(";

        private VarsTable _table = new VarsTable();
        
        private string GetFuncCallToRead(int index, string type)
        {
            switch (type)
            {
                case "int": { return this._nameFuncToRead + index.ToString() + ")"; };
                case "string": //{ return "(char)" + this._nameFuncToRead + index.ToString() + ")"; };
                    {
                        string callFuncToRead = "(" + "(char)" + this._nameFuncToRead + index.ToString() + ")";
                        ItemForVar item = this._table.GetVarByIndex(index);

                        //callFuncToRead = "(" + this.GetFuncCallToRead(index, "char");

                        for (int i = 1; i < item.GetFullSellsCount(); i++)
                        {
                            int indexOfChar = index + i;
                            callFuncToRead += "+" + "(char)" + this._nameFuncToRead + indexOfChar.ToString() + ")";
                        }

                        callFuncToRead += ").ToString()";
                        return callFuncToRead;
                    }
                
            }
            return "not func for " + type;
            
        }

        private string GetFuncCallToWrite(int index, string type, string rightText)
        {
            switch(type)
            {
                case "int": { return this._nameFuncToWrite + index.ToString() + ", \"int\", (" + rightText + ").ToString());"; };
                case "string": { return this._nameFuncToWrite + index.ToString() + ", \"string\", " + rightText + ");"; };
             
            }
            return "I can't create write call for this type: \"" + type + "\"";

        }

        private string GetReadFuncText()
        {
            return "public static int " + this._nameFuncToRead + "int index) { return mas[index]; }\n";
        }

        private string GetWriteFuncText()
        {
            SizeOfTypes sizeOfTypes = new SizeOfTypes();

            return "public static void " + this._nameFuncToWrite + "int index, string type, string data)" +
            "{" +
                "switch(type)" +
                "{" +
                    "case \"int\": {" +
                        "mas[index] = Int32.Parse(data);" +
                        "break;" +
                    "}" +

                    "case \"string\": {" +

                        "for(int i=0;i<"+ sizeOfTypes.GetSizeOfType("string") +"; i++)" +
                        "{" +
                            "mas[index + i] = -1;" +
                        "}" +

                        "int letterIndex=0;" +
                        "foreach(char letter in data)" +
                        "{" +
                            "mas[index + letterIndex] = (int)letter;" +
                        "}" +
                        "break;" +
                    "}" +
                "}" +

            "}\n";
        }

        private string GetArrayText()
        {
            string arrayText = "public static int[] mas = {";
            foreach (int cell in this._table.GetFinalArray())
            {
                arrayText += " " + cell.ToString() + ",";
            }

            arrayText += " 0";
            
            arrayText += "};\n";
            return arrayText;
        }

        private string WorkWithConsts(string text)
        {   
            Func func;
            IntConst intConst = null;
            
            int lastIntConstIndex = 0;
            int lastFuncIndex = 0;

            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                lastIntConstIndex = 0;
                string callFuncToRead="";
                while ((func = Programm.FindFunc(lastFuncIndex, text)) != null && (intConst = Programm.FindIntConst(lastIntConstIndex + callFuncToRead.Length, func.GetBody())) != null)
                {
                    int index = this._table.AddVar(intConst.GetItemForVar());
                    int posIntoText = intConst.GetIndexIntoText() + func.GetIndexBody() + func.GetIndexFuncIntoText();
                    
                    text = text.Remove(posIntoText, intConst.GetLength());
                    callFuncToRead = this.GetFuncCallToRead(index, "int");
                    text = text.Insert(posIntoText, callFuncToRead);
                    
                    lastIntConstIndex = intConst.GetIndexIntoText();
                }
                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }

            StringConst stringConst = null;

            int lastStringConstIndex = 0;
            lastFuncIndex = 0;

            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                lastStringConstIndex = 0;
                string callFuncToRead = "";
                while ((func = Programm.FindFunc(lastFuncIndex, text)) != null && (stringConst = Programm.FindStringConst(lastStringConstIndex + callFuncToRead.Length, func.GetBody())) != null)
                {
                    int index = this._table.AddVar(stringConst.GetItemForVar());
                    int posIntoText = stringConst.GetIndexIntoText() + func.GetIndexBody() + func.GetIndexFuncIntoText();
                    // 2 кавычки
                    text = text.Remove(posIntoText, stringConst.GetLength() + 2);

                    callFuncToRead = this.GetFuncCallToRead(index, "string");
                    /*callFuncToRead = "(" + this.GetFuncCallToRead(index, "char");

                    for (int i = 1; i < stringConst.GetLength(); i++)
                    {
                        int indexOfChar = index + i;
                        callFuncToRead += "+"+this.GetFuncCallToRead(indexOfChar, "char");
                    }

                    callFuncToRead += ").ToString()";*/
                    text = text.Insert(posIntoText, callFuncToRead);
                        
                    lastStringConstIndex = stringConst.GetIndexIntoText();
                }
                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }

            return text;
        }
        private string WorkWithFuncsParams(string text)
        {
            Func func;
            
            int lastFuncIndex = 0;

            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                int lastVarInitIndex = 0;
                VarInit varInit;

                int paramIndex = 0;
                while ((varInit = Programm.FindVarInit(lastVarInitIndex, func.GetFuncParamsText())) != null)
                {
                    //this._params.Add(varInit.GetItemForVar()); // Запомнить, какие параметры каким функциям принадлежат
                    ItemForVar item = varInit.GetItemForVar();
                    item.SetView(func.GetName());
                    item.SetParamStatus(true);
                    item.SetParamIndex(paramIndex++);

                    this._table.AddVar(item);
                    lastVarInitIndex = varInit.GetIndexIntoText() + varInit.GetText().Length;
                }

                text = text.Remove(func.GetIndexFuncParams() + func.GetIndexFuncIntoText(), func.GetFuncParamsText().Length);

                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }
            
            return text;
        }

        private string WorkWithVarInit(string text)
        {
            Func func;

            int lastFuncIndex = 0;

            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                int lastVarInitIndex = 0;
                VarInit varInit;

                while ((func = Programm.FindFunc(lastFuncIndex, text)) != null && (varInit = Programm.FindVarInit(lastVarInitIndex, func.GetBody())) != null)
                {
                    ItemForVar item = varInit.GetItemForVar();
                    item.SetView(func.GetName());
                    
                    this._table.AddVar(item);
                    text = text.Remove(func.GetIndexFuncIntoText() + func.GetIndexBody() + varInit.GetIndexIntoText(), varInit.GetText().Length);

                    lastVarInitIndex = varInit.GetIndexIntoText() + varInit.GetText().Length;
                }

                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }

            return text;
        }

        private string WorkWithLocalVars(string text)
        {
            Func func;

            int lastFuncIndex = 0;

            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                int lastVaribaleIndex = 0;
                Varibale varibale;
                List<ItemForVar> items = this._table.GetVarsByView(func.GetName());

                foreach (ItemForVar item in items)
                {
                    while ((varibale = Programm.FindVaribale(lastVaribaleIndex, item.GetName(), func.GetBody())) != null)
                    {
                        text = text.Remove(func.GetIndexFuncIntoText() + func.GetIndexBody() + varibale.GetIndexIntoText(), varibale.GetText().Length);
                        string newVaribale = this.GetFuncCallToRead(item.GetIndex(), item.GetType());
                        text = text.Insert(func.GetIndexFuncIntoText() + func.GetIndexBody() + varibale.GetIndexIntoText(), newVaribale);

                        lastVaribaleIndex = varibale.GetIndexIntoText() + varibale.GetText().Length;
                        func = Programm.FindFunc(lastFuncIndex, text);
                    }
                    lastVaribaleIndex = 0;

                }

                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }

            return text;
        }

        private string WorkWithAssignments(string text)
        {
            Func func;

            int lastFuncIndex = 0;

            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                int lastVarInitIndex = 0;
                Assignment assignment;
                
                while ((func = Programm.FindFunc(lastFuncIndex, text)) != null && (assignment = Programm.FindAssignment(lastVarInitIndex, func.GetBody())) != null)
                {
                    ItemForVar varibale = this._table.GetItem(assignment.GetVaribaleName(), func.GetName());
                    text = text.Remove(func.GetIndexFuncIntoText() + func.GetIndexBody() + assignment.GetIndexIntoText(), assignment.GetText().Length);
                    string newAssignment = this.GetFuncCallToWrite(varibale.GetIndex(), varibale.GetType(), assignment.GetRightText());
                    text = text.Insert(func.GetIndexFuncIntoText() + func.GetIndexBody() + assignment.GetIndexIntoText(), newAssignment);

                    lastVarInitIndex = assignment.GetIndexIntoText() + assignment.GetText().Length;
                }

                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }
            return text;
        }

        private string WorkWithFuncCall(string text)
        {
            List<string> funcsName = new List<string>();

            Func func;

            int lastFuncIndex = 0;

            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                if (func.GetName() != "Main")
                {
                    funcsName.Add(func.GetName());

                }
                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }

            lastFuncIndex = 0;
            
            while ((func = Programm.FindFunc(lastFuncIndex, text)) != null)
            {
                int lastVarInitIndex = 0;
                FuncCall funcCall;

                while ((func = Programm.FindFunc(lastFuncIndex, text)) != null && (funcCall = Programm.FindFuncCall(lastVarInitIndex, func.GetBody())) != null)
                {
                    string newCall = "";
                    foreach (string funcName in funcsName)
                    {
                        if (funcCall.GetFuncName() == funcName)
                        {
                            text = text.Remove(func.GetIndexBody() + func.GetIndexFuncIntoText() + funcCall.GetIndexIntoText(), funcCall.GetText().Length);

                            foreach (ItemForVar item in this._table.GetVarParamsByView(funcCall.GetFuncName()))
                            {
                                newCall += this.GetFuncCallToWrite(item.GetIndex(), item.GetType(), funcCall.GetFuncParams()[item.GetParamsIndex()]) + "\n";

                            }
                            newCall += funcCall.GetFuncName() + "();\n";

                            text = text.Insert(func.GetIndexBody() + func.GetIndexFuncIntoText() + funcCall.GetIndexIntoText(), newCall);
                            lastVarInitIndex = funcCall.GetIndexIntoText() + newCall.Length;

                            break;
                        }
                        else
                        {
                            lastVarInitIndex = funcCall.GetIndexIntoText() + funcCall.GetText().Length;

                        }
                    }

                }

                lastFuncIndex = func.GetIndexFuncIntoText() + func.GetFuncText().Length;
            }

            return text;
        }

        private string WorkWithArrayAddWriteAndReadFunctions(string text)
        {
            Func func;

            if((func = Programm.FindFunc(0, text)) != null)
            {
                int insertPos = func.GetIndexFuncIntoText();
                text = text.Insert(insertPos, this.GetReadFuncText());
                text = text.Insert(insertPos += this.GetReadFuncText().Length, this.GetWriteFuncText());
                text = text.Insert(insertPos += this.GetWriteFuncText().Length, this.GetArrayText());

            }

            return text;
        }

        public string Make(string text)
        {

            string processedText = text;
            processedText = WorkWithConsts(processedText);
            processedText = WorkWithFuncsParams(processedText);
            processedText = WorkWithVarInit(processedText);
            processedText = WorkWithAssignments(processedText);////????
            processedText = WorkWithLocalVars(processedText);
            processedText = WorkWithFuncCall(processedText);
            processedText = WorkWithArrayAddWriteAndReadFunctions(processedText);

            return processedText;
        }

    }
}
