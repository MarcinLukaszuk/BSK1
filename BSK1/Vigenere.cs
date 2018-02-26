using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Vigenere : ICrypter
    {
        StringBuilder builder;
        Dictionary<char, int> alphabetDictionary;
        List<int> keyList;
        int sizeKey;
        int dictionarySize;

        public Vigenere(string key)
        {
            alphabetDictionary = new Dictionary<char, int>();
            keyList = new List<int>();


            var alphabetArray = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            for (int i = 0; i < alphabetArray.Count(); i++)
                alphabetDictionary.Add(alphabetArray[i], i);

            foreach (var item in key) keyList.Add(alphabetDictionary[item]);

            dictionarySize = alphabetDictionary.Count;
            sizeKey = keyList.Count();



        }
        public string Encrypt(string text)
        {
            text = text.ToUpper();

            builder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]==' ')
                {
                    builder.Append(' ');
                    continue;
                }               
                builder.Append((char)(((alphabetDictionary[text[i]] + keyList[i % sizeKey]) % dictionarySize) + 65));
            }


            return builder.ToString();
        }
        public string Decrypt(string text)
        {
            builder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    builder.Append(' ');
                    continue;
                }
                builder.Append((char)(((alphabetDictionary[text[i]] - keyList[i % sizeKey] + dictionarySize) % dictionarySize) + 65));
            }
            return builder.ToString();
        }


    }
}
