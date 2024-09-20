using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using task3;
class Game
{
    static void createUserMenu(string[] args)
    {
        Console.WriteLine("\r\nChoose an option:");
        Console.WriteLine("0- exit");
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"{(i + 1).ToString()}- {args[i]}");
        }
        Console.WriteLine("?- help");
    }
    static bool checkUserInput(string input, string[] args)
    {
        if (int.TryParse(input, out int number) || input=="?")
        {
            return number >= 0 && number <= args.Length ? true : false;
        }
        else
        {
            return false;
        }
    }
    static void Main(string[] args  )
    {
        try
        {
            InvalidNumberException.ValidateArguments(args);
            KeyGenerator keyGenerator = new KeyGenerator();
            HmacComputation hmacComputation = new HmacComputation();
            RuleGenerator rule = new RuleGenerator();
            rule.generateRulesArray(args.Length);
            
            while (true)
            {

                int randomIndex = keyGenerator.GenerateRandomNumber(0,args.Length-1);
                byte[] generatedKey = keyGenerator.GenerateSecureRandomKey(32);
                byte[] generatedHmac = hmacComputation.ComputeHmac(args[randomIndex], generatedKey);
                string strGeneratedKey = Convert.ToBase64String(generatedKey);
                Console.WriteLine($"\r\nHMAC: {Convert.ToBase64String(generatedHmac)}");
                bool flag = false;
                createUserMenu(args);
                string userInput = Console.ReadLine();
                if (checkUserInput(userInput,args))
                {
                    switch (userInput)
                    {
                        case "?":
                            TableGenerator.ShowTable(args, rule.RulesArray);
                            break;
                        case "0":
                            flag = true;
                            break;
                        default:
                            Console.WriteLine("\r\nYour move is " + args[Convert.ToInt32(userInput) - 1]);
                            Console.WriteLine("The computer move is " + args[randomIndex]);
                            Console.WriteLine(WinnerDeterminer.GetWinner(Convert.ToInt32(userInput) - 1,
                                                                         randomIndex,
                                                                         rule.RulesArray,
                                                                         rule.RulesArray[0, rule.RulesArray.GetLength(1) - 1],
                                                                         rule.RulesArray[0, 0]));
                            Console.WriteLine("The HMAC key is " + strGeneratedKey);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Please, input a number from 0 to {args.Length} or input ? for help");
                }
                if(flag==true)
                {
                    break;
                }
            }
        }
        catch(ArgumentValidationException ex)
        {
           
                Console.Write($"Error:{ex.Message}");
        }  
    }

}

