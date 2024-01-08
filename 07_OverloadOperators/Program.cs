using System.Runtime.CompilerServices;

namespace _07_OverloadOperators
{
    class Point_3D// Base class Object
    {
        public int X { get; set; }//private int x;
        public int Y { get; set; }//private int x;
        public int Z { get; set; }//private int x;
        public Point_3D(): this(0,0,0){}
        public Point_3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"X : {X} . Y : {Y} . Z : {Z}";

        }
    }
    class Point_2D// Base class Object
    {
        public int X { get; set; }//private int x;
        public int Y { get; set; }//private int x;
        public Point_2D() : this(0, 0) { }
        public Point_2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Print()
        {
            Console.WriteLine($"X : {X} . Y : {Y}");
           
        }
        //override method
        public override string ToString()
        {
            return $"X : {X} . Y : {Y}";
          
        }
        public override bool Equals(object? obj)
        {
            return obj is Point_2D d &&
                   this.X == d.X &&
                   this.Y == d.Y;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        //ref and out not allow
        // public static return_type operator[symbol](parameters){}
        #region Унарні оператори
        // - (-5), 6++, 8--
        public static Point_2D operator-(Point_2D point)
        {
            Point_2D p = new Point_2D 
            { 
                 X = point.X*-1,
                 Y = point.Y*-1
            };
            return p;
        }
        public static Point_2D operator ++(Point_2D point)
        {
           point.X++;
           point.Y++;
           return point;            
        }
        public static Point_2D operator --(Point_2D point)
        {
            point.X--;
            point.Y--;
            return point;
        }
        #endregion
        #region Binary Operators
        public static Point_2D operator +(Point_2D p1, Point_2D p2)
        {
            Point_2D point = new Point_2D
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
            return point;
        }
        public static Point_2D operator -(Point_2D p1, Point_2D p2)
        {
            Point_2D point = new Point_2D
            {
                X = p1.X- p2.X,
                Y = p1.Y - p2.Y
            };
            return point;
        }
        public static Point_2D operator *(Point_2D p1, Point_2D p2)
        {
            Point_2D point = new Point_2D
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return point;
        }
        public static Point_2D operator /(Point_2D p1, Point_2D p2)
        {
            Point_2D point = new Point_2D
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };
            return point;
        }
        #endregion
        #region Оператори порівняння
        public static bool operator ==(Point_2D p1, Point_2D p2)
        {
            //if ((p1.X == p2.X) && (p1.Y == p2.Y))
            //    return true;
            //else
            //    return false;
            //return (p1.X == p2.X) && (p1.Y == p2.Y);
            return p1.Equals(p2);
        }
        //in pair
        public static bool operator !=(Point_2D p1, Point_2D p2)
        {
            return !(p1==p2);
        }
        #endregion
        #region Логічні оператори
        public static bool operator >(Point_2D p1, Point_2D p2)
        {
            return p1.X+ p1.Y > p2.X + p2.Y;
        }
        //in pair
        public static bool operator <(Point_2D p1, Point_2D p2)
        {
            return !(p1 > p2);
        }
        public static bool operator >=(Point_2D p1, Point_2D p2)
        {
            return p1.X + p1.Y >= p2.X + p2.Y;
        }
        //in pair
        public static bool operator <=(Point_2D p1, Point_2D p2)
        {
            return !(p1 >= p2);
        }
        #endregion
        #region true/false operator
        public static bool operator true(Point_2D p)
        {
            return p.X != 0 ||  p.Y != 0;
        }
        //in pair
        public static bool operator false(Point_2D p)
        {
            return p.X == 0 || p.Y == 0;
        }

        #endregion
        #region Overload types
        public static implicit operator int(Point_2D p)
        {
            return p.X + p.Y;
        }
        public static implicit operator double(Point_2D p)
        {
            return p.X + p.Y;
        }
        public static explicit operator Point_3D(Point_2D p)
        {
            return new Point_3D(p.X, p.Y, 0);
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            double b = 3.7;

            b = a;//implicit  5.00000000000000000  int => double
            a = (int) b;//explicit double => int  5
            Point_2D test = new Point_2D(2, 2);

            a = test;//Point_2D => int
            Console.WriteLine($"Point_2D => int : {a}");
            b = test;//Point_2D => double
            Console.WriteLine($"Point_2D => double : {b}");
            Point_3D newPoint = (Point_3D)test;//Point_2D => Point_3D
            Console.WriteLine($"Point_2D => Point_3D : {newPoint}");


            //object
            string str = "Hello";
            string str2 = "Hello";
            if (str.Equals(str2))
            {
                Console.WriteLine("Object is equals");
            }
            else
            {
                Console.WriteLine("Object is not equals");
            }



            Console.WriteLine("Hello, World!");
            Point_2D point = new Point_2D(0,0);
            Point_2D point2 = new Point_2D(3,5);
            if (point == point2)
            {
                Console.WriteLine("Point is equals");
            }
            else
            {
                Console.WriteLine("Point is not equals");
            }
            if (point)
            {
                Console.WriteLine("Point is true");
            }
            else
            {
                Console.WriteLine("Point is false");
            }
            if (point > point2)
            {
                Console.WriteLine("Point 1 is more than point 2");
            }
            else
            {
                Console.WriteLine("Point 1 is not more than point 2");
            }
            point.Print();
            Console.WriteLine($"Original point {point}" );

            Point_2D res = -point;
            Console.WriteLine($"Point 1 : {res}");
            Console.WriteLine($"Increment {point++}");
            Console.WriteLine($"Increment {++point}");
            Console.WriteLine($"Decrement {point--}");
            Console.WriteLine($"Decrement {--point}");

            res = point + point2;
            Console.WriteLine($"Plus point {res}");
            res = point - point2;
            Console.WriteLine($"Minus point {res}");
            res = point * point2;
            Console.WriteLine($"Multi point {res}");
            res = point / point2;
            Console.WriteLine($"Divide point {res}");

        }
    }
}
