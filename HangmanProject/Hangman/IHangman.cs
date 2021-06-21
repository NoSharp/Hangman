namespace HangmanProject.Hangman
{
    public interface IHangman
    {
        /// <summary>
        /// Used to increment the hangman state.
        /// </summary>
        void IncrementHangman();

        /// <summary>
        /// Whether the Hangman complete, and the game should
        /// be ended.
        /// </summary>
        /// <returns> Is the hangman complete </returns>
        bool IsComplete();

        /// <summary>
        /// Draw the hangman on the screen.
        /// </summary>
        void DrawHangman();
    }
}