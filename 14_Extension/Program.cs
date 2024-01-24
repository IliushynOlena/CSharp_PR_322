using System.Runtime.CompilerServices;
using System.Text;

namespace _14_Extension
{
    static class ExampleExtension
    {
        public static int NumberWord(this string data)
        {
            if(string.IsNullOrEmpty(data)) return 0;

            return data.Split(new char[] { ' ', ',', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries).Length;

        }
        public static int NumberSymbol(this string data, char s)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            int count = 0;
            foreach (char c in data) 
            { 
                if(c == s) count++; 
            }
            return count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string message = "Також є  покупці-трейдери, які мають кількість своєї " +
                "валюти та обробники зміни курсу  і відповідоно " +
                "до своїх цілей виконуватимуть   роботу по " +
                "продажу або купівлі ";
           string[] arr = message.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(arr.Length);

            Console.WriteLine($"Count word : {message.NumberWord()}");
            Console.WriteLine($"Count symbol 'т' : {message.NumberSymbol('т')}");
        }
    }
}
