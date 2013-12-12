using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
		public static int fr(int index) { return mas[index]; }
public static void fw(int index, string type, string data){switch(type){case "int": {mas[index] = Int32.Parse(data);break;}case "string": {for(int i=0;i<30; i++){mas[index + i] = -1;}int letterIndex=0;foreach(char letter in data){mas[index + letterIndex] = (int)letter;}break;}}}
public static int[] mas = { 234, 23, 232, 234, 1234, 12123, 22352, 12123, 22352, 123, 126, 119, 115, 101, 102, 115, 101, 102, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 119, 115, 101, 102, 115, 101, 102, 113, 119, 114, 113, 119, 114, 113, 119, 114, 113, 119, 101, 114, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 49, 50, 51, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 52, 53, 54, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 55, 56, 57, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0};
void A()
        { 
			fr(0);
			((char)fr(11)+(char)fr(12)+(char)fr(13)+(char)fr(14)+(char)fr(15)+(char)fr(16)+(char)fr(17)).ToString();
			((char)fr(41)+(char)fr(42)+(char)fr(43)+(char)fr(44)+(char)fr(45)+(char)fr(46)+(char)fr(47)+(char)fr(48)+(char)fr(49)+(char)fr(50)+(char)fr(51)+(char)fr(52)+(char)fr(53)+(char)fr(54)+(char)fr(55)+(char)fr(56)+(char)fr(57)+(char)fr(58)+(char)fr(59)+(char)fr(60)).ToString();
		}

        static void Main()
		{
			
			fw(161, "int", (fr(1)).ToString());
fw(162, "int", (fr(2)).ToString());
fw(163, "string", ((char)fr(71)+(char)fr(72)+(char)fr(73)).ToString());
A();

			fr(3);
			
			fw(223, "int", ( fr(4)).ToString());
			fw(161, "int", (fr(5)).ToString());
fw(162, "int", (fr(6)).ToString());
fw(163, "string", ((char)fr(101)+(char)fr(102)+(char)fr(103)).ToString());
A();

			fw(161, "int", (fr(7)).ToString());
fw(162, "int", (fr(8)).ToString());
fw(163, "string", ((char)fr(131)+(char)fr(132)+(char)fr(133)).ToString());
A();

			
			fw(224, "int", ( fr(9) + fr(10)).ToString());

		}
    }
}
