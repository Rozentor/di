﻿using System.Drawing;
using System.Linq;
using CommandLine;
using TagCloud.Visualizer.Settings;

namespace TagCloud.Utility
{
    public class Options
    {
        [Option('w', "words", Required = true,
            HelpText = "Path to words in format .../words.txt (type is required)")]
        public string PathToWords { get; set; }

        public string WordsFileType => PathToWords.Split('.').Last();

        [Option('p', "picture", Required = true,
            HelpText = "Path to picture in format .../picture.png (type is required)")]
        public string PathToPicture { get; set; }

        [Option('d', "drawSettings", Default = DrawFormat.WordsInRectangles,
            HelpText = "Draw settings:" +
                       "(only words == 0)" +
                       "(words in rectangles == 1)" +
                       "(only rectangles == 2)" +
                       "(rectangles with numeration == 3)")]
        public DrawFormat DrawFormat { get; set; }

        [Option('t', "tags",
            HelpText = "Path to tags in format .../tags.txt (type is required)")]
        public string PathToTags { get; set; }

        [Option('c', "color",
            HelpText = "Color of brush(in html color)", Default = "#000000")]
        public string Color { get; set; }

        [Option('s', "size",
            HelpText = "Size of picture in format (width)x(height)")]
        public string Size { get; set; }

        [Option('f', "font",
            HelpText = "Font family name", Default = "arial")]
        public string Font { get; set; }

        [Option("stopWords",
            HelpText = "Path to stop words in format .../stopwords.txt (type is required)")]
        public string PathToStopWords { get; set; }
    }
}