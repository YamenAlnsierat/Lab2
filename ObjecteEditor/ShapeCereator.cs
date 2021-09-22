using System;
using System.Numerics;
using Geometric_Library;

namespace ShapeCereator
{
    class ShapeCereator
    {
        static void Main(string[] args)
        {
            //Circle myC = new Circle(new Vector2(4,5), 3);
            //Console.WriteLine(myC.Circumference);
            //Console.WriteLine(myC.ToString());

            //Rectangle myR = new Rectangle(new Vector2(3, 4),new Vector2(3,4));
            //Console.WriteLine(myR.Circumference);
            //Console.WriteLine(myR.Area);
            //Console.WriteLine(myR);

            //Cuboid myCu = new Cuboid(new Vector3(4, 2, 6), new Vector3(4,3,4));
            //Console.WriteLine(myCu.Volume);
            //Console.WriteLine(myCu.Area);
            //Console.WriteLine(myCu);

            Sphere myS = new Sphere(new Vector3(3, 4, 6), 5);
            Console.WriteLine(myS.Area);
            Console.WriteLine(myS.Volume);
            Console.WriteLine(myS);
        }
    }
}
