using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
   public interface ICrypter
    {
        string Encrypt(string text);
        string Decrypt(string text);

    }
}
