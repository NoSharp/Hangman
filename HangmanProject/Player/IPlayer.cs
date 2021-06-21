namespace HangmanProject.Player
{
    public interface IPlayer
    {

        PlayerType GetType();
        
        /// <summary>
        /// Used to access the name of the player.
        /// </summary>
        string GetName();
        
        /// <summary>
        /// Called when the player is created.
        /// </summary>
        /// <param name="game">The Current game state.</param>
        void MountGame(Game game);

        /// <summary>
        /// Called when the game progresses one round.
        /// </summary>
        void OnRoundProgressed();

        /// <summary>
        /// Called when the player wins the game.
        /// </summary>
        void OnWinGame();

        /// <summary>
        /// Called when the player has lost the game.
        /// </summary>
        void OnLoseGame();
    }
}