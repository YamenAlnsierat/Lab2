using System;
using System.Numerics;


namespace Geometric_Library
{

    public abstract class Shape
    {
        private static float x, y, z, width, length, height, radius;

        public abstract Vector3 Center { get; }
        public abstract float Area { get; }


        public static Shape GenerateShape()
        {

            Random random = new Random();
            x = (float)random.NextDouble() * 10;
            y = (float)random.NextDouble() * 10;
            z = (float)random.NextDouble() * 10;


            Random random1 = new Random();
            int number = random1.Next(0, 6);
            switch (number)
            {
                case 0:
                    radius = (float)random.NextDouble() * 10;
                    return new Circle(new Vector2(x, y), radius);

                case 1:
                    width = (float)random.NextDouble() * 10;
                    return new Rectangle(new Vector2(x, y), width);

                case 2:
                    width = (float)random.NextDouble() * 10;
                    length = (float)random.NextDouble() * 10;
                    return new Rectangle(new Vector2(x, y), new Vector2(length, width));

                case 3:
                    width = (float)random.NextDouble() * 10;
                    return new Cuboid(new Vector3(x, y, z), width);

                case 4:
                    width = (float)random.NextDouble() * 10;
                    length = (float)random.NextDouble() * 10;
                    height = (float)random.NextDouble() * 10;
                    return new Cuboid(new Vector3(x, y, z), new Vector3(height, length, width));

                case 5:
                    radius = (float)random.NextDouble() * 10;
                    return new Sphere(new Vector3(x, y, z), radius);

                default: return null;
            }            
        }
    }

    public abstract class Shape2d : Shape
    {
        public Vector2 center;

        public abstract float Circumference { get; }
    }
    public abstract class Shape3d : Shape
    {
        public Vector3 center;

        public abstract float Volume { get; }
    }


    public class Circle : Shape2d
    {
        private float radius;

        public override Vector3 Center
        {
            get
            {
                return new Vector3(center,0);
            }
        }
        public override float Area
        {
            get
            {
                return radius * radius * MathF.PI;
            }
        }
        public override float Circumference
        {
            get
            {
                return radius * MathF.Pow(MathF.PI,2);
            }
        }

        public Circle(Vector2 center, float radius)
        {
            this.radius = radius;
            this.center = center;
        }

        public override string ToString()
        {
            return $"Circle ({center.X:N2}, {center.Y:N2}): r = {radius:N4}";
        }
    }


   public class Rectangle : Shape2d
    {
        private Vector2 size;
        private float width;
        private float length;

        public override Vector3 Center
        {
            get
            {
                return new Vector3(center, 0);
            }
        }
        public override float Area
        {
            get
            {
                return width * length;
            }
        }
        public override float Circumference
        {
            get
            {
                return 2 * (width * length);
            }
        }
        public bool IsSquare 
        {
            get 
            {
                return (length == width);
            } 
        }

        public Rectangle(Vector2 center, Vector2 size)
        {
            this.center = center;
            width = size.X;
            length = size.Y;
        }
        public Rectangle (Vector2 center, float width)
        {
            this.center = center;
            this.width = width;
            length = width;
        }

        public override string ToString()
        {
            if (IsSquare)
            {
                return $"Square ({center.X:N2}, {center.Y:N2}), W = {width:N4}, L = {length:N4}";
            }
            else
            {
                return $"Rectangle ({center.X:N2}, {center.Y:N2}), W = {width:N4}, L = {length:N4}";
            }
        }
    }


   public class Triangle : Shape2d
    {
        private Vector2 p1,  p2 , p3;

        public override Vector3 Center
        {
            get
            {
                return new Vector3(center, 0);
            }
        }
        public override float Area
        {
            get
            {
                return Area;
            }
        }
        public override float Circumference => throw new NotImplementedException();

        public Triangle(Vector2 center, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.center = center;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }
    }


   public class Cuboid : Shape3d
    {
        private float width;
        private float length;
        private float height;
        public override Vector3 Center
        {
            get
            {
                return new Vector3(center.X,center.Y,center.Z);
            }
        }
        public override float Area
        {
            get
            {
                return 2 * (length * width) + 2 * (height * length) + 2 * (width * height);
            }
        }
        public override float Volume
        {
            get
            {
                return width * length * height;
            }
        }
        public bool IsCube 
        {
            get 
            {
                return (length == height && length == width);                
            }
        }

        public Cuboid (Vector3 center, Vector3 size)
        {
            this.center = center;
            width = size.X;
            length = size.Y;
            height = size.Z;

        }
        public Cuboid(Vector3 center, float width)
        {
            this.center = center;
            this.width = width;
            height = width;
            length = width;
        }

        public override string ToString()
        {
            if (IsCube)
            {
                return $"Cube ({center.X:N2}, {center.Y:N2}, {center.Z:N2}): W = {width:N4}, L = {length:N4}, H = {height:N4}";
            }
            else
            {
                return $"Cuboid ({center.X:N2}, {center.Y:N2}, {center.Z:N2}): W = {width:N4}, L = {length:N4}, H = {height:N4}";
            }
        }
    }


   public class Sphere : Shape3d
    {
        private float radius;
        public override Vector3 Center
        {
            get
            {
                return new Vector3(center.X, center.Y, center.Z);
            }
        }
        public override float Area
        {
            get
            {
                return (4 * MathF.PI) * (MathF.Pow(radius, 2));
            }
        }
        public override float Volume
        {
            get
            {
                return (1.33f * MathF.PI) * (MathF.Pow(radius,3));
            }
        }

        public Sphere(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override string ToString()
        {
            return $"Sphere ({center.X:N2}, {center.Y:N2}, {center.Z:N2}): r = {radius:N4}";
        }
    }
}
