using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {  
		public static int fr(int index) { return mas[index]; }
public static void fw(int index, string type, string data){switch(type){case "int": {mas[index] = Int32.Parse(data);break;}case "string": {for(int i=0;i<70; i++){mas[index + i] = -1;}int letterIndex=0;foreach(char letter in data){mas[index + letterIndex] = (int)letter;}break;}}}
public static int[] mas = { 121, 111, 117, 114, 32, 110, 111, 114, 109, 97, 108, 32, 112, 101, 114, 115, 111, 110, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 72, 111, 119, 32, 111, 108, 100, 32, 97, 114, 101, 32, 121, 111, 117, 63, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 65, 114, 101, 32, 121, 111, 117, 32, 109, 97, 110, 32, 111, 114, 32, 119, 111, 109, 97, 110, 63, 58, 32, 121, 45, 121, 101, 115, 32, 47, 32, 110, 45, 110, 111, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 65, 114, 101, 32, 121, 111, 117, 32, 101, 97, 116, 32, 102, 111, 111, 100, 63, 58, 32, 121, 45, 121, 101, 115, 32, 47, 32, 110, 45, 110, 111, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0};
static  void AnalizePerson()
            {

                Console.WriteLine(((char)fr(0)+(char)fr(1)+(char)fr(2)+(char)fr(3)+(char)fr(4)+(char)fr(5)+(char)fr(6)+(char)fr(7)+(char)fr(8)+(char)fr(9)+(char)fr(10)+(char)fr(11)+(char)fr(12)+(char)fr(13)+(char)fr(14)+(char)fr(15)+(char)fr(16)+(char)fr(17)+(char)fr(18)).ToString());
            }

            else
            {
                if ((age1 >= 0) && (age1 <= 120) && (sex1 == "n") && (food1 == "y"))
                {
                    Console.WriteLine("your sex is undefine");
                }
                else
                {
                    if ((age1 >= 0) && (age1 <= 120) && (sex1 == "y") && (food1 == "n"))
                    {
                        Console.WriteLine("your are normal, but your sex is unusual");
                    }
                    else
                    {
                        Console.WriteLine("your dates is uncorrect");
                    }
                }
            }
        }



        static void Main()
        {


            
            

            

            
            
            Console.WriteLine(((char)fr(70)+(char)fr(71)+(char)fr(72)+(char)fr(73)+(char)fr(74)+(char)fr(75)+(char)fr(76)+(char)fr(77)+(char)fr(78)+(char)fr(79)+(char)fr(80)+(char)fr(81)+(char)fr(82)+(char)fr(83)+(char)fr(84)+(char)fr(85)).ToString());
            fw(562, "string",  Console.ReadLine());
            fw(421, "int", ( Convert.ToInt32(((char)fr(562)).ToString())).ToString());
            Console.WriteLine(((char)fr(140)+(char)fr(141)+(char)fr(142)+(char)fr(143)+(char)fr(144)+(char)fr(145)+(char)fr(146)+(char)fr(147)+(char)fr(148)+(char)fr(149)+(char)fr(150)+(char)fr(151)+(char)fr(152)+(char)fr(153)+(char)fr(154)+(char)fr(155)+(char)fr(156)+(char)fr(157)+(char)fr(158)+(char)fr(159)+(char)fr(160)+(char)fr(161)+(char)fr(162)+(char)fr(163)+(char)fr(164)+(char)fr(165)+(char)fr(166)+(char)fr(167)+(char)fr(168)+(char)fr(169)+(char)fr(170)+(char)fr(171)+(char)fr(172)+(char)fr(173)+(char)fr(174)).ToString());
            fw(422, "string",  Console.ReadLine());
            Console.WriteLine(((char)fr(210)+(char)fr(211)+(char)fr(212)+(char)fr(213)+(char)fr(214)+(char)fr(215)+(char)fr(216)+(char)fr(217)+(char)fr(218)+(char)fr(219)+(char)fr(220)+(char)fr(221)+(char)fr(222)+(char)fr(223)+(char)fr(224)+(char)fr(225)+(char)fr(226)+(char)fr(227)+(char)fr(228)+(char)fr(229)+(char)fr(230)+(char)fr(231)+(char)fr(232)+(char)fr(233)+(char)fr(234)+(char)fr(235)+(char)fr(236)+(char)fr(237)+(char)fr(238)+(char)fr(239)+(char)fr(240)+(char)fr(241)).ToString());
            fw(492, "string",  Console.ReadLine());

            fw(280, "int", (fr(421)).ToString());
fw(281, "string", ((char)fr(422)).ToString());
fw(351, "string", ((char)fr(492)).ToString());
AnalizePerson();


        }
    }
}

