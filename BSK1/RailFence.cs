using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{ 
    public class RailFence : ICrypter
    {
        int _railsNumber;

        public RailFence(int railsNumber)
        {
            _railsNumber = railsNumber;
        }
        
        public string Encrypt(string text)
        {
            StringBuilder str = new StringBuilder();
            int tmp;
            int left;
            int right;

            for (int i = 0; i < _railsNumber; i++)
            {
                for (int k = 0; (tmp = 2 * (_railsNumber - 1) * k) <= (Math.Ceiling((double)text.Length / (double)_railsNumber)) * _railsNumber; k++)
                {
                    //firstrow
                    if (i == 0)
                    {
                        if (tmp > text.Length - 1) continue;
                        str.Append(text[tmp]);
                        continue;
                    }

                    //lastrow
                    if (i == _railsNumber - 1)
                    {
                        if (tmp + i > text.Length - 1) continue;
                        str.Append(text[tmp + i]);
                        continue;
                    }

                    left = tmp - i;
                    right = tmp + i;

                    if (left >= 0 && left < text.Length)
                        str.Append(text[left]);

                    if (right < text.Length)
                        str.Append(text[right]);
                }
            }
            return str.ToString();
        }

        public string Decrypt(string text)
        {
            StringBuilder str = new StringBuilder();
            char[] tablica = new char[text.Length];
            int tmp;
            int left;
            int right;
            
            int counter = 0;
            for (int i = 0; i < _railsNumber; i++)
            {
                for (int k = 0; (tmp = 2 * (_railsNumber - 1) * k) <= (Math.Ceiling((double)text.Length / (double)_railsNumber)) * _railsNumber; k++)
                {
                    //firstrow
                    if (i == 0)
                    {
                        if (tmp > text.Length - 1) continue;
                        tablica[tmp] = text[counter++];
                        continue;
                    }

                    //lastrow
                    if (i == _railsNumber - 1)
                    {
                        if (tmp + i > text.Length - 1) continue;
                        tablica[tmp + i] = text[counter++];
                        continue;
                    }

                    left = tmp - i;
                    right = tmp + i;

                    if (left >= 0 && left < text.Length)
                        tablica[left] = text[counter++];

                    if (right < text.Length)
                        tablica[right] = text[counter++];
                }
            }
            tablica.ToList().ForEach(x => str.Append(x));
            return str.ToString();
        }
        

    }


}
