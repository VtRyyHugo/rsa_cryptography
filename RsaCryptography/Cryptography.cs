using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Cryptography
    {
        private byte[] Codes { get; set; }


        public Cryptography()
        {

        }

        public void Encoder()
        {
            Console.WriteLine("\nDigite um texto para codificar: ");
            string str = Console.ReadLine();
            SetCodes(Encoding.ASCII.GetBytes(str));

            Console.WriteLine("\nTexto codificado: ");
            foreach (byte x in GetCodes())
            {
                Console.Write("{0}", x);
            }
            Console.WriteLine();

        }

        public void Decoder(byte[] array)
        {
            string value = Encoding.ASCII.GetString(array);

            Console.WriteLine("\n\nTexto decodificado: ");
            Console.WriteLine(value);

        }

        public byte[] GetCodes()
        {
            return Codes;
        }

        public void SetCodes(byte[] value)
        {
            Codes = value;
        }
    }
}
