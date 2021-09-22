using System;
using System.Numerics;
using Geometric_Library;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle myC = new Circle(Vector2.UnitX, 4f);
            Console.WriteLine(myC.Area);
        }
    }
}
