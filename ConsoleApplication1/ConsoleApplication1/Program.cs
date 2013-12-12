using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
	

       static  void AnalizePerson(int age1, string derivate, string arithemOpr, string sinRes )
        {
             if (age1 <= 14)
             {
                 if (arithemOpr == "n")
                 {

                     Console.WriteLine("your knowledges of mathematics is corresponded for your age ");
                 }
                 else 
                 {

                     Console.WriteLine("your knowledges of mathematics is not corresponded for your age ");
                     
                 }
             }
             else
             {
                 int baseCount;
                 baseCount = 0;
                 if ((arithemOpr == "n") || (sinRes == "y"))
                 {
                     baseCount = 1;

                     if ((baseCount == 1) && (derivate == "y") && (age1 <= 14))
                     {

                         Console.WriteLine("your knowledges of mathematics more then corresponded for your age ");
                     }


                     Console.WriteLine("your knowledges of mathematics is corresponded for your age ");
                 }
                 else
                 {

                     Console.WriteLine("your knowledges of mathematics is not corresponded for your age ");
                 }
             }
        }
      

 
        static void Main(string[] args)
     {


         int age;
         string derivate;

         string arithemOpr;
         string sinRes;


         Console.WriteLine("Your age?");
           

         string age1;
         age1= Console.ReadLine();
         try
         {
             age = Convert.ToInt32(age1);

        if (age >= 10)
        {

            do
            {
                Console.WriteLine("2*3-1*3*(4:2)=0 ?(y/n)");
                arithemOpr = Console.ReadLine();
            }
            while (!((arithemOpr == "y") || (arithemOpr == "n")));
            do
            {
                Console.WriteLine("(2X+1)'=2 ?(y/n)");
                derivate = Console.ReadLine();
            }
            while (!((derivate == "y") || (derivate == "n")));
            do
            {
                Console.WriteLine("sin2x =2sinxcosx ?(y/n)");
                sinRes = Console.ReadLine();
            }
            while (!((sinRes == "y") || (sinRes == "n")));

            {
               // Console.Clear();
               AnalizePerson(age, derivate, arithemOpr, sinRes);
            }

        }
             else
             {

                 Console.WriteLine("Your's age is not sootv by this test");

             }

         }
         catch (FormatException )
         {
             Console.WriteLine("unformat dates"); 
         }

     }
    }
}
