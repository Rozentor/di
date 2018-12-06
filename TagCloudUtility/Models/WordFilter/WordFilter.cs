﻿using System.Collections.Generic;
using System.Linq;

namespace TagCloud.Utility.Models.WordFilter
{
    /// <summary>
    /// Class for filtering words, deleting all words, which added, or with length less than minimalWordLength, selecting them to lower case
    /// </summary>
    public class WordFilter : IWordFilter
    {
        protected readonly HashSet<string> stopWords;
        protected readonly int minimalWordLength;

        public WordFilter(IEnumerable<string> stopWords,int minimalWordLength = 3)
        {
            this.stopWords = new HashSet<string>();
            foreach (var stopWord in stopWords)
                this.stopWords.Add(stopWord);
            this.minimalWordLength = minimalWordLength;
        }

        public string[] FilterWords(string[] words)
        {
            return words
                .Select(word => word.ToLower())
                .Where(word => word.Length > minimalWordLength
                               && !stopWords.Contains(word))
                .ToArray();
        }

        public void Add(string stopWord)
        {
            if (!stopWords.Contains(stopWord) && stopWord.Length >= minimalWordLength)
                stopWords.Add(stopWord);
        }
    }
}
