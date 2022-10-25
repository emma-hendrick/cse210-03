namespace Unit03.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private bool _isPlaying = true;
        private Library _library = new Library();
        private HiddenWord _hiddenWord;
        private TerminalService _terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            _hiddenWord = new HiddenWord(_library.GetWord(_terminalService.ReadNumber(
            "What difficulty setting would you like to play with? Valid difficulties are 0 - " + 
            _library.getMaxDifficulty() + ". ")), _terminalService);
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {

            _hiddenWord.DrawState();

            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Moves the seeker to a new location.
        /// </summary>
        private void GetInputs()
        {
            _hiddenWord.GuessLetter(_terminalService.ReadText("Guess a letter: "));
        }

        /// <summary>
        /// Keeps watch on where the seeker is moving.
        /// </summary>
        private void DoUpdates()
        {
            if(_hiddenWord.CheckWin() == 1) 
            {
                _terminalService.WriteText("Congratulations on your victory!!!");
                _isPlaying = false;
            }
            else if(_hiddenWord.CheckWin() == -1) 
            {
                _terminalService.WriteText("Congratulations on your... oh wait, you're like, totally dead... oops.");
                _terminalService.WriteText("...");
                _terminalService.WriteText("Oh, you wanted to know the word you missed? Ummmm... no.");
                _isPlaying = false;
            }
        }

        /// <summary>
        /// Provides a hint for the seeker to use.
        /// </summary>
        private void DoOutputs()
        {
            _hiddenWord.DrawState();
        }
    }
}