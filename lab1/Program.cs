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
        public static string GetObfuscationText(string text)
        {
            string processedText;
            Obfuscator obfuscator = new Obfuscator();
            processedText = obfuscator.Make(text);

            return processedText;
        }

        [STAThread]
        static void Main(string[] args)
        {



            string mode;
            Console.Write("Введите : 0 - для обфускации; 1 - для выхода ");
            mode = Console.ReadLine();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = ".cs|*.cs|All Files (*.*)|*.*";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".cs|*.cs|All Files (*.*)|*.*";

            StreamReader finput = null;


            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                    finput = new StreamReader(fileDialog.FileName/*"input_program.cs"*/);
            }
            else
            {
                Application.Exit();
            }

            string str = finput.ReadToEnd();////////trreteryrehtehtehteh
            string result = null;

            if (mode == "0")
            {
                
                result = GetObfuscationText(str);

            }
            else
            {


                Application.Exit();
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            
            {
                File.WriteAllText(saveFileDialog.FileName/*"C:\\Users\\kira\\Documents\\Visual Studio 2010\\Projects\\ConsoleApplication1\\ConsoleApplication1\\Program.cs"*/, result);
            }

            Console.WriteLine("Ok");

        }


    }
}


