using System;
using System.Numerics;
using Geometric_Library;

namespace ShapeCereator
{
    class ShapeCereator
    {
        static void Main(string[] args)
        {
            float totArea = 0;
            Console.WriteLine("Here is a list with 20 random Shapes with their area and the sum of it:\n\n");

            Shape[] shapes = new Shape[20];
            for (int i = 0; i < shapes.Length; i++)
            {
                shapes[i] = Shape.GenerateShape();
                totArea += shapes[i].Area;
                Console.WriteLine(shapes[i]);
                Console.WriteLine($"Area: {shapes[i].Area:N2} cm");
                Console.WriteLine("________________________");
            }
            Console.WriteLine($"\nTotal area of all shapes together is: {totArea:N2} cm\n");

        }
    }
}
