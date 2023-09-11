using System.Diagnostics.SymbolStore;
using System.Security.Cryptography.X509Certificates;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

                Random random = new Random();
                int number = random.Next(1, 10);

                int försök = 0;
                bool guessRight = false;

                while (försök < 5)
                {
                    Console.WriteLine("Gissa ett tal mellan 1-20");
                    if (int.TryParse(Console.ReadLine(), out int guess))
                    {
                        försök++;

                        if (checkGuess(guess, number))
                        {
                            guessRight = true;
                            break;
                        }
                        else
                        {
                            if (guess < number)
                                Console.WriteLine("Tyvärr du gissade för lågt!");
                            else
                                Console.WriteLine("Tyvärr du gissade för högt!");
                        }
                    }

                }
                if (guessRight)
                {
                    Console.WriteLine("Wohoo du gissade rätt!!");
                }
                else
                {
                    Console.WriteLine("Du lyckades inte gissa rätt denna gång!");
                }

                Console.WriteLine("Vill du spela igen? Ja/Nej?");
                string answer = Console.ReadLine().ToLower();
                playAgain = (answer == "ja");
            }

            

        }
        static bool checkGuess(int guess,int number)
        {
            return guess == number;
        }
    }
}