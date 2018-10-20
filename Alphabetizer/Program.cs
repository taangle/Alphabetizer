using System;
using System.Collections.Generic;
using System.IO;

namespace Alphabetizer
{
    static class Program
    {
        private const string ALPHA_START = ">>ALPHA>>";
        private const string ALPHA_END = "<<ALPHA<<";
        static void Main(string[] args)
        {
            Op operation;
            string path;
            if (args.Length == 1)
            {
                operation = Op.NewlineList;
                path = args[0];
            }
            else
            {
                string opString = args[0];
                path = args[1];
                switch (opString)
                {
                    case "-n":
                        operation = Op.NewlineList;
                        break;
                    default:
                        operation = Op.NewlineList;
                        break;
                }
            }

            // TODO: exception handling
            Alphabetize(path, operation);
        }

        private static void Alphabetize(string filePath, Op operation)
        {
            switch (operation)
            {
                    case Op.NewlineList:
                        AlphabetizeNewlineList(filePath, operation);
                        break;
            }
        }

        private static void AlphabetizeNewlineList(string filePath, Op operation)
        {
            List<string> preLines = new List<string>();
            List<string> postLines = new List<string>();
            List<string> alphaLines = null;
            using (StreamReader reader = new StreamReader(filePath))
            {
                bool preAlpha = true;
                // get each line until end of file
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (line.Equals(ALPHA_START))
                    {
                        alphaLines = InAlphaNewlineLines(reader);
                        preAlpha = false;
                    }
                    else if (preAlpha)
                    {
                        preLines.Add(line);
                    }
                    else
                    {
                        postLines.Add(line);
                    }
                }
            }

            alphaLines?.Sort();
            ReplaceAlphaNewlineLines(filePath, preLines, alphaLines, postLines);
        }

        // TODO: make sure you can handle empty strings
        private static void ReplaceAlphaNewlineLines(string filePath, List<string> preLines, List<string> alphaLines, List<string> postLines)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string preLine in preLines)
                {
                    writer.WriteLine(preLine);
                }

                foreach (string alphaLine in alphaLines)
                {
                    writer.WriteLine(alphaLine);
                }

                foreach (string postLine in postLines)
                {
                    writer.WriteLine(postLine);
                }
            }
        }

        private static List<string> InAlphaNewlineLines(StreamReader reader)
        {
            var lines = new List<string>();

            // TODO: deal with reaching EOF w/out reaching ALPHA_END
            string line = reader.ReadLine();
            while (line != ALPHA_END)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }

            return lines.Count > 0 ? lines : null;
        }
    }

    enum Op
    {
        NewlineList
    }
}