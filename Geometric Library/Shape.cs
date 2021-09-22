using System;
using System.Numerics;


namespace Geometric_Library
{
    public abstract class Shape
    {

        public abstract Vector3 Center { get; }
        public abstract float Area { get; }


        public static Shape GenerateShape()
        {
            Shape[] Geometry = {};
            Random slump = new Random();
            return Shape.GenerateShape();
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
            return $"Circle @({center.X}, {center.Y}): r = {radius}";
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
                return $"Square ({center.X},{center.Y}), W = {width}, L = {length}";
            }
            else
            {
                return $"Rectangle ({center.X},{center.Y}), W = {width}, L = {length}";
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
                return $"Cube ({center.X},{center.Y}), W = {width}, L = {length}, H = {height}";
            }
            else
            {
                return $"Cuboid ({center.X},{center.Y}), W = {width}, L = {length}, H = {height}";
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
            return $"Sphere @({center.X}, {center.Y}, {center.Z}): r = {radius}";
        }
    }
}
