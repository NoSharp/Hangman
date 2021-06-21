using System;
using HangmanProject.Player;

namespace HangmanProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start();

            Console.WriteLine("Enter the name of the guesser:");
            string guesserName = Console.ReadLine();
            game.CreatePlayer(guesserName, PlayerType.Guesser);
            
            Console.WriteLine("Enter the name of the Setter:");
            string setterName = Console.ReadLine();
            game.CreatePlayer(setterName, PlayerType.Setter);
            
            while (true)
            {
                if (game.IsComplete) break;
                game.OnEventLoop();
            }
        }
    }
}
