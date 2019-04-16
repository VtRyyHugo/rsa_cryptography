using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Cryptography
    {
        public byte[] Codes;

        public Cryptography()
        {

        }

        public void Encoder()
        {
            Console.WriteLine("Digite um texto para codificar: ");
            string str = Console.ReadLine();
            Codes = Encoding.ASCII.GetBytes(str);

            Console.WriteLine("\nTexto codificado: ");
            foreach (byte x in Codes)
            {
                Console.Write("{0}", x);
            }

        }

        public void Decoder(byte[] array)
        {
            string value = Encoding.ASCII.GetString(array);

            Console.WriteLine("\n\nTexto decodificado: ");
            Console.WriteLine(value);

        }
    }
}
