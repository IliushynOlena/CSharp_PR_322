using System.Text.Json;

namespace _21_JSON_Serialization


{
   
    [Serializable]
    public class Person
    {       
        public string Name { get; set; }
        public int Age { get; set; }

        int _identNumber;
        [NonSerialized]
        const string Planet = "Earth";
        public Person()
        {
           
        }
        public Person(int number)
        {
            _identNumber = number;
           
        }
        public override string ToString()
        {
            return $"Name : {Name}. Age: {Age}. Identification number : {_identNumber} Planet : {Planet}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                 new Person(11111111){ Name = "Jack", Age = 25},
                 new Person(22222222){ Name = "Bob", Age = 15},
                 new Person(33333333){ Name = "Tom", Age = 45}
            };
            foreach (var item in people)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            try
            {
                //Serialize
                string fileName = "Persons.json";
                string jsonString =  JsonSerializer.Serialize(people);

                File.WriteAllText(fileName, jsonString );
                //Deserialize
                jsonString = File.ReadAllText(fileName);

                 List<Person> list =  JsonSerializer.Deserialize<List<Person>>(jsonString);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
