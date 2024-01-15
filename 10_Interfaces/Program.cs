namespace _10_Interfaces
{

    public interface IWorker
    {
        //default - all field is public
        void RunWorker();
        ///private int salary;- error
        bool IsWorking { get; set; }
        int Salary { set; }
        string Position { get;  }
        event EventHandler WorkEnded;       
    }


    abstract class Human// : Object
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public override string ToString()
        {
            return $"Name : {Name}. \nLastName : {LastName}. " +
                $"\nBirthday : {Birthday.ToShortDateString()}";
        }
    }
    abstract class Employee : Human 
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nPosition : {Position}. \nSalary {Salary}\n";
        }
    }
    interface IWorkable
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkable> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager // implement(realize)
    {
        public List<IWorkable> ListOfWorkers { get ; set; }

        public void Control()
        {
            Console.WriteLine( "Controling work!!!!");
        }

        public void MakeBudget()
        {
            Console.WriteLine("Count money!!!!");
        }

        public void Organize()
        {
            Console.WriteLine("Organizing work!!!!");
        }
    }
    class Seller : Employee, IWorkable
    {
        //auto-property  - readonly
        //bool IsWorking { get; } = true;
        //as
        //readonly
        public bool IsWorking => true;//lambda 

        public string Work()
        {
            return "Selling product!";
        }
    }
    class Cashier : Employee, IWorkable
    {
        //full property
        private bool isWorking = true;

        public bool IsWorking
        {
            get { return isWorking = true; }
        }   
        public string Work()
        {
            return "Get payment!";
        }
    }
    class Adminstrator : Employee, IWorkable, IManager
    {
        public bool IsWorking { get; } = true;

        public List<IWorkable> ListOfWorkers { get; set ; }

        public void Control()
        {
            Console.WriteLine("I am a BOSS))))");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I have a million......Xaxaxaxaxaxaxxa");
        }

        public void Organize()
        {
            Console.WriteLine("I organize work....");
        }

        public string Work()
        {
           return "I need to do my work(((((";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IManager director = new Director()
            {
                 Name = "Bill",
                 LastName = "Ivanovich",
                 Birthday = new DateTime(2000,5,15),
                 Position = "Director",
                 Salary = 45000
            };
            
            director.Organize();
            director.Control();
            Console.WriteLine(director);

            IWorkable seller = new Seller()
            {
                Name = "Oksana",
                LastName = "Petrivna",
                Birthday = new DateTime(1985, 4, 22),
                Position = "Seller",
                Salary = 7350
            };
            if (seller is Seller)
            {
                (seller as Seller).Salary = 60000;
                Console.WriteLine($"Salary of seller : {(seller as Seller).Salary} ");
            }

            //seller.Salary = 60000;
            Console.WriteLine(seller.Work());
            Console.WriteLine(seller);

            director.ListOfWorkers = new List<IWorkable> 
            { 
                seller,
                new Cashier
                {
                    Name = "Ivanka",
                    LastName = "Oliunuk",
                    Birthday = new DateTime(2000, 4, 22),
                    Position = "Cashier",
                    Salary = 12000
                },
                new Adminstrator
                {
                     Name = "Oleg",
                    LastName = "Petruk",
                    Birthday = new DateTime(2002, 4, 22),
                    Position = "Adminstrator",
                    Salary = 25000
                }
            };
            foreach (var item in director.ListOfWorkers)
            {
                Console.WriteLine(item);
                if (item.IsWorking)
                {
                    Console.WriteLine(item.Work());    
                }
                if(item is Seller)
                    Console.WriteLine("List have seller");
            }

            //Multiple Interface
            Adminstrator admin = new Adminstrator();
            Console.WriteLine(admin);
            
            IManager manager = admin;
            manager.MakeBudget();

            IWorkable worker = admin;
            worker.Work();
            


        }
    }
}
