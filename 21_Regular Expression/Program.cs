using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace _21_Regular_Expression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  System.Text.RegularExpressions 
            /*
                СПЕЦ. СИМВОЛИ
                \d - Визначає символи цифр. 
                \D - Визначає любий символ, який не є цифрою. 
                \w - Визначає любий символ цифри, букви або нижнє підкреслення. 
                \W - Визначає любий символ, який не є цифрою, буквою або нижнім підкресленням.. 
                \s - Визначає любий недрукований символ, включаючи пробіл. 
                  (таб і перехід на новий рядок)
                \S - Визначає любий символ, крім символів табуляции, 
                    нового рядка и повернення каретки.
                .  - Визначає любий символ крім символа нового рядка.  
                \. - Визначає символ крапки.

            */
            //string pattern = @"\d";
            //Regex regex = new Regex(pattern);
            //bool flag = true;

            //while (flag)
            //{
            //    string symbol = Console.ReadKey().KeyChar.ToString();

            //    if( symbol == " ")flag = false;

            //    bool success = regex.IsMatch(symbol);
            //    Console.WriteLine(success ? " match found [{0}]" : 
            //        $" match not found [{pattern}]", pattern);
            //}

            /*
            КВАНТИФИКАТОРЫ
            ^ - з початку рядка. 
            $ - з кінця рядка. 
            * - нуль і більше входжень підшаблону в сторці.  
            + - одне і більше  входжень підшаблону в сторці.  
            ? - нуль чи одне  входження підшаблону в сторці.    
             */
            //string pattern = @"\D+";
            ////pattern = @"\d+";
            ////pattern = @"^\d+";
            //pattern = @"\d+$";
            //Regex regex = new Regex(pattern);
            //var arr = new[] { "test", "123", "test123test", "123test", "test123" };

            //foreach (var element in arr)
            //{
            //    Console.WriteLine(regex.IsMatch(element) ? $"String [{element}] matched {pattern}" :
            //        $"String {element} NOT matched {pattern}");

            //    Console.WriteLine(new string('_', 50));
            //}

            //pattern = "^[A-Z][a-z]*$";
            //pattern = "^[A-Z]+[a-z]*$";
            //regex = new Regex(pattern); 

            //while (true)
            //{
            //    Console.WriteLine("Enter string : ");
            //    string input = Console.ReadLine();
            //    if (input == "exit") break;
            //    Console.WriteLine( input != null && regex.IsMatch(input) ?
            //        $"String [{input}] matched {pattern}" :
            //    $"String {input} NOT matched {pattern}");

            //    Console.WriteLine(new string('_', 50));

            //}

            System.Environment.Exit(0);
            string value = "4 - 5 AND  5 y 789";
            Match match = Regex.Match(value, @"\d");

            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
            match = match.NextMatch();
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
           while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }

            Match m = Regex.Match("123 Axx-1-xxy \n Axyx-2xyyxy", @"A.*y");
            while (m.Success)
            {
                Console.WriteLine("Value " + m.Value);
                Console.WriteLine("Length " + m.Length);
                Console.WriteLine("Index " + m.Index);
                Console.WriteLine();
                m = m.NextMatch();
            }

            string values = "saidsaid shed shed see spear spread super";
             MatchCollection matches =  Regex.Matches(values, @"s\w+d");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Index = {item.Index}, Value : {item.Value}");
            }

            string message = "Don't replace Dot Net replaced Net Net dots";
            string output = Regex.Replace(message, "N.t", "NET");
            Console.WriteLine(message);
            Console.WriteLine(output);

        }
    }
}
