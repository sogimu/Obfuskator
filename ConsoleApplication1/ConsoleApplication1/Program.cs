using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void AnalizePerson(int age1, string sex1, string food1)
        {
            if ((age1 >= 0) && (age1 <= 120) && (sex1 == "y") && (food1 == "y"))


                Console.WriteLine("your normal person ");


            else

                if ((age1 >= 0) && (age1 <= 120) && (sex1 == "n") && (food1 == "y"))

                    Console.WriteLine("your sex is undefine");

                else

                    if ((age1 >= 0) && (age1 <= 120) && (sex1 == "y") && (food1 == "n"))

                        Console.WriteLine("your are normal, but your sex is unusual");

                    else

                        Console.WriteLine("your dates is uncorrect");


        }



        static void Main()
        {


            int age;
            string sex;

            string food;

            string tmp;

            Console.WriteLine("How old are you");
            tmp = Console.ReadLine();
            age = Convert.ToInt32(tmp);
            Console.WriteLine("Are you man or woman?: y-yes / n-no");
            sex = Console.ReadLine();
            Console.WriteLine("Are you eat food?: y-yes / n-no ");
            food = Console.ReadLine();

            AnalizePerson(age, sex, food);
            Console.ReadKey();
        }
    }
}

