using System;

class Program
{
    static void Main()
    {
        Random random = new();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = random.Next(1, 101);
            int numberOfGuesses = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            int userGuess = -1;

            while (userGuess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                if (int.TryParse(Console.ReadLine(), out userGuess))
                {
                    numberOfGuesses++;

                    if (userGuess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (userGuess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            Console.WriteLine($"You guessed the number in {numberOfGuesses} attempts.");

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}
