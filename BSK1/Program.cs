using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    class Program
    {
        static void Main(string[] args)
        {

            string testNapis = "HERE IS A SECRET MESSAGE ENCIPHERED BY TRANSPOSITION";


            ICrypter c1 = new Vigenere("BREAKBREAKBR");


            string C = "";
            string M = "";
               C = c1.Encrypt(testNapis);
            M = c1.Decrypt(C);


            Console.WriteLine(testNapis);
            Console.WriteLine();
            Console.WriteLine(C);
            Console.WriteLine();
            Console.WriteLine(M);

            //   Enumerable.Range('A', 52)  .Select(x => (char)x).ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }
    }
}
