using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Caesar3b : ICrypter
    {
        Dictionary<char, int> alphabetDictionary = new Dictionary<char, int>();
        StringBuilder builder;
        int n;
        int k0;
        int k1;
        int eulerNumber;

        public Caesar3b(int key0, int key1)
        {
            this.k0 = key0;
            this.k1 = key1;
            eulerNumber = 12;
            var alphabetUpperArray = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            var alphabetLowerArray = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
            var numberArray = Enumerable.Range('0', 10).Select(x => (char)x).ToArray();
            int nUpper = alphabetUpperArray.Count();
            int nLower = alphabetLowerArray.Count();
            int nNumber = numberArray.Count();

            char[] finalArray=new char[nUpper+nLower+nNumber];
            Array.Copy(alphabetUpperArray, finalArray, nUpper);
            Array.Copy(alphabetLowerArray,0, finalArray, nUpper,nLower);
            Array.Copy(numberArray, 0, finalArray, nUpper+nLower, nNumber);

            n = finalArray.Count();
            for (int i = 0; i < n; i++) alphabetDictionary.Add(finalArray[i], i);
        }

        public string Encrypt(string text)
        {
            builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                builder.Append(EncryptOneLetter(text[i]));
            }
            return builder.ToString();
        }

        public string Decrypt(string text)
        {
            builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                builder.Append(DecryptOneLetter(text[i]));
            }
            return builder.ToString();
        }

        private char EncryptOneLetter(char a)
        {
            if (a == ' ')
            {
                return ' ';
            }
            //var asasas = alphabetDictionary.Keys.ElementAt((((alphabetDictionary[a]) * k1 + k0) % n));
            //return (char)(((alphabetDictionary[a]) * k1 + k0) % n);
            return alphabetDictionary.Keys.ElementAt((((alphabetDictionary[a]) * k1 + k0) % n));
        }

        private char DecryptOneLetter(char c)
        {
            if (c == ' ')
            {
                return ' ';
            }

            //char charOut = (char)((c - 65) + (n - k0));
            //for (int i = 0; i < 11; i++)
            //{
            //    charOut *= (char)(k1);
            //    charOut %= (char)(n);
            //}
            //return (char)(charOut + 65);

            int charOut = (alphabetDictionary[c] + (n - k0));
            for (int i = 0; i < 29; i++)
            {
                charOut *= k1;
                charOut %= n;
            }
            return alphabetDictionary.Keys.ElementAt(charOut);
        }
    }
}
