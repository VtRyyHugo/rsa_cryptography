using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Cryptography
    {
        public void setAscEncoding(string str) {
            str = Console.ReadLine();

            byte[] codes = Encoding.ASCII.GetBytes(str);
        }
    }
}
