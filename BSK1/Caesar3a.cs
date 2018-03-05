using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Caesar3a : ICrypter
    {
        Dictionary<char, int> alphabetDictionary = new Dictionary<char, int>();
        StringBuilder builder;
        int n;
        int k0;
        int k1;
        int eulerNumber;

        public Caesar3a(int key0, int key1)
        {
            this.k0 = key0;
            this.k1 = key1;
            eulerNumber = 30;
            var alphabet1 = Enumerable.Range('A', 26).Select(x => (char)x);
            var alphabet2 = Enumerable.Range('a', 26).Select(x => (char)x);
            var numbers = Enumerable.Range('0', 10).Select(x => (char)x);
            var alphabetArray = (alphabet1.Concat(alphabet2)).Concat(numbers).ToArray();
            n = alphabetArray.Count();
            for (int i = 0; i < n; i++) alphabetDictionary.Add(alphabetArray[i], i);
        }


        public string Encrypt(string text)
        {
            builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                builder.Append(EncryptOneLetter(text[i]));
            return builder.ToString();
        }


        public string Decrypt(string text)
        {
            builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                builder.Append(DecryptOneLetter(text[i]));
            return builder.ToString();
        }

        private char EncryptOneLetter(char a)
        {
            if (a == ' ') return ' ';
            int value = (alphabetDictionary[a] * k1 + k0) % n;
            return alphabetDictionary.FirstOrDefault(x => x.Value == value).Key;
        }

        private char DecryptOneLetter(char c)
        {
            if (c == ' ') return ' ';
            double value = ((alphabetDictionary[c] + (n - k0)) * (Math.Pow(k1, (eulerNumber - 1)))) % n;
            return alphabetDictionary.FirstOrDefault(x => x.Value == value).Key;
        }

    }
}
