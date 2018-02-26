using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Matrix2b : Matrix2a, ICrypter
    {
        public Matrix2b(string key)
        {
            keyList = DecodeKey(key);
        }

        public new string Encrypt(string text)
        {
            builder = new StringBuilder();
            arrayText = text.ToCharArray();
            arraySize = text.Length;
            widthArray = keyList.Count;
            heightArray = (int)Math.Ceiling((double)arraySize / widthArray);
            fullHeightCollumns = 0 == arraySize % widthArray ? widthArray : arraySize % widthArray;


            for (int i = 1; i <= widthArray; i++)
            {
                var tmpIndex = keyList.IndexOf(i);

                if (tmpIndex < fullHeightCollumns)
                    for (int k = 0; k < heightArray; k++)
                        builder.Append(arrayText[tmpIndex + widthArray * k]);
                else
                    for (int k = 0; k < heightArray - 1; k++)
                        builder.Append(arrayText[tmpIndex + widthArray * k]);
            }

            return builder.ToString();
        }

        public new string Decrypt(string text)
        {
            builder = new StringBuilder();
            arrayText = text.ToCharArray();
            arraySize = text.Length;
            widthArray = keyList.Count;
            heightArray = (int)Math.Ceiling((double)arraySize / widthArray);
            fullHeightCollumns = 0 == arraySize % widthArray ? widthArray : arraySize % widthArray;
            codeArray = new char[arraySize];


            int counter = 0;

            for (int i = 1; i <= widthArray; i++)
            {
                var tmpIndex = keyList.IndexOf(i);

                if (tmpIndex < fullHeightCollumns)
                    for (int k = 0; k < heightArray; k++)
                        codeArray[tmpIndex + k * widthArray] = arrayText[counter++];
                else
                    for (int k = 0; k < heightArray - 1; k++)
                        codeArray[tmpIndex + k * widthArray] = arrayText[counter++];
            }
            return new string(codeArray); ;
        }

        private List<int> DecodeKey(string text)
        {
            LinkedList<char> list = new LinkedList<char>(text.ToList().OrderBy(x => x).Distinct());
            int[] keyArray = new int[text.Length];
            int indexer = 1;

            foreach (var item in list)
                for (int i = 0; i < keyArray.Length; i++)
                    if (item == text[i])
                        keyArray[i] = indexer++;

            return keyArray.ToList<int>();
        }



    }
}
