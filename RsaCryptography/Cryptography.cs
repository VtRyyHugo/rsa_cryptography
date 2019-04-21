using System;
using System.Text;
using System.Numerics;

namespace RsaCryptography
{
    class Cryptography
    {
        private byte[] Codes { get; set; } //Array que armazena a mensagem em ASCII
        private int[] Converted { get; set; } //Array que armazena os bytes convertidos para inteiros
        private BigInteger[] Encrypted { get; set; } //Array que armazena a mensagem criptografada em inteiros grandes
        private int[] Decrypted { get; set; } //Array que armazena a mensagem decriptografada em inteiros
        private byte[] FinalMsg { get; set; } //Array que armazena a mensagem  decriptografada em bytes

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
            FinalMsg = new byte[Codes.Length];

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
            ModDecrypt(Encrypted, Decrypted, key);
            string txt = Encoding.UTF8.GetString(FinalMsg);
            Console.WriteLine("Texto decodificado: ");
            Console.WriteLine(txt);

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

            for (int i = 0; i < converted.Length; i++)
            {
                encrypted[i] = BigInteger.ModPow(converted[i], e, n);
            }
            Console.WriteLine();
            Console.WriteLine("\nArray Criptografado: ");

            foreach (BigInteger x in encrypted)
            {
                Console.Write(x);
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
                try{

                    FinalMsg[i] = Convert.ToByte(decrypted[i]);
                }catch {
                    Console.Clear();
                    Console.WriteLine("Ocorreu um erro, tente gerar outra chave!!");
                }
                
            }
        }

        //Retorna o array de bytes com códigos ASCII
        public byte[] GetCodes()
        {
            return Codes;
        }

        //Seta os valores do array
        public void SetCodes(byte[] value)
        {
            Codes = value;
        }
    }
}
