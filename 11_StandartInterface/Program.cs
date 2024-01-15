using System.Collections;

namespace _11_StandartInterface
{
    class StudentCard : ICloneable
    {
        public int Number { get; set; }//10 = 10
        public string Series { get; set; }//0x123 * 0x123
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"\nNumber : {Number}. Series : {Series}";
        }
    }

    class Student : IComparable<Student>, ICloneable //IComparable
    {
        public string FirstName { get; set; }//0x123 = 0x123
        public string LastName { get; set; }//0x147 = 0x147
        public DateTime Birthdate { get; set; }//2003.5.6 = 2003.5.6
        public StudentCard StudentCard { get; set; }//0x258 = 0x258

        public object Clone()
        {
           Student copy = (Student)this.MemberwiseClone();
            copy.FirstName = (string) this.FirstName.Clone();
            copy.LastName = (string) this.LastName.Clone();
            copy.StudentCard = (StudentCard) this.StudentCard.Clone();
            //copy.StudentCard = new StudentCard()
            //{
            //    Number = this.StudentCard.Number,
            //    Series = this.StudentCard.Series
            //};
            return copy;
        }

        public int CompareTo(Student? other)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
        //public int CompareTo(object? obj)//Students st
        //{
        //    if (obj is Student)
        //        return FirstName.CompareTo((obj as Student).FirstName);
        //    throw new Exception();
        //}

        public override string ToString()
        {
            return $"First Name : {FirstName}. Last Name : {LastName}. " +
                $"Birthdate : {Birthdate.ToShortDateString()}. {StudentCard}\n";
        }
    }
    class LastNameComparer : IComparer<Student>//IComparer
    {
        //public int Compare(object? x, object? y)
        //{
        //    if ( x is Student && y is Student)
        //    {
        //        return (x as Student).LastName.CompareTo( (y as Student).LastName);
        //    }
        //    throw new Exception();  
        //}
        public int Compare(Student? x, Student? y)
        {
            return x!.LastName.CompareTo(y!.LastName);
        }
    }
    class BirtdayComparer : IComparer<Student>//IComparer
    {
        public int Compare(Student? x, Student? y)
        {
            return x!.Birthdate.CompareTo(y!.Birthdate);
        }
    }
    class Auditory : IEnumerable
    {
        Student[] students = null;//Array
        public Auditory()
        {
            students = new Student[]//Array
            {
               
                new Student
                {
                    FirstName = "Bill",
                    LastName = "Tomson",
                    Birthdate = new DateTime(2005, 4, 7),
                    StudentCard = new StudentCard() { Number = 123456, Series = "AA" }
                },
                new Student
                {
                    FirstName = new string("Olga"),
                    LastName = "Ivanchuk",
                    Birthdate = new DateTime(2003, 10, 17),
                    StudentCard = new StudentCard() { Number = 321456, Series = "BA" }
                },
                new Student
                {
                    FirstName = "Candice",
                    LastName = "Leman",
                    Birthdate = new DateTime(2006, 3, 12),
                    StudentCard = new StudentCard() { Number = 7412585, Series = "AA" }
                },
                new Student
                {
                    FirstName = "Nicol",
                    LastName = "Taylor",
                    Birthdate = new DateTime(2004, 7, 14),
                    StudentCard = new StudentCard() { Number = 963258, Series = "BK" }
                }
            };
        }

        public IEnumerator GetEnumerator()
        {
           return students.GetEnumerator();
        }
        //void Print()
        //{
        //    for (int i = 0; i < students.Length; i++)
        //    {
        //        Console.WriteLine(students[i]);
        //    }
        //}
        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students, comparer);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student() {
                    FirstName = "Bill",
                    LastName = "Tomson",
                    Birthdate = new DateTime(2005, 4, 7),
                    StudentCard = new StudentCard() { Number = 123456, Series = "AA" }
                };


            Student copy= (Student)student.Clone();
            
            Console.WriteLine(student);
            Console.WriteLine(copy);
            copy.FirstName = "Anton";
            copy.Birthdate = new DateTime(1945, 3, 8);
            copy.StudentCard.Number = 999999;
            copy.StudentCard.Series = "MM";
            Console.WriteLine(student);
            Console.WriteLine(copy);
            /*
            Auditory auditory = new Auditory();
            Console.WriteLine("------- List Students ------------");
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }
            auditory.Sort();
            Console.WriteLine("------- Sort Students by Name ------------");
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }
            auditory.Sort(new LastNameComparer());
            Console.WriteLine("------- Sort Students by Surname ------------");
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }
            auditory.Sort(new BirtdayComparer());
            Console.WriteLine("------- Sort Students by Birthday------------");
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }
            */
            //int[] : Array
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //Console.WriteLine();
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}
        }
    }
}
