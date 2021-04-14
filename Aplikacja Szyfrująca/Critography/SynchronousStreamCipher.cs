using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class SynchronousStreamCipher
    {
        private readonly LFSR_Generator generator;

        public SynchronousStreamCipher(string startState, string polynomial)
        {
            this.generator = new LFSR_Generator(startState,polynomial);
        }
        private byte xor(byte value1, byte value2)
        {
            if (value1 == value2) return 0;
            else return 1;
        }
        public string Encrypt(string word)
        {
            byte[] wordArray = new byte[word.Length];
            int i = 0;
            foreach (var s in word)
            {
                wordArray[i] = (byte)(s - 48);
                i++;
            }

            string result = "";
            foreach(var value in wordArray)
            {
                byte res = xor(value, generator.GetNextValue());
                result += (char)(res + 48);
            }
            return result;
        }
        public string Decrypt(string word)
        {
            byte[] wordArray = new byte[word.Length];
            int i = 0;
            foreach (var s in word)
            {
                wordArray[i] = (byte)(s - 48);
                i++;
            }

            string result = "";
            foreach (var value in wordArray)
            {
                byte res = xor(value, generator.GetNextValue());
                result += (char)(res + 48);
            }
            return result;
        }
    }
}
