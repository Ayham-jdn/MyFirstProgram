// File: SimpleRockPaperScissors/Game.cs
using System;

namespace SimpleRockPaperScissors
{
    // Represents a player (human or computer)
    class Player
    {
        public string Name { get; set; }
        public string Choice { get; private set; }

        public void MakeChoice()
        {
            Choice = "";
            while (Choice != "ROCK" && Choice != "PAPER" && Choice != "SCISSORS")
            {
                Console.Write($"{Name}, enter ROCK, PAPER, or SCISSORS: ");
                Choice = Console.ReadLine().ToUpper();
                if (Choice != "ROCK" && Choice != "PAPER" && Choice != "SCISSORS")
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        public void SetComputerChoice(Random random)
        {
            Choice = random.Next(1, 4) switch
            {
                1 => "ROCK",
                2 => "PAPER",
                3 => "SCISSORS",
                _ => "ROCK"
            };
        }
    }

    // Represents the game logic
    class Game
    {
        private Player human;
        private Player computer;
        private Random random;

        public Game(string playerName)
        {
            human = new Player { Name = playerName };
            computer = new Player { Name = "Computer" };
            random = new Random();
        }

        public void PlayRound()
        {
            human.MakeChoice();
            computer.SetComputerChoice(random);

            Console.WriteLine($"Player: {human.Choice}");
            Console.WriteLine($"Computer: {computer.Choice}");

            if (human.Choice == computer.Choice)
                Console.WriteLine("It's a draw!");
            else if ((human.Choice == "ROCK" && computer.Choice == "SCISSORS") ||
                     (human.Choice == "PAPER" && computer.Choice == "ROCK") ||
                     (human.Choice == "SCISSORS" && computer.Choice == "PAPER"))
                Console.WriteLine("You win!");
            else
                Console.WriteLine("You lose!");
        }
    }

    // Entry point
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            Game game = new Game(playerName);

            string playAgain;
            do
            {
                game.PlayRound();
                Console.Write("Do you want to play again? (Y/N): ");
                playAgain = Console.ReadLine().ToUpper();
            } while (playAgain == "Y");

            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
    }
}
