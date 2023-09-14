using System.Diagnostics.SymbolStore;
using System.Security.Cryptography.X509Certificates;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            //Här skapar jag en bool datatyp, döper den till playAgain och sätter värdet till true direkt.  

            while (playAgain)
            //medan playAgain är true ska denna loop köras med hela programmet inuti sig.
            {
                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");


                Console.WriteLine("Mellan vilka tal vill du gissa?");
                int number1 = int.Parse(Console.ReadLine());
                Console.Write("Till");
                int number2 = int.Parse(Console.ReadLine());
                Random random = new Random();
                int number = random.Next(number1, number2);
                //Console.WriteLine(number);

                int försök = 0;
                bool guessRight = false;

                //här skapar jag variabeln "försök" som börjar på 0, och boolean "guessRight" som får värdet false.

                while (försök < 5)
                //denna while loop med programmet ska köras så länge försök är under 5. För varje gång den körs plussas det på en på variablen försök.
                {
                    Console.WriteLine($"Gissa ett tal mellan {number1} till {number2}");
                    if (int.TryParse(Console.ReadLine(), out int guess))
                    {
                        försök++;

                        if (checkGuess(guess,number))
                        {
                            guessRight = true;
                            break;
                        //Denna if-sats kollar om användaren har rätt eller inte med funktionen som ligger längst ner i koden
                        //är det rätt så går den ur if satses.
                        }
                        else
                        //Är det inte rätt? då kollar den om gissningen är lägre än numret som slumpades fram
                        //och skriver ut en rad text, annars är det högre. och då skriver den ut en annan text.
                        {
                            if (guess < number)
                                Console.WriteLine("Tyvärr du gissade för lågt!");
                            else
                                Console.WriteLine("Tyvärr du gissade för högt!");
                        }
                    }

                }
                if (guessRight)
                //till denna if-sats kommer vi om användaren gissar rätt. Då skriver den ut denna text.
                {
                    Console.WriteLine("Wohoo du gissade rätt!!");
                }
                else
                //Om inte guessRight blir true, så har användaren gissat fel, då skriver den ut denna rad text.
                {
                    Console.WriteLine("Du lyckades inte gissa rätt denna gång!");
                }

                Console.WriteLine("Vill du spela igen? Ja/Nej?");
                string answer = Console.ReadLine().ToLower();
                playAgain = (answer == "ja");
                //och i slutet så ska användaren få valet att spela igen. om answer är "ja" så blir playAgain true och den hoppar längst upp igen.
            }

            

        }
        static bool checkGuess(int guess,int number)
        {
            return guess == number;
        }
        //här är funktionen som kollar om svaret användaren gav är rätt. Är guess = med numret som slumpades så är funktionen true annars false.
    }
}