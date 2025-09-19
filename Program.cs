namespace NumbersGame
{
    internal class Program
    {
        public static int GenerateSecretNumber(int lowestValue, int highestValue)
        {
            var randomNumber = new Random();
            int number = randomNumber.Next(lowestValue, highestValue+1);
            return number;
        }

        public static int CorrectUserInput(int lowestValue, int highestValue)
        {
            bool isAnswerValid = false;
            int inputNumber= 0;

            while (!isAnswerValid)
            {
                isAnswerValid = int.TryParse(Console.ReadLine(), out inputNumber);

                if (!isAnswerValid || inputNumber<lowestValue || inputNumber>highestValue)
                {
                    Console.WriteLine($"Du behöver skriva ett tal mellan {lowestValue} och {highestValue}. Försök igen: ");
                    isAnswerValid = false;                    
                }               
            }
            return inputNumber;
        }

        public static void CheckGuesses(int numberOfAcceptedGuesses)
        {
            int secretNumber = GenerateSecretNumber(1, 20);
            

            for(int i = 0; i < numberOfAcceptedGuesses; i++)
            {
                int userGuess = CorrectUserInput(1, 20);

                if (userGuess==secretNumber)
                {
                    Console.WriteLine("Wohoo! Du klarade det!");
                    break;
                }

                else if (i==numberOfAcceptedGuesses-1 && !(userGuess == secretNumber))
                {
                    Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                }

                else if (userGuess<secretNumber)
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt!");
                }

                else if (userGuess>secretNumber)
                {
                    Console.WriteLine("Tyvärr, du gissade för högt!");
                }

            }            
        }

        static void Main(string[] args)
        {
            int lowestValue = 1;
            int higestValue = 20;
            int numbersOfAcceptedGuesses = 5;

            Console.WriteLine($"Välkommen! Jag tänker på ett nummer mellan {lowestValue}-{higestValue}." +
                $" Kan du gissa vilket? Du får {numbersOfAcceptedGuesses} försök.");                       
            
            CheckGuesses(numbersOfAcceptedGuesses);

            Console.ReadLine();
        }
    }
}
