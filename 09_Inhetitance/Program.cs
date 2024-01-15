namespace _09_Inhetitance
{
    //private public protected
    abstract class Person:Object
    {
        protected string name;
        private readonly DateTime birthday;
        public Person()
        {
            name = "No name";
            birthday = DateTime.Now;
        }
        public Person(string n, DateTime b)
        {
            name = n;
            if (b > DateTime.Now) { birthday = new DateTime(); }
            else { birthday = b; }
        }
        //void SetDate(DateTime newB)
        //{
        //    birthday = newB;
        //}
        public virtual void Print()
        {
            Console.WriteLine($"Name : {name}. Birthday : {birthday.ToShortDateString()}");
        }
        public override string ToString()
        {
            return $"Name : {name}. Birthday : {birthday.ToShortDateString()}";
        }
       public abstract void DoWork();
    }
    //class Name : BaseClass, Interface1, Interface2, 
    class Worker : Person//public Person
    {
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set 
            {
                salary = value >= 0 ? value : 0;
            }
        }
        public Worker() : base()
        {
            Salary = 0;
        }
        public Worker(string n, DateTime b, decimal s):base(n, b) 
        { Salary = s; }
        public override void DoWork()
        {
            Console.WriteLine("Doing some work......");
        }
        public override string ToString()
        {
            return base.ToString() + Salary.ToString();
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Salary : {Salary} grn\n");
        }

    }
    sealed class Programmer: Worker
    {
        public int CodeLines { get; set; }
        public Programmer():base()
        {
           CodeLines = 0;
        }
        public Programmer(string n, DateTime b, decimal s):base(n,b,s)
        {
            CodeLines = 0;
        }
        public sealed override void DoWork()
        {
            Console.WriteLine("Write C# code!");
        }
        public void WriteCode()
        {
            CodeLines++;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Code Lines : {CodeLines}");
        }
    }
    class TeamLead: Worker
    {
        public int ProjectCount { get; set; }
        //public override void DoWork()
        //{
        //    Console.WriteLine("Manage Team project!");
        //}
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Worker worker = new Worker("Vova", new DateTime(1995,12,5), 40); 
            worker.Print();

            Person[] people = new Person[]
            {
                //new Person(),
                worker,
                new Programmer("Bill", new DateTime(1999, 5, 5), 10000)
            };

            foreach (Person person in people) 
            {
                Console.WriteLine("-------------- Info-----------");
                person.Print();                 
            }
            Programmer pr = null;
            //1 - use cast type()
            try
            {
                pr = (Programmer)people[1];
                pr.DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //2 - use as
            pr = people[1] as Programmer;
            if(pr != null)
            {
               pr?.DoWork();
            }
            //3 - use is and as
            if (people[1] is Programmer) 
            {
                pr = people[1] as Programmer;
                pr.DoWork();
            }



        }
    }
}
