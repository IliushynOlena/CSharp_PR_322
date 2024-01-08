using System.Reflection.Metadata;
using System.Xml.Linq;

namespace _05_IntroToOOP
{
    //Access Spetifacators
    /*
    - private (default for field)
    - protected
    - public
    - protected internal
    - internal
     
     */
    class MyClass //: Object
    {
        //private
        private int number;
        private string name;
        private const float PI = 3.14f;
        private readonly int id;
        public MyClass()
        {
            id = 10;
            name = "MyClass";
        }
        //void SetId(int id) 
        //{ 
        //    this.id = id;
        //}
        public void Print()
        {
            Console.WriteLine($"Id : {id} Name {name}");
        }
        public override string ToString()
        {
            return $"Id : {id} Name {name}";
        }
    }
    partial class Point
    {
        private int number;
        //Auto-property   prop+Tab
        public string Name { get; set; }
        public string Type { get; }//readonly
                                   //=========
        //FULL- property
        //private string name;
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}
        //FULL- property
        private int _xCoord;
        public int XCoord//value
        {
            get
            {
                return _xCoord;
            }
            set
            {
                if (value >= 0)
                    this._xCoord = value;
                else
                    _xCoord = 0;
            }
        }
        //full property  propfull+Tab
        private int yCoord;
        public int YCoord
        {
            get { return yCoord; }
            set
            {
                if (value >= 0)
                    this.yCoord = value;
                else
                    yCoord = 0;
            }
        }
        public string Address { get; private set; } = "Soborna";

        static int count;
        static Point()
        {
            count = 0;
        }
        public static int getCount()
        {
            return count;
        }


    }
    //references type
    class DerivedClass : MyClass
    { }
    //value type 
    internal struct MyStruct
    {
        public int x;
        public int y;
        public void Print()
        {
            Console.WriteLine($"X : {x}. Y : {y}");
        }
    }
    internal class Program
    {        
        static void Main(string[] args)
        {
            //Console.SetCursorPosition(10, 10);
            Point p = new Point(5,9);  

            p.SetX(5);
            p.getX();
            p.XCoord = 5;//setter
            p.XCoord = 10;//setter
            int x = p.XCoord;//get
            p.Print();
            Console.WriteLine(p);
            p.SetX(10);
            p.SetY(21);
            Console.WriteLine(p);
            Console.WriteLine($"X = {p.getX()}"  );
            Console.WriteLine($"Y = {p.getY()}"  );
            //XCoord = value
            p.XCoord = 5; //setter
            int x = p.XCoord;//getter
            Console.WriteLine(x);//getter
            p.Name = "2D_Point";//setter
            Console.WriteLine(p.Name);//getter

            Console.WriteLine(Point.getCount());

            p.PrintWithSetPosition();

            //MyClass @class = new MyClass();
            //MyClass @int = new MyClass();
            //MyClass @float = new MyClass();

            // @class.Print();
            // Console.WriteLine(@class.ToString());
        }
    }
}


