using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class MatrixShift 
    {
        //d-5, key 3-4-1-5-2
        private static int D = 5;
        private static int[] KEY = new int[] { 2, 3, 0, 4, 1 }; 
        private static int[] KEY_DECRYPT = new int[] { 2, 4, 0, 1, 3 }; 
        public string Encrypt(string word)
        {
            int rows;
            char[,] matrix = GetMatrix(word, out rows);
            return GetEncryptedFromMatrix(matrix, rows);
        }

        public string Decrypt(string word)
        {
            int rows;
            char[,] matrix = GetMatrixToDecode(word, out rows);
            return GetDectryptedFromMatrix(matrix, rows);
        }

        private char[,] GetMatrixToDecode(string word, out int rows)
        {
            int lastRowMaxColumn = 4;
            if (word.Length % D == 0)
            {
                rows = word.Length / D;
            }
            else {
                rows = word.Length / D + 1;
                lastRowMaxColumn = D - (D * rows - word.Length) - 1;
            }

            char[,] matrix = new char[rows, D];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                
                foreach (var col in KEY)
                {
                    if (i < rows - 1)
                    {
                        matrix[i, col] = word[index++];
                        
                    }
                    else
                    {
                        if (col <= lastRowMaxColumn && index < word.Length)
                        {
                            matrix[i, col] = word[index++];
                            
                        }
                    }
                    

                }
            }
            return matrix;
        }

        private string GetDectryptedFromMatrix(char[,] matrix, int rows)
        {
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for(int j= 0; j<D;j++)
                {
                    if (matrix[i, j] != '\0') 
                    result += matrix[i, j];

                }
            }
            return result;
        }

        private string GetEncryptedFromMatrix(char[,] matrix,int rows)
        {
            string result = "";
            for(int i = 0; i < rows; i++)
            {
                foreach(var column in KEY)
                {
                    char toResult = matrix[i, column];
                    if (toResult != '\0') result += toResult;
                    
                }

            }
            return result;
        }

        private char[,] GetMatrix(string word,out int rows)
        {
            if(word.Length % D == 0)
            {
                rows = word.Length / D;
            }
            else
                rows = word.Length / D + 1;


            char[,] matrix = new char[rows, D];
            int index = 0;
            int lastIndex = word.Length -1 ;
            for(int i = 0;i < rows; i++)
                for(int j = 0; j < D; j++)
                {
                    matrix[i, j] = word[index];
                    if (index == lastIndex) break;
                    index++;
                }
            return matrix;
        }

        

        
    }
}
