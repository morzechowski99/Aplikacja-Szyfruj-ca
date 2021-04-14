using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class CiphertextAutokey
    {
        public string Encrypt(string word,string startState, string polynomial)
        {
            byte[] wordArray = new byte[word.Length];
            int i = 0;
            foreach (var s in word)
            {
                wordArray[i] = (byte)(s - 48);
                i++;
            }
            LFSR_Encrypt encrypt = new LFSR_Encrypt(startState, polynomial);
            string result = "";
            foreach (var value in wordArray)
            {
                byte res = encrypt.GetNextValue(value);
                result += (char)(res + 48);
            }
            return result;
        }

        public string Decrypt(string word, string startState, string polynomial)
        {
            byte[] wordArray = new byte[word.Length];
            int i = 0;
            foreach (var s in word)
            {
                wordArray[i] = (byte)(s - 48);
                i++;
            }
            LFSR_Decrypt decrypt = new LFSR_Decrypt(startState, polynomial);
            string result = "";
            foreach (var value in wordArray)
            {
                byte res = decrypt.GetNextValue(value);
                result += (char)(res + 48);
            }
            return result;
        }

        private class LFSR_Encrypt
        {
            private byte[] state;
            private List<int> taps;
            public LFSR_Encrypt(string startState, string polynomial)
            {
                state = new byte[startState.Length];
                int i = 0;
                foreach (var s in startState)
                {
                    state[i] = (byte)(s - 48);
                    i++;
                }
                taps = new List<int>();
                i = 0;
                foreach (var s in polynomial)
                {
                    if (s == '1') taps.Add(i);
                    i++;
                }
            }

            private byte xor(byte value1, byte value2)
            {
                if (value1 == value2) return 0;
                else return 1;
            }

            private byte shift(byte input)
            {
                byte newHead = state[taps[0]];
                newHead = xor(input, newHead);
                foreach (var idx in taps.Skip(1))
                {
                    newHead = xor(newHead, state[idx]);
                }
                byte oldValue = state[0];
                for (int i = 0; i < state.Length; i++)
                {
                    if (i != state.Length - 1)
                    {
                        byte temp = state[i + 1];
                        state[i + 1] = oldValue;
                        oldValue = temp;
                    }
                }
                state[0] = newHead;
                return newHead;
            }
            public byte GetNextValue(byte nextInputValue)
            {
                //byte value = state[state.Length - 1];
                return shift(nextInputValue);
                //  return value;
            }
        } 
        private class LFSR_Decrypt
        {
            private byte[] state;
            private List<int> taps;
            public LFSR_Decrypt(string startState, string polynomial)
            {
                state = new byte[startState.Length];
                int i = 0;
                foreach (var s in startState)
                {
                    state[i] = (byte)(s - 48);
                    i++;
                }
                taps = new List<int>();
                i = 0;
                foreach (var s in polynomial)
                {
                    if (s == '1') taps.Add(i);
                    i++;
                }
            }

            private byte xor(byte value1, byte value2)
            {
                if (value1 == value2) return 0;
                else return 1;
            }

            private void shift(byte input)
            {
 
                byte oldValue = state[0];
                for (int i = 0; i < state.Length; i++)
                {
                    if (i != state.Length - 1)
                    {
                        byte temp = state[i + 1];
                        state[i + 1] = oldValue;
                        oldValue = temp;
                    }
                }
                state[0] = input;
                
            }
            public byte GetNextValue(byte nextInputValue)
            {
                byte value = nextInputValue;
                foreach (var idx in taps)
                {
                    value = xor(value, state[idx]);
                }
                shift(nextInputValue);
                return value;
            }
        }
    }
}
