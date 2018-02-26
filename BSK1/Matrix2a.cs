using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Matrix2a : ICrypter
    {
        protected StringBuilder builder;
        protected char[] arrayText;
        protected char[] codeArray;
        protected int arraySize;
        protected int widthArray;
        protected int heightArray;
        protected int fullHeightCollumns;
        protected List<int> keyList;
        bool encrypt;

        public Matrix2a() { }

        public Matrix2a(string key)
        {
            keyList = key.Split('-').Select(x => int.Parse(x)).ToList();
            encrypt = true;
        }


        public string Encrypt(string text)
        {
            builder = new StringBuilder();
            arrayText = text.ToCharArray();
            arraySize = text.Length;
            codeArray = new char[arraySize];
            widthArray = keyList.Count;
            heightArray = (int)Math.Ceiling((double)arraySize / widthArray);
            fullHeightCollumns = arraySize % widthArray == 0 ? widthArray : arraySize % widthArray;



            //check if this is encrypted
            keyList = encrypt ? keyList : InvertKey(keyList);

            int counter = 0;
            for (int i = 0; i < heightArray - 1; i++)
                for (int k = 1; k <= widthArray; k++)
                    if (counter < arraySize - 2)
                        codeArray[i * widthArray + keyList.IndexOf(k)] = arrayText[counter++];

            //last row coding
            List<int> tmpKeyList;
            if (encrypt)
            {
                tmpKeyList = keyList
                    .Select(x => x)
                    .Where(x => x <= fullHeightCollumns)
                    .ToList();

                for (int i = 1; i <= tmpKeyList.Count; i++)
                    codeArray[widthArray * (heightArray - 1) + tmpKeyList.IndexOf(i)] = arrayText[counter++];
            }
            else
            {
                //set normal key 
                keyList = InvertKey(keyList);
                tmpKeyList = InvertKey(keyList
                    .Select(x => x)
                    .Where(x => x <= fullHeightCollumns)
                    .ToList());

                for (int i = 1; i <= tmpKeyList.Count; i++)
                    codeArray[widthArray * (heightArray - 1) + tmpKeyList.IndexOf(i)] = arrayText[counter++];
            }



            return new string(codeArray);
        }
        public string Decrypt(string text)
        {
            encrypt = false;
            string tmpText = Encrypt(text);
            encrypt = true;

            return tmpText;
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
