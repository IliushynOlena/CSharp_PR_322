using System.ComponentModel.DataAnnotations;

namespace _22_DataAnnotation
{
    [Serializable]
    public class User
    {
        [Required(ErrorMessage ="Id not defined")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name not setted")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Error length")]
        public string Name { get; set; }//"p"

        [Required(ErrorMessage = "Age not setted")]
        [Range(1,120,ErrorMessage ="Error age")]
        public int Age { get; set; }//333
        //[Phone]
        [RegularExpression(@"\+38\(0\d{2}\)\d{3}\-\d{2}\-\d{2}|\+380\d{9}")]
        public string Phone { get; set; }//+3806968854444
                                         //[EmailAddress]
        [RegularExpression(@"\w{4,}\@\w+\.\w+")]
        public string Email { get; set; }//"slfnsdghoasdhgosdhl"
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
       
        [Compare(nameof(Password),ErrorMessage ="Noe confirm Password")]
        public string ConfirmPassword { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            bool isValid = true;
            do
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter age");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Login");
                string login = Console.ReadLine();

                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                Console.WriteLine("Confirm password");
                string confirmPassword = Console.ReadLine();

                Console.WriteLine("Enter email");
                string email = Console.ReadLine();

                Console.WriteLine("Enter phone");

                string phone = Console.ReadLine();

                user.Id = 1;
                user.Name = name;
                user.Age = age;
                user.Password = password;
                user.ConfirmPassword = confirmPassword;
                user.Email = email;
                user.Phone = phone;
                user.Login = login;

              

                var result = new List<ValidationResult>();
                var contex = new ValidationContext(user);
                if (!(isValid = Validator.TryValidateObject(user, contex, result, true)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.MemberNames.FirstOrDefault() + ": " + error.ErrorMessage);
                    }
                }


            } while (!isValid);

            Console.WriteLine("Model is valid");
        }
    }
}
