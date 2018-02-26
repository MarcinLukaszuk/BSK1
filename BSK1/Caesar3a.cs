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
            eulerNumber = 12;
            var alphabetArray = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            n = alphabetArray.Count();
            for (int i = 0; i < n; i++) alphabetDictionary.Add(alphabetArray[i], i);
        }


        public string Encrypt(string text)
        {
            text = text.ToUpper();
            builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                builder.Append(EncryptOneLetter(text[i]));
            return builder.ToString();
        }


        public string Decrypt(string text)
        {
            text = text.ToUpper();
            builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                builder.Append(DecryptOneLetter(text[i]));
            return builder.ToString();
        }

        private char EncryptOneLetter(char a)
        {
            if (a == ' ') return ' ';
            return (char)((alphabetDictionary[a] * k1 + k0) % n + 65);
        }

        private char DecryptOneLetter(char c)
        {
            if (c == ' ') return ' ';
            return (char)(((alphabetDictionary[c] + (n - k0)) * (Math.Pow(k1, (eulerNumber - 1)))) % n + 65);
        }

    }
}
