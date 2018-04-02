using System;
using System.Text;
using B18_Ex01_2;

namespace B18_Ex01_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            B18_Ex01_2.Program.PrintHourglass(4);
            Console.WriteLine();
            B18_Ex01_2.Program.PrintHourglass(5);
            Console.WriteLine();
            B18_Ex01_2.Program.PrintHourglass(7);
            Console.WriteLine();
            B18_Ex01_2.Program.PrintHourglass(8);
            Console.WriteLine(@"
Press Any Key to Exit...");
            Console.ReadKey();
        }
    }
}
