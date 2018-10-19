using System;
using System.Collections.Generic;
using System.IO;

namespace Alphabetizer
{
    class Program
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
            List<string> lines = null;
            using (StreamReader reader = new StreamReader(filePath))
            {
                // get each line until end of file
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (line.Equals(ALPHA_START))
                    {
                        lines = InAlphaNewlineLines(reader);
                        break;
                    }
                }
            }

            lines?.Sort();
            ReplaceAlphaNewlineLines(filePath, lines);
        }

        private static void ReplaceAlphaNewlineLines(string filePath, List<string> lines)
        {
            throw new NotImplementedException();
        }

        private static List<string> InAlphaNewlineLines(StreamReader reader)
        {
            throw new NotImplementedException();
        }
    }

    enum Op
    {
        NewlineList
    }
}