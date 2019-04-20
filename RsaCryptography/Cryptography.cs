using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace RsaCryptography
{
    class Cryptography
    {
        private byte[] Codes { get; set; } //Array que armazena a mensagem em ASCII
        private int[] Converted { get; set; }
        private BigInteger[] Encrypted { get; set; }
        private int[] Decrypted { get; set; }

        public Cryptography()
        {
            
        }

        //Transforma o texto digitado em códido ASCII
        public void Encoder(Keys key)
        {
            Console.WriteLine("\nDigite um texto para codificar: ");
            string str = Console.ReadLine();
            SetCodes(Encoding.UTF8.GetBytes(str));
            Converted = new int[GetCodes().Length];
            Encrypted = new BigInteger[Converted.Length];
            Decrypted = new int[Encrypted.Length];

            Console.WriteLine("\nTexto codificado: ");
            foreach (byte x in GetCodes())
            {
                Console.Write("{0}", x);
            }

            ConvertArray(Codes, Converted);
            ModEncrypt(Converted, Encrypted, key);
        }

        //Transforma o array de bytes na mensagem decodificada
        public void Decoder(byte[] array, Keys key)
        {
            /*string value = Encoding.ASCII.GetString(array);
            Console.WriteLine("\n\nTexto decodificado: ");
            Console.WriteLine(value);*/
            ModDecrypt(Encrypted, Decrypted, key);
        }

        //Converte o array de bytes para inteiros
        public void ConvertArray(byte[] array, int [] converted)
        {
            for (int i = 0; i < array.Length; i++)
            {
                converted[i] = Convert.ToInt32(array[i]);
            }
        }

        //Encripta o array de inteiros
        public void ModEncrypt(int[] converted,BigInteger[] encrypted, Keys key)
        {
            int n = key.GetN();
            int e = key.GetE();

            Console.WriteLine(n);
            

            for (int i = 0; i < converted.Length; i++)
            {
                encrypted[i] = BigInteger.ModPow(converted[i], e, n);
            }
            Console.WriteLine("\nArray Criptografado: ");

            foreach (BigInteger x in encrypted)
            {
                Console.WriteLine(x);
            }
        }

        //Decripta o array de inteiros
        public void ModDecrypt(BigInteger[] encrypted, int[] decrypted, Keys key)
        {
            int n = key.GetN();
            int d = key.GetD();

            for (int i = 0; i < encrypted.Length; i++)
            {
                decrypted[i] = (int)BigInteger.ModPow(encrypted[i], d, n);   
            }

            Console.WriteLine("\nArray Decriptografado: ");
            foreach (int x in decrypted)
            {
                Console.WriteLine(x);
            }
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
