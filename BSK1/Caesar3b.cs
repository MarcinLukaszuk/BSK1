using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Caesar3b : ICrypter
    {
        Dictionary<char, int> alphabetUpperDictionary = new Dictionary<char, int>();
        Dictionary<char, int> alphabetLowerDictionary = new Dictionary<char, int>();
        Dictionary<char, int> numberDictionary = new Dictionary<char, int>();
        StringBuilder builder;
        int upperCount;
        int lowerCount;
        int numberCount;
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
            upperCount = alphabetUpperArray.Count();
            lowerCount= alphabetLowerArray.Count();
            numberCount = numberArray.Count();
            for (int i = 0; i < upperCount; i++) alphabetUpperDictionary.Add(alphabetUpperArray[i], i+65);
            for (int i = 0; i < lowerCount; i++) alphabetLowerDictionary.Add(alphabetLowerArray[i], i+97);
            for (int i = 0; i < numberCount; i++) numberDictionary.Add(numberArray[i], i+48);
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
            if (a >= 65 && a < 91)
            {
                return (char)(((a-65) * k1 + k0) % upperCount + 65);
                
            }
            else if (a >= 97 && a < 123)
            {
                return (char)(((a-97) * k1 + k0) % lowerCount + 97);
            }
            else if (a >= 48 && a < 58)
            {
                return (char)(((a - 48) * k1 + k0) % numberCount + 48);
            }
            else
            {
                return ' ';
            }
        }

        private char DecryptOneLetter(char c)
        {
            if (c == ' ')
            {
                return ' ';
            }
            if (c >= 65 && c < 91)
            {
                char charOut = (char)((c - 65) + (upperCount - k0));

                for (int i = 0; i < 11; i++)
                {
                    charOut *= (char)(k1);
                    charOut %= (char)(upperCount);
                }

                return (char)(charOut + 65);
            }
            else if (c >= 97 && c < 123)
            {
                char charOut = (char)((c - 97) + (lowerCount - k0));

                for (int i = 0; i < 11; i++)
                {
                    charOut *= (char)(k1);
                    charOut %= (char)(lowerCount);
                }

                return (char)(charOut + 97);
            }
            else if (c >= 48 && c < 58)
            {
                char charOut = (char)((c - 48) + (numberCount - k0));

                for (int i = 0; i < 11; i++)
                {
                    charOut *= (char)(k1);
                    charOut %= (char)(numberCount);
                }

                return (char)(charOut + 48);
            }
            else
            {
                return ' ';
            }
        }
    }
}
