using System;

namespace RsaCryptography
{
    class PrimeNumbers
    {
        private int Divisors { get; set; } //Armazena a quantidade de divisores de um número
        private Random r; //Objeto da classe Random

        public PrimeNumbers()
        {
            Divisors = 0;
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

        //Retorna os divisores
        public int GetDivisors()
        {
            return Divisors;
        }
    }
}
