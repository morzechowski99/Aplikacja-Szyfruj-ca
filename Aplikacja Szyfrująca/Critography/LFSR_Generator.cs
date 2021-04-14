using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacja_Szyfrująca.Critography
{
    public class LFSR_Generator
    {
        private byte[] state;
        private List<int> taps;
        public LFSR_Generator(string startState, string polynomial)
        {
            state = new byte[startState.Length];
            int i = 0;
            foreach(var s in startState)
            {
                state[i] = (byte)(s - 48);
                i++;
            }
            taps = new List<int>();
            i = 0;
            foreach(var s in polynomial)
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

        private byte shift()
        {
            byte newHead = state[taps[0]];
            foreach(var idx in taps.Skip(1))
            {
                newHead = xor(newHead, state[idx]);
            }
            byte oldValue = state[0];
            for(int i = 0; i< state.Length; i++)
            {
                if(i != state.Length - 1)
                {
                    byte temp = state[i + 1];
                    state[i + 1] = oldValue;
                    oldValue = temp;
                }
            }
            state[0] = newHead;
            return newHead;
        }
        public byte GetNextValue()
        {
            //byte value = state[state.Length - 1];
            return shift();
          //  return value;
        }
    }
}
