using System;
using System.Text;
using System.Collections.Generic;

class GFG : IComparer<int>
{
    /* I do not have a clue what this class is and how it works with
    the itemLens.Sort(gg) stuff, I honestly copy and pasted it, I'm just telling the shameless truth. */
    public int Compare(int x, int y)
    {
        if (x == 0 || y == 0)
        {
            return 0;
        }

        return x.CompareTo(y);
    }
}

namespace TableIO
{
    class Table
    {
        public int Length = 0;
        
        public Table()
        {
            this.Length = 0;
        }

        static int Main()
        {
            // Entry Point

            // Creating dict to be converted to table 
            var dict = new Dictionary<string, string>();
            for (int count = 0; count <= 100; count++)
            {
                dict.Add("MyReallyCoolKey" + count.ToString(), "MyReallyCoolValue" + count.ToString());
            }

            Table instance = new Table();
            instance.CreateSimpleTable(dict);
            return 0;
        }

        // Method used for repeating a character n-amount of times
        private string RepeatCharacter(char character, int times)
        {
            return new String(character, times);
        }

        public void CreateSimpleTable(Dictionary<string, string> dict, string header = "")
        {
            // Openly usable Method || Method can only create a table with a hLength of 2 ( dict related )
            // Assigning variables for longest key & value elements in dict <- (@param)
            int[] retrievedLengthData = GetLongestItem(dict);
            int longestKey = retrievedLengthData[0];
            int longestValue = retrievedLengthData[1];

            // creating variables for visual stuff
            string horizontalCloserA = RepeatCharacter('=', longestKey+2);
            string horizontalCloserB = RepeatCharacter('=', longestValue+2);
            string fullHorizontalCloser = '+' + horizontalCloserA + '=' + horizontalCloserB + '+';

            // Writing Top Closer
            Console.WriteLine(fullHorizontalCloser);

            // Creating variable responsible for assigning this.Length attribute
            int localLineCount = 0;
            
            // vertical Start / End Closers ("|"), will be created in loop during runtime
            foreach (string element in dict.Keys)
            {  
                // Calculating spaces needed for every element in table, so '|' doesn't get unintentionally moved
                int spacesNeededA = longestKey - element.Length;
                int spacesNeededB = longestValue - dict[element].Length;

                // Using spaces calculated above to write Key column and value column
                string linePartA = "| " + element + RepeatCharacter(' ', spacesNeededA);
                string linePartB = " | " + dict[element] + RepeatCharacter(' ', spacesNeededB) + " |";
                string fullLine = linePartA + linePartB;

                // You guessed it, ouputting the current line in your table
                Console.WriteLine(fullLine);

                // adding this.Length attribute responsible variable / preparing for assignment
                localLineCount++;
            }

            // Writing Bottom Closer
            Console.WriteLine(fullHorizontalCloser);

            // setting attribute
            this.Length = localLineCount;
        }

        private int[] GetLongestItem(Dictionary<string, string> givenDict)
        {
            List<int> keyLens = new List<int>();
            // Appending array with all the lengths of each key in array
            foreach (string element in givenDict.Keys)
            {
                keyLens.Add(element.Length);
            }

            // Appending array with all the lengths of each item in array
            List<int> valueLens = new List<int>();
            foreach(string value in givenDict.Values)
            {
                valueLens.Add(value.Length);
            }

            // Sorting List 'n stuff like that, ya get it
            GFG gg = new GFG();
            keyLens.Sort(gg);
            valueLens.Sort(gg);

            int[] longestElements = new int[2] { keyLens[keyLens.Count - 1], valueLens[valueLens.Count - 1] };

            // index[0] -> longest key; index[1] -> longest item;
            return longestElements;
        }
    }
}
