using System;
using System.Collections.Generic;


namespace Unit03.Game 
{
    /// <summary>
    /// <para>The word the user is trying to guess.</para>
    /// <para>
    /// The responsibility of HiddenWord is to track the secret word, the guesses the player has made, and to report whether thayve won, lost, or neither when they make a guess.
    /// </para>
    /// </summary>
    public class HiddenWord
    {
        private string _word = "";
        private List<string> _guesses = new List<string>();
        private int _maxGuesses = 5;
        private int _remainingGuesses;
        private TerminalService _terminalService;

        /// <summary>
        /// Constructs a new instance of HiddenWord. 
        /// </summary>
        /// <param name="word">The word being guessed.</param>
        /// <param name="terminalService">The terminal service.</param>
        public HiddenWord(string word, TerminalService terminalService)
        {

            _word = word;
            _terminalService = terminalService;
            _remainingGuesses = _maxGuesses;

        }

        /// <summary>
        /// Lets the guesser guess a word
        /// </summary>
        /// <param name="guess">The word being guessed.</param>
        public void GuessLetter(string guess) {

            if (!getWordStringList().Contains(guess))
            {
                _remainingGuesses -= 1;
            }

            _guesses.Add(guess.ToLower());

        }

        /// <summary>
        /// Converts the hidden word to a list of strings.
        /// </summary>
        /// <returns>The word as a list of each character as a string.</returns>
        private List<string> getWordStringList()
        {

            List<string> _wordString = new List<string>();

            foreach (char letter in _word)
            {
                _wordString.Add(letter.ToString().ToLower());
            }

            return _wordString;

        } 

        /// <summary>
        /// Gets a hint for the guesser.
        /// </summary>
        /// <returns>A new hint.</returns>
        private string GetHint()
        {

            List<string> _wordString = getWordStringList();
            string result = " ";

            _wordString.ForEach(letter => {

                result += (_guesses.Contains(letter)) ? letter + " ": "_ ";

            });

            return result;

        }

        /// <summary>
        /// Whether or not the hidden word has been guessed.
        /// </summary>
        /// <returns>1 if found; -1 if game over, 0 otherwise.</returns>
        public int CheckWin()
        {

            List<string> _wordString = getWordStringList();
            _guesses.ForEach(guess => 
            {

                int index = _wordString.IndexOf(guess);
                while (index != -1)
                {
                    _wordString.RemoveAt(index);
                    index = _wordString.IndexOf(guess);
                }

            });
            bool isWin = (_wordString.Count == 0);
            bool isLost = (_remainingGuesses == 0);
            return isWin ? 1: isLost ? -1: 0;

        }

        /// <summary>
        /// Draw the parachute.
        /// </summary>
        /// <returns>A string representing the parachute.</returns>
        public string DrawChute()
        {

            List<string> chute = new List<string>();
            chute.Add(" _________ ");
            chute.Add("/         \\");
            chute.Add("\\         /");
            chute.Add(" \\       / ");
            chute.Add("  \\     /  ");
            chute.Add("   \\ O /   ");
            chute.Add("    \\|/    ");
            chute.Add("     |     ");
            chute.Add("    / \\    ");

            chute.RemoveRange(0, _maxGuesses - _remainingGuesses);

            return string.Join('\n', chute);

        }

        /// <summary>
        /// Draw the current state of the board.
        /// </summary>
        public void DrawState()
        {

            _terminalService.WriteText(DrawChute());
            _terminalService.WriteText(GetHint());

        }
    }
}