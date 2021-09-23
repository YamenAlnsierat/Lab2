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
            Random rand = new Random();
            for (int i = 0; i < 7; i++)
            {
                double min = 1;
                double max = 10;
                double range = max - min;
                double sample = rand.NextDouble();
                double scaled = (sample * range) + min;
                x = MathF.Round((float)rand.NextDouble() * 10);
                y = MathF.Round((float)rand.NextDouble() * 10);
                z = MathF.Round((float)rand.NextDouble() * 10);
                width = (float)scaled;
                length = (float)scaled;
                height = (float)scaled;
                radius = (float)scaled;
            }

            Shape[] shapes = new Shape[6];
            shapes[0] = new Circle(new Vector2(x, y), radius);
            shapes[1] = new Rectangle(new Vector2(x, y), width);
            shapes[2] = new Rectangle(new Vector2(x, y), new Vector2(length, width));
            shapes[3] = new Cuboid(new Vector3(x, y, z), width);
            shapes[4] = new Cuboid(new Vector3(x, y, z), new Vector3(height, length, width));
            shapes[5] = new Sphere(new Vector3(x, y, z), radius);

            Random random = new Random();
            int number = random.Next(0, 5);
            return shapes[number];
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
                return (radius * radius) * MathF.PI;
            }
        }
        public override float Circumference
        {
            get
            {
                return radius * (MathF.Pow(MathF.PI,2));
            }
        }

        public Circle(Vector2 center, float radius)
        {
            this.radius = radius;
            this.center = center;
        }

        public override string ToString()
        {
            return $"Circle ({center.X}, {center.Y}): r = {radius:N4}";
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
                if (length == width)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                return $"Square ({center.X}, {center.Y}), W = {width:N4}, L = {length:N4}";
            }
            else
            {
                return $"Rectangle ({center.X}, {center.Y}), W = {width:N4}, L = {length:N4}";
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
                return 2 * width + 2 * length + 2 * height;
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
                if (length == height && length == width)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                return $"Cube ({center.X}, {center.Y}), W = {width:N4}, L = {length:N4}, H = {height:N4}";
            }
            else
            {
                return $"Cuboid ({center.X}, {center.Y}), W = {width:N4}, L = {length:N4}, H = {height:N4}";
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
            return $"Sphere ({center.X}, {center.Y}, {center.Z}): r = {radius:N4}";
        }
    }
}
