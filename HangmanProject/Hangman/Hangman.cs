using System;

namespace HangmanProject.Hangman
{
    public class Hangman : IHangman
    {
        // The amount of guesses that it's taken.
        // 
        private uint hangmanPosition;
        
        public void IncrementHangman()
        {
            hangmanPosition++;
        }

        public bool IsComplete()
        {
            return hangmanPosition == 5;
        }

        public void DrawHangman()
        {
            Console.WriteLine($"You have {5-hangmanPosition} chances left");
        }
    }
}