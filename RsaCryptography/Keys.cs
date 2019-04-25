using System;
using System.Collections.Generic;

namespace RsaCryptography
{
    class Keys
    {
        private int P { get; set; } // Chave privada P              //REGRAS PARA E:
        private int Q { get; set; } // Chave privada Q              /*--Deve ser qualquer valor entre 1 e função Tot. de N.    
        private int N { get; set; } // Chave pública N                  Os divisores de E não podem pertencer        
        private  int E; // Chave pública E                 aos divisores de função Tot. de N --> Não podem ter divisores comuns--*/
        private int D { get;  set; } // Chave pública D
        private PrimeNumbers Pn; //Objeto da classe PrimeNumbers
        private int gcd; // Verifica se o MDC é 1 para validar a geração de E

        public Keys()
        {
            P = 0;
            Q = 0;
            N = 0;
            D = 0;
            Pn = new PrimeNumbers();
            gcd = 0;
        }

        //Gera as chaves --> P e Q são privadas N e E são públicas
        public void GenerateKeys()
        {
            P = Pn.RandomNum(1, 10000);
            Q = Pn.RandomNum(1, 10000);
            N = P * Q;
            GenerateKeyE();
            GenerateKeyD();
        }
        
        //Gera a chave pública E
        private void GenerateKeyE()
        {
            int phi = TotientFunction();
            int e =RandomE(phi);
            EuclAlgorithm(e, phi);

            while (gcd != 1)
            {
                e = RandomE(phi);
                EuclAlgorithm(e, phi);
            }

            E = e;
        }

        //Função totiente de N
        public int TotientFunction()
        {
            int tf = (P - 1) * (Q - 1);
            return tf;
        }

        //Gera uma tentativa para E aleatória
        private int RandomE(int ntotient)
        {
            Random r = new Random();
            return r.Next(1, ntotient);
        }

        //Gera a chave privada D
        private void GenerateKeyD()
        {
            int phi = TotientFunction();
            D = EuclAlgorithm(E, phi);  
        }

        //Algoritmo de Euclides Estendido
        public int EuclAlgorithm(int a, int b)
        {
            int r = b % a, q = b / a;
            int oldM = 1, oldN = 0, m = 0, n = 1;
            int helpM, helpN;
            int modB = b;
            while (r != 0)
            {
                helpM = m;
                helpN = n;

                m = oldM - (q * m);
                n = oldN - (q * n);

                oldM = helpM;
                oldN = helpN;

                b = a;
                a = r;

                gcd = r;
                r = b % a;
                q = b / a;
            }

            if (n < 0)
            {
                n = n + modB;
            }

            return n;
        }

        // Retorna P
        public int GetP()
        {
            return P;
        }

        // Retorna Q
        public int GetQ()
        {
            return Q;
        }

        // Retorna N
        public int GetN()
        {
                return N;
        }

        // Retorna E
        public int GetE()
        {
            return E;
        }

        // Retorna D
        public int GetD()
        {
            return D;
        }
    }
}
