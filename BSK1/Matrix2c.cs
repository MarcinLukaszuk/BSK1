using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Matrix2c : Matrix2b, ICrypter
    {
        public Matrix2c(string key) : base(key) { }

        public new string Encrypt(string text)
        {
            builder = new StringBuilder();
            arrayText = text.ToCharArray();
            arraySize = text.Length;
            widthArray = keyList.Count;
            List<char>[] matrix = new List<char>[widthArray];


            for (int i = 0; i < widthArray; i++) matrix[i] = new List<char>();

            int counter = 0;
            for (int i = 0; i < arraySize; i++)
                for (int k = 0; k <= keyList.IndexOf(i % widthArray + 1); k++)
                {
                    if (counter >= arraySize) break;
                    matrix[k].Add(arrayText[counter++]);
                }

            for (int i = 1; i <= widthArray; i++)
                matrix[keyList.IndexOf(i)].ForEach(x => builder.Append(x));

            return builder.ToString();
        }

        public new string Decrypt(string text)
        {
            builder = new StringBuilder();
            arrayText = text.ToCharArray();
            arraySize = text.Length;
            widthArray = keyList.Count;
            List<char>[] matrix = new List<char>[widthArray];
            int[] tmpArray = new int[widthArray];


            for (int i = 0; i < matrix.Count(); i++) matrix[i] = new List<char>();

            int counter = 0;
            for (int i = 0; i < arraySize; i++)
                for (int k = 0; k <= keyList.IndexOf(i % widthArray + 1); k++)
                {
                    if (counter++ >= arraySize) break;
                    tmpArray[k]++;
                }

            counter = 0;
            for (int i = 0; i < tmpArray.Count(); i++)
                for (int k = 0; k < tmpArray[keyList.IndexOf(i % widthArray + 1)]; k++)
                    matrix[i].Add(text[counter++]);

            counter = 0;
            for (int i = 0; i < tmpArray.OrderBy(x => x).Last(); i++)
                for (int k = 0; k <= keyList.IndexOf(i % widthArray + 1); k++)
                {
                    if (counter++ >= arraySize) break;
                    builder.Append(matrix[keyList[k] - 1].First());
                    matrix[keyList[k] - 1].RemoveAt(0);
                }
            return builder.ToString();
        }

    }
}
