using System.Text;

namespace _04_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello";
            str += " World";
            str += " World";
            str += " World";
            str += " World";
            str += " World";

            StringBuilder builder = new StringBuilder();
            Console.WriteLine($"Size / Length = {builder.Length}");
            Console.WriteLine($"Capacity = {builder.Capacity}");

            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append(Environment.NewLine);    
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine(  builder);
            Console.WriteLine($"Size / Length = {builder.Length}");
            Console.WriteLine($"Capacity = {builder.Capacity}");
            builder.AppendLine("bla");
            builder.AppendLine("bla");
            builder.AppendLine("bla");
            builder.AppendLine("bla");
            builder.AppendLine("bla");
            builder.AppendLine("bla");
            Console.WriteLine(builder);
            Console.WriteLine($"Size / Length = {builder.Length}");
            Console.WriteLine($"Capacity = {builder.Capacity}");

           
        }
    }
}
