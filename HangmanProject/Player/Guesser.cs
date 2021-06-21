using System;

namespace HangmanProject.Player
{
    public class Guesser : IPlayer
    {

        private string _name;
        private uint _guessesLeft;
        private PlayerType _type;
        private Game _game;
        public Guesser(string name, PlayerType type)
        {
            _name = name;
            _type = type;
            _guessesLeft = 5;
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
        }

        public void OnRoundProgressed()
        {
            Console.WriteLine($"{this._name}: Enter your guess, you have {_guessesLeft} guesses left :");
            var readWord = Console.ReadLine();
            
            // Keep retrying so the player will enter a correctly formatted string of text.
            while (readWord.ToCharArray().Length == 0 || _game.GuessedLetters.ContainsKey(readWord.ToCharArray()[0]))
            {
                
                Console.WriteLine("Please enter in a character (that you haven't already entered).");
                readWord = Console.ReadLine();
            }

            // Get the first letter of the character array.
            char character = readWord.ToCharArray()[0];
            
            var answerCorrect = _game.IsCharacterInWord(character.ToString());
            _game.GuessedLetters.Add(character, answerCorrect);
            
            Console.WriteLine($"Your guess: {character} Is{(answerCorrect ? " " : " Not ")}correct");

            if (!answerCorrect)
            {
                _game.OnWrongGuess(this);
            }
            
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