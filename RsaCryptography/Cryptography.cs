using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Cryptography
    {
        private byte[] Codes { get; set; } //Array que armazena a mensagem em ASCII

        public Cryptography()
        {
            
            
        }

        //Transforma o texto digitado em códido ASCII
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

        //Transforma o array de bytes na mensagem decodificada
        public void Decoder(byte[] array)
        {
            string value = Encoding.ASCII.GetString(array);
            Console.WriteLine("\n\nTexto decodificado: ");
            Console.WriteLine(value);
        }

        //Retorna o array de bytes com códigos ASCII
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
