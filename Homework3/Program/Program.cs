using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    //抽象产品类
    public abstract class Shape
    {
        public abstract void Draw();
        public abstract double Area
        {
            get;
        }
    }

    //三角形类
    public class Triangle : Shape
    {
        private int mySide_1, mySide_2, mySide_3;
        public Triangle(int side_1, int side_2, int side_3)
        {
            mySide_1 = side_1;
            mySide_2 = side_2;
            mySide_3 = side_3;
        }
        public override void Draw()
        {
            Console.WriteLine("Draw a triangle!");
        }
        public override double Area
        {
            get
            {
                int p = (mySide_1 + mySide_2 + mySide_3) / 2;
                double S = System.Math.Sqrt(p * (p - mySide_1) * (p - mySide_2) * (p - mySide_3));
                return S;
            }
        }
    }

    //圆形
    public class Circle : Shape
    {
        private int myRadius;
        public Circle(int radius)
        {
            myRadius = radius;
        }
        public override void Draw()
        {
            Console.WriteLine("Draw a circle!");
        }
        public override double Area
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }
    }

    //正方形
    public class Square : Shape
    {
        private int mySide;
        public Square(int side)
        {
            mySide = side;
        }
        public override void Draw()
        {
            Console.WriteLine("Draw a square!");
        }
        public override double Area
        {
            get
            {
                return mySide * mySide;
            }
        }
    }

    //矩形类
    public class Rectangle : Shape
    {
        private int myWidth, myHeight;
        public Rectangle(int width, int height)
        {
            myWidth = width;
            myHeight = height;
        }
        public override void Draw()
        {
            Console.WriteLine("Draw a rectangle!");
        }
        public override double Area
        {
            get
            {
                return myWidth * myHeight;
            }
        }
    }

    //工厂类
    public class ShapeFactory
    {
        public static Shape GetShape(String type)
        {
            Shape shape = null;
            if(type.Equals("TRIANGLE"))
            {
                int a, b, c;
                Console.WriteLine("Please enter three sides : ");
                a = Int32.Parse(Console.ReadLine());
                b = Int32.Parse(Console.ReadLine());
                c = Int32.Parse(Console.ReadLine());
                shape = new Triangle(a,b,c);
            }
            else if (type.Equals("CIRCLE"))
            {
                int a;
                Console.WriteLine("Please enter the radius : ");
                a = Int32.Parse(Console.ReadLine());
                shape = new Circle(a);
            }
            else if (type.Equals("SQUARE"))
            {
                int a;
                Console.WriteLine("Please enter the side : ");
                a = Int32.Parse(Console.ReadLine());
                shape = new Square(a);
            }
            else if (type.Equals("RECTANGLE"))
            {
                int a, b;
                Console.WriteLine("Please enter width and height : ");
                a = Int32.Parse(Console.ReadLine());
                b = Int32.Parse(Console.ReadLine());
                shape = new Rectangle(a, b);
            }
            return shape;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape shape_1;
            shape_1 = ShapeFactory.GetShape("TRIANGLE");
            shape_1.Draw();
            Console.WriteLine("The area is : " + shape_1.Area);
            Shape shape_2;
            shape_2 = ShapeFactory.GetShape("CIRCLE");
            shape_2.Draw();
            Console.WriteLine("The area is : " + shape_2.Area);
            Shape shape_3;
            shape_3 = ShapeFactory.GetShape("SQUARE");
            shape_3.Draw();
            Console.WriteLine("The area is : " + shape_3.Area);
            Shape shape_4;
            shape_4 = ShapeFactory.GetShape("RECTANGLE");
            shape_4.Draw();
            Console.WriteLine("The area is : " + shape_4.Area);
        }
    }
}
