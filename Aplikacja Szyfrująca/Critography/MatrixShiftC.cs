using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class MatrixShiftC
    {
        public string Encrypt(string word, string key)
        {
            var ranking = GetRanking(key);
            int x = key.Length;
            char[,] matrix = new char[x, x];
            int index = 0;
            int i = 0;
            foreach(var item in ranking)
            {
                int column = item.Rank;
                for(int j = 0; j <=column;j++)
                {
                    if (index == word.Length) break;

                    matrix[i, j] = word[index++];
                }
                i++;
            }

            string result = "";

            foreach (var elem in ranking)
            {
                for (int j = 0; j < x; j++)
                {
                    if (matrix[j, elem.Rank] != '\0') result += matrix[j, elem.Rank];
                }
            }

            return result;
        }

        public string Decrypt(string word, string key)
        {
            var ranking = GetRanking(key);
            int x = key.Length;
            char[,] matrix = new char[x, x];
            int index = 0;
            int i = 0;
            foreach (var item in ranking)
            {
                int column = item.Rank;
                for (int j = 0; j <= column; j++)
                {
                    if (index == word.Length) break;

                    matrix[i, j] = '#';
                    index++;
                }
                i++;
            }
            index = 0;
            
            foreach(var item in ranking)
            {
                int column = item.Rank;
                for(int j = 0; j< x;j++)
                {
                    if (matrix[j, column] == '#') matrix[j, column] = word[index++];
                }
            }

            string result = "";

            for(int a = 0; a< x; a++)
                for(int b = 0; b<x;b++)
                {
                    if (matrix[a, b] != '\0') result += matrix[a, b];
                }
            return result;
        }
        private List<LetterWithRank> GetRanking(string key)
        {
            int index = 0;
            List<LetterWithRank> letterWithRanks = new List<LetterWithRank>();
            foreach (var letter in key)
            {
                letterWithRanks.Add(new LetterWithRank(letter, index++));
            }

            letterWithRanks.Sort((el1, el2) =>
            {
                if (el1.Letter == el2.Letter) return 0;
                else if (el1.Letter < el2.Letter) return -1;
                else return 1;
            });
            return letterWithRanks;
        }
        private struct LetterWithRank
        {
            internal char Letter { get; set; }
            internal int Rank { get; set; }

            internal LetterWithRank(char letter, int rank)
            {
                Letter = letter;
                Rank = rank;
            }
        }
    }
}
