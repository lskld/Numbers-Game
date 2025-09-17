using System;

namespace NumbersGame
{
    internal class Program
    {
        //Deklarerar alla variabler som måste vara samma i samtliga metoder.
        static int gameRounds = 0;
        static int amountTries;
        static int randomNumber;
        static int maxNumber;
        static Random random = new Random();
        static bool continueGame = true;
        static void Main(string[] args)
        {
            while (continueGame) 
            { 
            Console.Clear();
            Console.WriteLine("Välkommen! Välj svårighetsgrad. lätt, medel eller svår?");
            string userInput1 = Console.ReadLine();

            ChooseDifficulty(userInput1);
            gameRounds = 0;
            Gameplay();
            }
        }

        static void CheckGuess(int userNum, int randomNum)
        {
            if (userNum == randomNum)
            {
                Console.WriteLine("Wohoo! Du klarade det!");
                gameRounds = amountTries;
                Console.WriteLine("Vill du starta om spelet? (ja / nej)");
                string restartQuestion = Console.ReadLine();

                if (restartQuestion == "nej")
                {
                    Console.WriteLine("Hejdå!");
                    continueGame = false;
                }

            }
            else if (((randomNum - userNum) <=2 && ((randomNum - userNum) > 0)) || ((userNum - randomNum) <= 2 && ((userNum - randomNum) > 0)))
            {
                Console.WriteLine("Det var riktigt nära!");
            }
            else if (userNum < randomNum)
            {
                Console.WriteLine("Tyvärr, du gissade för lågt!");
            }
            else
            {
                Console.WriteLine("Tyvärr, du gissade för högt!");
            }
            
        }

        static void ChooseDifficulty(string input)
        {
            switch (input)
            {

                case "lätt":
                    maxNumber = 11;
                    randomNumber = random.Next(1, maxNumber);
                    amountTries = 6;
                    Console.WriteLine("Välkommen! Detta är lätt nivå. Jag tänker på ett nummer mellan 1 - 10 och du har 6 försök! Kör!");
                    break;

                case "medel":
                    maxNumber = 26;
                    randomNumber = random.Next(1, maxNumber);
                    amountTries = 5;
                    Console.WriteLine("Välkommen! Detta är medel nivå. Jag tänker på ett nummer mellan 1 - 25 och du har 5 försök! Kör!");
                    break;

                case "svår":
                    maxNumber = 51;
                    randomNumber = random.Next(1, maxNumber);
                    amountTries = 3;
                    Console.WriteLine("Välkommen! Detta är svår nivå. Jag tänker på ett nummer mellan 1 - 50 och du har 3 försök! Kör!");
                    break;

                default:
                    maxNumber = 26;
                    Console.WriteLine("Ogiltig input! Vi har valt medelnivå åt dig. Jag tänker på ett nummer mellan 1 - 25 och du har 5 försök! Kör!");
                    randomNumber = random.Next(1, maxNumber);
                    amountTries = 5;
                    break;
            }
        }

        static void Gameplay()
        {
            while (gameRounds < amountTries)
            {
                int userNumber;
                string userInput2 = Console.ReadLine();
                bool convertInt = int.TryParse(userInput2, out userNumber);

                if (convertInt && userNumber < maxNumber)
                {
                    CheckGuess(userNumber, randomNumber);
                    gameRounds++;
                }

                else if (convertInt && userNumber > maxNumber || userNumber < 1)
                {
                    Console.WriteLine("Talet är utanför de tillåtna gränserna. Försök igen.");
                }
                else
                {
                    Console.WriteLine("Ogiltig input! Försök igen.");
                }

            }
            if (gameRounds == amountTries)
            {
                Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på {amountTries} försök!");
                Console.WriteLine("Vill du starta om spelet? (ja / nej)");
                string restartQuestion = Console.ReadLine();
               
                if (restartQuestion == "nej")
                {
                    Console.WriteLine("Hejdå!");
                    continueGame = false;
                }
              
            }

        }

    }
}
