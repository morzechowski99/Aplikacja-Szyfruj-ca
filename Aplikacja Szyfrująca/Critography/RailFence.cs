using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class RailFence : ICriptographyAlgorithm
    {
        public string Encrypt(string word, int key)
        {
            List<char>[] encryptArray = new List<char>[key];
            bool isIncrement = true;
            for (int i = 0; i < key; i++)
            {
                encryptArray[i] = new List<char>();
            }
            int index = 0;
            foreach (var c in word)
            {
                encryptArray[index].Add(c);
                if (isIncrement)
                {
                    if (index < key - 1)
                        index++;
                    else
                    {
                        isIncrement = false;
                        index--;
                    }
                }
                else
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        isIncrement = true;
                        index++;
                    }
                }
            }
            string encrypted = "";
            foreach (var list in encryptArray)
            {
                foreach (char c in list)
                {
                    encrypted += c;
                }
            }
            return encrypted;
        }

        public string Decrypt(string encryptedWord, int key)
        {
            char[,] rail = new char[key, encryptedWord.Length];

            bool isIncrement = true;

            int row = 0, col = 0;

            for (int i = 0; i < encryptedWord.Length; i++)
            {
                // check the direction of flow 
                if (row == 0)
                    isIncrement = true;
                if (row == key - 1)
                    isIncrement = false;

                // place the marker 
                rail[row, col++] = '*';

                // find the next row using direction flag 
                row = isIncrement ? ++row : --row;
            }

            // now we can construct the fill the rail matrix 
            int index = 0;
            for (int i = 0; i < key; i++)
                for (int j = 0; j < encryptedWord.Length; j++)
                    if (rail[i, j] == '*' && index < encryptedWord.Length)
                        rail[i, j] = encryptedWord[index++];

            string result = "";

            row = 0;
            col = 0;

            for (int i = 0; i < encryptedWord.Length; i++)
            {
                // check the direction of flow 
                if (row == 0)
                    isIncrement = true;
                if (row == key - 1)
                    isIncrement = false;

                // place the marker 
                if (rail[row, col] != '*')
                    result += rail[row, col++];

                // find the next row using direction flag 
                row = isIncrement ? ++row : --row;
            }
            return result;
        }
    }
}
