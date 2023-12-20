namespace _06_StructClass
{
    //using _2D_Objects;

    partial class Point
    {
        //auto-prop
        //public int X { get; set; }//property
        //as =======
        //full-prop
        private int x;

        public int X
        {
            get { return x; }
            set 
            {
                if(value > 0)
                    x = value;
                else
                    throw new Exception("Incorrect X");
            
            }
        }


    }
    partial class Point
    {
        public int Y { get; set; }
        public override string ToString()
        {
            return $"X = {X}. Y = {Y}";
        }
    }
    struct Time//internal
    {
        public int H { get; set; }
        public int M { get; set; }
        public Time(int h, int m)
        {
            H = h;
            M = m;
        }
    }

    internal class Program
    {
        static void MethodWithParams(string name, int countLesson, params int[] marks)
        {
            Console.WriteLine($"-------------{name}------------");
            Console.WriteLine($"-------------{countLesson}------------");
            foreach (var item in marks)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Modify(ref int num,ref string str,ref Point point)
        {
            //ref == &
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            Console.WriteLine($"Point : {point}");
            Console.WriteLine("--------------------------");
            num += 1;
            str += "!";
            point.X++;
            point.Y++;
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            Console.WriteLine($"Point : {point}");
            Console.WriteLine("--------------------------");

        }
        static void GetCurrentTime(out int hour,out int minute,out int second)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
            //Console.WriteLine($"{hour}:{minute}:{second}");


        }
        static void Main(string[] args)
        {
            int h, m , s;
            //Console.WriteLine($"{h}:{m}:{s}");
            GetCurrentTime(out h, out m,out s);
            Console.WriteLine($"{h}:{m}:{s}");


            //int[] marks = { 11, 12, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            //MethodWithParams("Bob", marks);
            //MethodWithParams("Bob", new int[] { 11, 12, 12, 11, 12, 12 });
            //MethodWithParams("Bob", 11, 12, 12, 11, 12, 12,7,8,9,6,12,10);
            int num = 10;
            string str = "Hello academy ";
            Point point = new Point() { X = 5, Y = 8 };
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            Console.WriteLine($"Point : {point}");
            Console.WriteLine($"Size = {str.Length}");
            Console.WriteLine("--------------------------");
            Modify(ref num,ref str,ref point);
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            Console.WriteLine($"Point : {point}");
            Console.WriteLine("--------------------------");

            //reference type
            Point pointClass = new Point();//new - create new memory

            //value type
            Time time = new Time();//invoke default constructor
            int a;//4b empty
            Point p;//empty reference = null

            //_3D_Objects.Point point3 = new _3D_Objects.Point(); 

            Point[] points = new Point[5];
            for (int i = 0; i < points.Length; i++)
            {

                points[i] = new Point();
                try
                {
                    points[i].X = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); 
                }
                
            }



        }
    }
}
namespace _2D_Objects
{
    struct Point//internal
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }  

}
namespace _3D_Objects
{
    struct Point//internal
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

}
