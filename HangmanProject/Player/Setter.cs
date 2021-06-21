using System;

namespace HangmanProject.Player
{
    public class Setter : IPlayer
    {

        private Game _game;
        private string _name;
        private PlayerType _type;
        
        public Setter(string name, PlayerType type)
        {
            _name = name;
            _type = type;
        }
        
        public PlayerType GetType()
        {
            return _type;
        }
        
        public string GetName()
        {
            return _name;
        }

        public void MountGame(Game game)
        {
            _game = game;

            Console.WriteLine($"{this._name} Enter your word");
            string word = Console.ReadLine();

            _game.TargetWord = word;
        }

        public void OnRoundProgressed()
        {
            
        }

        public void OnWinGame()
        {
            Console.WriteLine($"{this._name}: You've won the game!");
        }

        public void OnLoseGame()
        {
            Console.WriteLine($"{this._name}: You've lost the game!");
        }
    }
}