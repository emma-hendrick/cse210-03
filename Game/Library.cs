using System;
using System.Collections.Generic;


namespace Unit03.Game
{

    /// <summary>
    /// <para>A generator for the hidden words.</para>
    /// <para>
    /// The responsibility of a Library is to generate hidden words by difficulty.
    /// </para>
    /// </summary>
    public class Library
    {
        private List<List<string>> words = new List<List<string>>() {
            new List<string>() {"Apple", "Banana", "Conceptualize"},
            new List<string>() {"Kiwi", "Locale", "Swan", "Preen"},
            new List<string>() {"Injury", "Absurd", "Avenue", "Fluff", "Rhythm"},
            new List<string>() {"Haiku", "Quizzes", "Hyphen", "Zygote", "Abyss", "Askew", "Razzmatazz", "Rhubarb"},
        };
        
        /// <summary>
        /// Constructs a new instance of Library.
        /// </summary>
        public Library() 
        {
            
        }
        
        /// <summary>
        /// Generates a random word of the given difficulty.
        /// </summary>
        /// <param name="difficulty">The library difficulty to use.</param>
        /// <returns>The word that is randomly chosen.</returns>
        public string GetWord(int difficulty) 
        {

            // Get a word list from the library by the given difficulty,
            // Pick a random index up to the length of that list, and choose
            // The respective word
            List<string> wordOptions = words[difficulty];
            
            Random random = new Random();
            int wordIndex = random.Next(wordOptions.Count);

            return wordOptions[wordIndex];

        }
        
        /// <summary>
        /// Returns the maximum difficulty.
        /// </summary>
        /// <returns>The maximum difficulty.</returns>
        public int getMaxDifficulty()
        {
            return words.Count - 1;
        }
    }
}