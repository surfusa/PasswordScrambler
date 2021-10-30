using System;

namespace NimbleRx
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new FileReader();
            var writer = new FileWriter();

            Console.WriteLine("Enter the path to Character Mapping Text File:");
            var pathToCharacterMap = Console.ReadLine();

            // Sample Path
            //var pathToCharacterMap = @"C:\Users\james\Documents\GitHub\PasswordScrambler\NimbleRx\Test Files\CharacterMap.txt";

            Console.WriteLine("Enter the path to Passwords Text File:");
            var pathToPasswords = Console.ReadLine();

            // Sample Path
            //var pathToPasswords = @"C:\Users\james\Documents\GitHub\PasswordScrambler\NimbleRx\Test Files\Passwords.txt";

            Console.WriteLine("Enter the output directory for the New Passwords File:");
            var outputPath = Console.ReadLine();

            // Sample Path
            //var outputPath = @"C:\Users\james\Documents\GitHub\PasswordScrambler\NimbleRx\Test Files\";

            try
            {
                var characterMap = reader.ReadCharacterMap(pathToCharacterMap);
                var passwords = reader.ReadPasswordList(pathToPasswords);

                var scrambler = new PasswordScramble();

                var newPasswords = scrambler.ScramblePasswords(passwords, characterMap);

                writer.WritePasswords(newPasswords, outputPath);

                if (scrambler.DuplicatePasswords.Count > 0)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Skipped Duplicate Passwords");
                    Console.WriteLine("---------------------------");
                    foreach (var duplicate in scrambler.DuplicatePasswords)
                    {
                        Console.WriteLine(duplicate);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
