using System;
using System.Linq;

namespace Password_Validation
{
    internal static class Program
    {
        private static void Main()
        {
            /*
             * Password Validation
                Create a function that validates a password to conform to the following rules:

                Length between 6 and 24 characters.
                At least one uppercase letter (A-Z).
                At least one lowercase letter (a-z).
                At least one digit (0-9).
                Maximum of 2 repeated characters.
                "aa" is OK 👍
                "aaa" is NOT OK 👎
                Supported special characters:
                ! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; " ' ? < > , .
             */

            char[] Uppercase = new char[] { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O',
                'P', 'A', 'S', 'D', 'F', 'G','H','J','K','L','Z','X','C','V','B','N','M'};

            char[] Lowercase = new char[] {'q','w','e','r','t','y','u','i','o','p','a','s'
                ,'d','f','g','h','j','k','l','z','x','c','v','b','n','m' };

            char[] Digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            while (true)
            {
                Console.WriteLine("Please enter a password to be evaluated");
                string password = Console.ReadLine();
                if (password.Length <= 24 && password.Length >= 6)
                {
                    Console.WriteLine("Password has the correct length");
                    if (ValidateCharacters(password, 23, Uppercase))
                    {
                        Console.WriteLine("Password has an Uppercase");
                        if (ValidateCharacters(password, 23, Lowercase))
                        {
                            Console.WriteLine("Password has a Lowercase");
                            if (ValidateCharacters(password, 9, Digits))
                            {
                                Console.WriteLine("Password has a numerical character");
                                if (CheckRepeating(password))
                                {
                                    Console.WriteLine("Password is correct");
                                }
                                else Console.WriteLine("A character may only repeat 2 times");
                            }
                            else Console.WriteLine("Password must have a numerical character");
                        }
                        else Console.WriteLine("Password must have a lowercase");
                    }
                    else Console.WriteLine("Password must have an uppercase");
                }
                else Console.WriteLine("Password must have a minumum of 6 characters and a maximum of 24");
            }
        }
         static private bool ValidateCharacters(string password, int iterationCount,char[] check)
        {
            bool valid = false;
            int iteration = 0;

            while (!valid && (iteration <= iterationCount))
            {
                if (password.Contains(check[iteration])) {valid = true;}
                iteration++;
            }

            return valid;
        }
        static private bool CheckRepeating(string password)
        {
            bool valid = true;
            char[] passwordArray = password.ToCharArray() ;
            char selectedChar;
            int count = 0;

            for (int i = 0; i < passwordArray.Length; i++)
            {
                selectedChar = passwordArray[i];

                for (int y = i; y < passwordArray.Length; y++)
                {
                    if (y == i + 3) {break; }
                    if (selectedChar == passwordArray[y])
                    {
                        count++;
                        if (count > 2){valid = false;}
                    }
                }
                count = 0;
            }

            return valid;
        }
    }
}
//a24e787e99de2706ed6615da2398f50545e489f429e03ebf41867fd15452cbee3d56b2da50715412b08bbfd84fe0aba1aa14894be0ea888bb1b09784cffc3c15
//d982249f1b4e974aba099c5196bf40bd92570843c853e8c10e7f039234380153