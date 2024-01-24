namespace _16_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            Dictionary<string, string> countries = new Dictionary<string, string>();

       
            countries.Add("UA", "Ukraine");
            countries.Add("FR", "France");
            countries.Add("USA", "United State");
            countries.Add("PL", "Poland");
            countries.Add("GB", "Great Britain");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            string country = countries["USA"];
            Console.WriteLine(country);
            countries["USA"] = "America";
            countries["IN"] = "India";

            countries.Remove("USA");

            Console.WriteLine();
            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            //2
            Dictionary<char, Person> people = new Dictionary<char, Person>();
            people.Add('B', new Person() { Name = "Bill" });
            people.Add('T', new Person() { Name = "Tom" });
            people.Add('J', new Person() { Name = "Jack" });
            people.Add('R', new Person() { Name = "Rita" });
            people.Add('O', new Person() { Name = "Olga" });
            foreach (var p in people)
            {
                Console.WriteLine(p.Key + " - " + p.Value.Name);
            }
            if (people.ContainsKey('N'))
            {
                people['N'].Name = "Nick";
            }
            else
            {
                Console.WriteLine("Collection does not contain this key!!!");
            }

            foreach (var item in people.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in people.Values)
            {
                Console.WriteLine(item.Name);
            }

   

        }

        class Person
        {
            public string Name { get; set; }
        }
    

    }
}
