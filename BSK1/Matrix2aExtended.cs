using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Matrix2aExtended : ICrypter
    {
        protected StringBuilder builder;

        protected List<int> keyList;


        public Matrix2aExtended() { }



        public string Encrypt(string text)
        {
            keyList = new List<int>();
            keyList.Add(3);
            keyList.Add(4);
            keyList.Add(1);
            keyList.Add(5);
            keyList.Add(2);






            int height = (int)Math.Ceiling(((float)text.Length / 5));
            int lastRow = text.Length % 5;
            if (lastRow == 0)
                ++height;
            int width = 5;

            char[,] tab = new char[width, height];

            int counter = 0;
            for (int i = 0; i < height; i++)
                for (int k = 0; k < width; k++)
                    if (counter < text.Length)
                        tab[k, i] = text[counter++];



            builder = new StringBuilder();

            for (int i = 0; i < height; i++)
            {
                foreach (var item in keyList)
                {
                    if (i == height - 1 && item > lastRow)
                        continue;
                    builder.Append(tab[item - 1, i]);
                }
            }
            return builder.ToString();
        }
        public string Decrypt(string text)
        {
            keyList = new List<int>();
            keyList.Add(3);
            keyList.Add(5);
            keyList.Add(1);
            keyList.Add(2);
            keyList.Add(4);

            int height = (int)Math.Ceiling(((float)text.Length / 5));
            int lastRow = text.Length % 5;
            if (lastRow == 0)
                ++height;
            int width = 5;

            char[,] tab = new char[width, height];
            int counter = 0;
            for (int i = 0; i < height; i++)
                for (int k = 0; k < width; k++)
                    if (counter < text.Length)
                        tab[k, i] = text[counter++];


            builder = new StringBuilder();

            for (int i = 0; i < height - 1; i++)
            {
                foreach (var item in keyList)
                {
                    builder.Append(tab[item - 1, i]);

                }
            }

            if (lastRow == 0)
            {
                return builder.ToString();
            }
            else if (lastRow == 1)
            {
                builder.Append(text[text.Length - 1]);
                return builder.ToString();
            }
            else if (lastRow == 2)
            {
                builder.Append(text[text.Length - 2]);
                builder.Append(text[text.Length - 1]);
                return builder.ToString();
            }
            else if (lastRow == 3)
            {
                builder.Append(text[text.Length - 2]);
                builder.Append(text[text.Length - 1]);
                builder.Append(text[text.Length - 3]);
                return builder.ToString();
            }
            else
            {
                builder.Append(text[text.Length - 2]);
                builder.Append(text[text.Length - 1]);
                builder.Append(text[text.Length - 4]);
                builder.Append(text[text.Length - 3]);
                return builder.ToString();
            }
        }
        protected List<int> InvertKey(List<int> list)
        {
            int[] decodeKeyList = new int[list.Count];
            int indexer = 1;
            list.ForEach(x => decodeKeyList[x - 1] = indexer++);
            return decodeKeyList.ToList();
        }
        public void ShowKey()
        {
            keyList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
    }
}
