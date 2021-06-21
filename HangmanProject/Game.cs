using System;
using System.Collections.Generic;
using System.Linq;
using HangmanProject.Hangman;
using HangmanProject.Player;

namespace HangmanProject
{
    public class Game
    {
        public bool IsComplete = false;
        
        private List<IPlayer> _players = new ();
       
        private IHangman _hangman;
        internal Dictionary<char, bool> GuessedLetters { get; set; }
        internal string TargetWord { get; set; }

        public Game()
        {
            GuessedLetters = new Dictionary<char, bool>();
        }

        /// <summary>
        /// Called to populate the fields of the class.
        /// </summary>
        public void Start()
        {
            _hangman = new Hangman.Hangman();
        }

        public void OnEventLoop()
        {

            foreach (var player in _players)
            {
                player.OnRoundProgressed();
            }

            if (_hangman.IsComplete())
            {
                OnGameComplete(false);
                return;
            }
            
            if (IsAllCharactersGuessed())
            {
                OnGameComplete(true);
                return;
            }
            
            _hangman.DrawHangman();
        }

        /// <summary>
        /// Called when a player has entered a wrong guess.
        /// </summary>
        /// <param name="sender"> The Player who entered the command .</param>
        internal void OnWrongGuess(IPlayer sender)
        {
            _hangman.IncrementHangman();
            Console.WriteLine(_hangman.IsComplete());
        }

        /// <summary>
        /// Checks if the character is in the word.
        /// </summary>
        /// <param name="letter">The letter entered by the player.</param>
        /// <returns></returns>
        public bool IsCharacterInWord(string letter) => TargetWord.Contains(letter);

        public bool IsAllCharactersGuessed() => TargetWord.ToCharArray().All(chr => GuessedLetters.ContainsKey(chr));
        
        private void AddPlayer(IPlayer player)
        {
            this._players.Add(player);
        }
        
        private IPlayer GetPlayer(PlayerType type)
        {
            return this._players.First(ply => ply.GetType() == type);
        }

        public void OnGameComplete(bool guesserWon)
        {
            IsComplete = true;
            var guesser = GetPlayer(PlayerType.Guesser);
            var setter = GetPlayer(PlayerType.Setter);
            if (guesserWon)
            {
                setter.OnLoseGame();
                guesser.OnWinGame();
            }
            else
            {
                guesser.OnLoseGame();
                setter.OnWinGame();
            }
        }

        /// <summary>
        /// Create a player from the name and desired type.
        /// This is an abstract factory.
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="type">The type of the player</param>
        /// <returns>The created IPlayer</returns>
        public IPlayer CreatePlayer(string name, PlayerType type)
        {
            IPlayer player = type switch
            {
                PlayerType.Guesser => new Guesser(name, type),
                PlayerType.Setter => new Setter(name, type),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
            player.MountGame(this);
            
            AddPlayer(player);
            return player;
        }
    }
}