using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Cryptography
    {
        private byte[] Codes { get; set; } //Array que armazena a mensagem em ASCII
        private int Divisors { get; set; } //Armazena a quantidade de divisores de um número
        private Random r;
        private int P {get; set;}
        private int Q {get; set;}
        private int N {get; set;}


        public Cryptography()
        {
            Divisors = 0;
            P = 0;
            Q = 0;
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

        //Verificar se um numero é primo retornando verdadeiro se tiver apenas dois divisores
        public bool IsPrime(int n)
        {
            Divisors = 0;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    Divisors++;
                }
            }

            return Divisors == 2; //Retorna true se o número tiver apenas dois divisores
        }

        //Gerar um numero aleatório para testar se é primo rodando até ser verdadeiro

        public int RandomNum(int min, int max)
        {
            r = new Random();
            int num = r.Next(min, max);

            while (!IsPrime(num))
            {
                num = r.Next(min, max);
            }

            return num;
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

        //Retorna os divisores
        public int GetDivisors()
        {
            return Divisors;
        }
        
        // Retorna P
        public int GetP()
        {
            return P;
        }

        //Seta P
        public void SetP(int num)
        {
            P = num;
        }

        // Retorna Q
        public int GetQ()
        {
            return Q;
        }

        //Seta Q
        public void SetQ(int num)
        {
            Q = num;
        }
    }
}
