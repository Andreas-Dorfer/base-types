using AD.BaseTypes;
using System;

namespace TestApp
{
    [Int] partial record MyInt;
    [MaxLength(4)] partial record MyText;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
