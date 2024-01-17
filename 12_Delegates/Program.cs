namespace _12_Delegates
{
    //class VoidDelegate : MulticastDelegate// Delegate
    //{
    //void Print()
    //{ }

    //}

    //public delegate void VoidDelegate();
    delegate int IntDelegate(int i);

    public delegate void SetStringDelegate(string s);
    public delegate double DoubleDelegate();
    public delegate void VoidDelegate();
    public class SupersClass
    {
        public void Print(string str)
        {
            Console.WriteLine("String : " + str);
        }
        public static double GetKoef()
        {
            double res = new Random().NextDouble();//0....1
            return res;
        }
        public double GetNumber()
        {
           return  new Random().Next();//-2147483685 + 
        }
        public void DoWork()
        {
            Console.WriteLine("Doing work.....");
        }
        public void Test()
        {
            Console.WriteLine("Testing .....");
        }
    }
    public delegate double CalcDelegate(double x, double y);
    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Multi(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if (y != 0)
            {
                return x / y;
            }
            throw new DivideByZeroException();
        }
    }
    public delegate int ChangeDelegate(int value);
    internal class Program
    {
        public static void DoOperation(double a, double b, CalcDelegate oper)
        {
            //count(arr);
            Console.WriteLine(oper?.Invoke(a, b));
        }
        static void ChangeElement(int[]arr, ChangeDelegate change )
        {
            for (int i = 0; i < arr.Length; i++)
            {
              arr[i] =  change.Invoke(arr[i]);
            }
        }
        static int Sqr(int value)
        {
            return value * value;
        }
        static int Increment(int value)
        {
            return ++value;
        }
        static int Decrement(int value)
        {
            return --value;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 8, 4, 9, 6, 3, 11, 47 };
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine();
            ChangeElement(arr, Sqr);
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine();
            ChangeElement(arr, Increment);
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine();
            ChangeElement(arr, Decrement);
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine();
            ChangeElement(arr, delegate(int v) { return v * v; });
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine();

            ChangeElement(arr, (v) => {return v * v; });
            ChangeElement(arr, (v) =>  v * v);




            //Calculator calculator = new Calculator();

            //CalcDelegate calcDelegate2 = calculator.Add;
            //calcDelegate2 += calculator.Sub;
            //calcDelegate2 += calculator.Multi;
            //calcDelegate2 += calculator.Div;
            //calcDelegate2 -= calculator.Div;

            //foreach (var item in calcDelegate2!.GetInvocationList())
            //{
            //    Console.WriteLine("Result = " + ((CalcDelegate)item)?.Invoke(154, 45));
            //}

            //DoOperation(100, 2, calculator.Add);
            //DoOperation(48, 4, calculator.Sub);
            //DoOperation(15, 6, calculator.Multi);
            //DoOperation(128, 22, calculator.Div);
            /*
            double x, y;
            int key;
            do
            {
                Console.WriteLine("Enter first number : ");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter first number : ");
                y = double.Parse(Console.ReadLine());
                Console.WriteLine("Add - 1 ");
                Console.WriteLine("Sub - 2 ");
                Console.WriteLine("Multy - 3 ");
                Console.WriteLine("Div - 4 ");
                Console.WriteLine("Exit - 0 ");
                key = int.Parse(Console.ReadLine());
                CalcDelegate calcDelegate = null;
                switch (key)
                {
                    case 1:
                        calcDelegate = new CalcDelegate(calculator.Add);
                        break;
                    case 2:
                        calcDelegate = new CalcDelegate(calculator.Sub);
                        break;
                    case 3:
                        calcDelegate = calculator.Multi;
                        break;
                    case 4:
                        calcDelegate = calculator.Div;
                        break;
                    case 0:
                        Console.WriteLine("Good bye......");
                        break;
                    default:
                        Console.WriteLine("Incrrect choice");
                        break;
                }
               // if (calcDelegate != null)
                    Console.WriteLine("Res = " + calcDelegate?.Invoke(x, y));
            } while (key != 0);
            */
            // SupersClass supers = new SupersClass();
            // SupersClass.GetKoef();

            // //DoubleDelegate method = new DoubleDelegate(SupersClass.GetKoef);
            // DoubleDelegate method = SupersClass.GetKoef;
            //// Console.WriteLine(method()); 
            // Console.WriteLine(method?.Invoke());

            // DoubleDelegate[] delArr = new DoubleDelegate[]
            // {
            //     SupersClass.GetKoef,
            //     new DoubleDelegate(supers.GetNumber)
            // };

            // Console.WriteLine(delArr[0].Invoke()); ;
            // Console.WriteLine(delArr[1].Invoke());

            // SetStringDelegate setString = new SetStringDelegate(supers.Print);
            // VoidDelegate voidDelegate = supers.Test;

            // setString.Invoke("Hello Delegate");
            // voidDelegate.Invoke();

            // //Delegate.Combine(method, supers.GetNumber);
            // //method += new DoubleDelegate(supers.GetNumber);
            // method += supers.GetNumber;
            // method += supers.GetNumber;

            // foreach (var item in method.GetInvocationList())
            // {
            //     Console.WriteLine( ((DoubleDelegate)item).Invoke());
            // }
            // Console.WriteLine("******************************");

            // Console.WriteLine("Last element : " + method.Invoke());

        }
    }
}


