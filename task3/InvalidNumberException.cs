using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace task3
{


    public class ArgumentValidationException : Exception
    {
        public ArgumentValidationException(string message) : base(message) { }
    }

    public class InvalidNumberException
    {
        public static void ValidateArguments(string[] args)
        {
           
            if (args.Length < 3)
            {
                throw new ArgumentValidationException("The number of arguments must be more than 3.");
            }

            if (args.Length % 2 == 0)
            {
                throw new ArgumentValidationException("The number of arguments must be odd.");
            }

        
            HashSet<string> uniqueArgs = new HashSet<string>();
            foreach (var arg in args)
            {
                if (!uniqueArgs.Add(arg))
                {
                    throw new ArgumentValidationException($"The argument '{arg}' repeats. Please, change this argument.");
                }
            }
        }
    }
    
}
