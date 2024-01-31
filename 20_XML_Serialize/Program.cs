using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace _20_XML_Serialize
{
    //[Serializable]
    public class Passport
    {
        public int Number { get; set; }
        public Passport()
        {
            Number = 555555;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
    //[Serializable]
    public class Person
    {
        public Passport Passport { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        int _identNumber;
        [NonSerialized]
        const string Planet = "Earth";
        public Person()
        {
            Passport = new Passport();
        }
        public Person(int number)
        {
            _identNumber = number;
            Passport = new Passport();
        }
        public override string ToString()
        {
            return $"Name : {Name}. Age: {Age}. Identification number : {_identNumber}" +
                $" Planet : {Planet}. Passport :{Passport}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(1234569)
            {
                Name = "Jack",
                Age = 25
            };


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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            //XmlSerializer serializer = new XmlSerializer(typeof(Person));
            try
            {
                using (Stream fstream = File.Create("test.xml"))
                {
                    //serializer.Serialize(fstream, person);
                    serializer.Serialize(fstream, people);
                }//Dispose()
                Console.WriteLine("Xml Serialize OK!!!!");
                List<Person> newpersons = null;
               // Person p = null;
                using (Stream fstream = File.OpenRead("test.xml"))
                {
                    //p = (Person)serializer.Deserialize(fstream);
                    newpersons = (List<Person>)serializer.Deserialize(fstream);
                }
                //Console.WriteLine(p);
                foreach (var item in newpersons)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
