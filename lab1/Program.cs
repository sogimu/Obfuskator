using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace lab1
{
    class Program
    {

        public void A()
        {

        }
        public static string GetObfuscationText(string text)
        {
            string processedText;
            Obfuscator obfuscator = new Obfuscator();
            processedText = obfuscator.Make(text);
            /*
            VarsTable table = new VarsTable();
            TextOfProgram allText = new TextOfProgram(text);
            
            Func func;
            while ((func = allText.GetNextFunc()) != null)
            {
                TextOfProgram textOfFunc = new TextOfProgram(func.GetBody());
   
                VarInit var;
                while ((var = textOfFunc.GetNextVarInit()) != null)
                {
                    table.AddVar(var.GetItemForVar());
                       
                }

                StringConst stringConst;
                while ((stringConst = textOfFunc.GetNextStringConst()) != null)
                {
                    table.AddVar(stringConst.GetItemForVar());


                }

                IntConst intConst;
                while ((intConst = textOfFunc.GetNextIntConst()) != null)
                {
                    ItemForVar item = intConst.GetItemForVar();
                    //item.SetView(func.GetName());
                    table.AddVar(item);

                }

            }
               
                */
            return processedText;
        }

        //private static int[] mas = new int[100];// массив для хранения
        [STAThread]
        static void Main(string[] args)
        {
            //string mode;
            int count = args.Count(); 
          /*  if (count == 0)
            {
                Console.Write("Выберите режим [0-обфускация, 1-деобфускация]: ");
                mode = Console.ReadLine();
            }
            else
            {
                mode = args[0];//если с коммандной строки выбираем комманду
            }*/


            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = ".cs|*.cs|All Files (*.*)|*.*";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".cs|*.cs|All Files (*.*)|*.*";




            StreamReader finput = null;

            /*if (count > 1)
            {
                if (File.Exists(args[1]))
                    finput = new StreamReader(args[1]);
            }
            else
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(fileDialog.FileName))*/
            finput = new StreamReader(/*fileDialog.FileName*/"input_program.cs");
                /*}
                else
                {
                    Application.Exit();
                }
            }*/
            string str = finput.ReadToEnd();////////trreteryrehtehtehteh
            string result = null;

          /*  if (mode == "0")
            {*/
               result = GetObfuscationText(str);
          
           /* }else{
                //result = deobfuscation(str);

                result = "oops";
            }

            if (count > 2)
            {
                File.WriteAllText(args[2], result);
            }
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {*/
               File.WriteAllText(/*saveFileDialog.FileName*/"C:\\Users\\kira\\Documents\\Visual Studio 2010\\Projects\\ConsoleApplication1\\ConsoleApplication1\\Program.cs", result);
             /*   }
            }
            Console.WriteLine("Ok");*/

        }

        }  
    }


