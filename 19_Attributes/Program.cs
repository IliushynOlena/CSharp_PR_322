using System.Reflection;

namespace _19_Attributes
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method|AttributeTargets.Constructor)]
    class CoderAttribute : Attribute
    {
        public string Name { get; set; } = "Olena";
        public DateTime Date { get; set; } = DateTime.Now;
        public CoderAttribute() { }
        public CoderAttribute(string name, string date) {

            try
            {
                Name = name;
                Date = Convert.ToDateTime(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }
        public override string ToString()
        {
            return $"Coder : {Name}, Date : {Date}";
        }

    }

    [Obsolete, Serializable]
    [Coder]
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }//lena@gmail.com 
        public string Phone { get; set; }
        [CoderAttribute]
        public Employee() { }

        [Coder("Tom","2023-12-24")]
        public void IncreaseSalary(double salary)
        {
            Salary += salary;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var attr in typeof(Employee).GetCustomAttributes(true))
            {
                Console.WriteLine(attr.ToString());
            }
            Console.WriteLine("\n\nAttribute on member of class Employee");
            foreach (MemberInfo info in typeof(Employee).GetMembers())
            {
                Console.WriteLine(info.ToString());
                foreach (var attr in info.GetCustomAttributes<CoderAttribute>(true))
                {
                    Console.WriteLine(attr.ToString());
                }
            }

        }
    }
}
