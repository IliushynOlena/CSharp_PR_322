namespace _08_Indexers
{
    class Laptop
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"Model : {Model}. Price : {Price}";
        }
    }
    class Shop
    {
        //Array
        Laptop[] laptops = null;//references
        public Shop(int size)
        {
            laptops = new Laptop[size];
        }
        public int Length
        {
            get { return laptops.Length; }
        }
        public Laptop GetLaptop(int index)//110
        {
            if (index >= 0 && index < laptops.Length)return laptops[index]; 
            else throw new IndexOutOfRangeException();
        }
        public void SetLaptop(int index, Laptop value)
        {
            if (index >= 0 && index < laptops.Length)
                laptops[index] = value;
            else throw new IndexOutOfRangeException();

        }
        public Laptop this[int index]
        {
            get
            {
                if (index >= 0 && index < laptops.Length) return laptops[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < laptops.Length)
                    laptops[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }
        public Laptop this[string name]//Hp
        {
            get
            {
                foreach (Laptop item in laptops)
                {
                    if (item.Model == name)
                        return item;
                }
                return null;
            }
            //private set//value = new Laptop("Assus", 10000)'
            //{
            //    for (int i = 0; i < laptops.Length; i++)
            //    {
            //        if (laptops[i].Model == name)
            //        {
            //            laptops[i] = value;
            //            break;
            //        }
            //    }
            //}
        }
        public int FindByPrice(double price)
        {
            for (int i = 0; i < laptops.Length; i++)
            {
                if (laptops[i].Price == price)
                    return i;
            }
            return -1;
        }
        public Laptop this[double price]
        {
            get
            {
               int index =  FindByPrice(price);
                if( index != -1)
                    return laptops[index];
                throw new Exception("Incorrect price");

            }
            set
            {
                int index = FindByPrice(price);
                if (index != -1)
                    //laptops[index] = value; 
                    this[index] = value;

            }
        }
    }
    public class MultArray
    {
        private int[,] array;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public MultArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            array = new int[rows, cols];
        }
        public int this[int r, int c]
        {
            get { return array[r, c]; }
            set { array[r, c] = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //MultArray multArray = new MultArray(2, 3);

            //for (int i = 0; i < multArray.Rows; i++)
            //{
            //    for (int j = 0; j < multArray.Cols; j++)
            //    {
            //        multArray[i, j] = i + j;//indexator - set
            //        Console.Write($"{multArray[i, j]} ");//indexator - get
            //    }
            //    Console.WriteLine();
            //}
            
            Shop shop = new Shop(3);
            shop.SetLaptop(0, new Laptop() { Model = "HP", Price = 45000.00 });
            var laptop =  shop.GetLaptop(0);
            Console.WriteLine(laptop);

            shop[1] = new Laptop() { Model = "Asus", Price = 33999.99 };//value - set
            Console.WriteLine(shop[1]);//get
            shop[2] = new Laptop() { Model = "DELL", Price = 12000.10 };//value - set
            Console.WriteLine();

            try
            {
                for (int i = 0; i < shop.Length + 1; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //shop["HP"] = new Laptop() { Model = "Asus", Price = 1000 };//set

            if (shop["HP"] == null)
            {
                Console.WriteLine("Parameter is null");
            }
            Console.WriteLine(shop["HP"]); //get
            try
            {
                for (int i = 0; i < shop.Length; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            shop[12000.10] = new Laptop() { Model = shop[12000.10].Model, Price = 9999.99 };
            Console.WriteLine(shop[9999.99]); 

            Console.WriteLine("Continue......");
        }
    }
}
