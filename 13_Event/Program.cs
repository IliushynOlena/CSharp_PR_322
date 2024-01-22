namespace _13_Event
{
    public delegate void FinishAction();
    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public void PassExam(string task)
        {
            Console.WriteLine($"Student {FirstName} pass the exam {task}");
        }
    }
    class Teacher
    {
        //public  ExamDelegate ExamEvent = null;
        //public event ExamDelegate ExamEvent = null;// auto event
        //full-event
        
        private ExamDelegate examDelegate;
        public event ExamDelegate ExamEvent
        {
            add
            {
                examDelegate += value;
                Console.WriteLine(value.Method.Name + " was added!!!!");
            }
            remove
            {
                examDelegate -= value;
                Console.WriteLine(value.Method.Name + " was removed!!!!");
            }
        }

        public event Action TestEvent;
        public void CreateExam(string task)
        {
            //exam creating......
            ///some code......
            ///
            //call members (call event)
            examDelegate?.Invoke(task);

        }
        public void StartEvent()
        {
            TestEvent?.Invoke();    
        }

    }
    internal class Program
    {
        static void HardWork(FinishAction action)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Operation {i+1} working......");
                Thread.Sleep( random.Next(500) );
                Console.WriteLine($"Operation {i+1} finished......");
            }
            //finish action invoke
            action?.Invoke();
            //
            //
            //Console.WriteLine("Very bad");
        }
        public static void Action1() {
            Console.WriteLine("Very good");
        }
        public static void Action2()
        {
            Console.WriteLine("Norm");
        }
        static void Main(string[] args)
        {
            List<Student>students =  new List<Student>
            {
                new Student
                {
                    FirstName = "Bill",
                    LastName = "Tomson",
                    Birthday = new DateTime(2005, 4, 7),
                },
                new Student
                {
                    FirstName = new string("Olga"),
                    LastName = "Ivanchuk",
                    Birthday = new DateTime(2003, 10, 17),
                },
                new Student
                {
                    FirstName = "Candice",
                    LastName = "Leman",
                    Birthday = new DateTime(2006, 3, 12),
                },
                new Student
                {
                    FirstName = "Nicol",
                    LastName = "Taylor",
                    Birthday = new DateTime(2004, 7, 14),
                }
            };

            Teacher teacher = new Teacher();

            foreach (var st in students)
            {
                teacher.ExamEvent += new ExamDelegate(st.PassExam);
            }
            teacher.ExamEvent -= students[0].PassExam;
            //teacher.ExamEvent = null;

            teacher.CreateExam("Exam C# in Microsoft Teams....At 9.00 AM");



            teacher.TestEvent += Console.Clear;
            teacher.TestEvent += delegate () { Console.ForegroundColor = ConsoleColor.Yellow; };
            teacher.TestEvent += () => Console.Beep(500, 1000);
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent += Action1;
            teacher.TestEvent -= delegate () { Console.ForegroundColor = ConsoleColor.Yellow; };
            //teacher.StartEvent();



            //FinishAction[] action = new FinishAction[]
            //{
            //    Action1, Action2,
            //    delegate(){Console.WriteLine("Test");}
            //};
            //Console.WriteLine("Action1 - enter 1,Action2 - enter 2 ");
            //int index = int.Parse( Console.ReadLine() );
            ////HardWork(Action1);
            ////HardWork(Action2);
            //HardWork(delegate () { Console.WriteLine("Testing delegate"); });
            //HardWork(action[index-1]);
        }

        private static void Teacher_TestEvent()
        {
            Console.WriteLine("Auto-created method by pressing TAB!!!");
        }
    }
}
