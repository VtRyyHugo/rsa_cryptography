using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Keys
    {
        private int P { get; set; } // Chave privada P              //REGRAS PARA E:
        private int Q { get; set; } // Chave privada Q              /*--Deve ser qualquer valor entre 1 e função Tot. de N.    
        private int N { get; set; } // Chave pública N              Os divisores de E não podem pertencer        
        private int E { get; set; } // Chave pública E              aos divisores de função Tot. de N --> Não podem ter divisores comuns--*/
        private bool Etest { get; set;}                                                                                                                                    
        private PrimeNumbers Pn;

        public Keys()
        {
            P = 0;
            Q = 0;
            Pn = new PrimeNumbers();
            Etest = false;
        }

        //Gera as chaves --> P e Q são privadas N e E são públicas
        public void GenerateKeys()
        {
            P = Pn.RandomNum(1, 1000);
            Q = Pn.RandomNum(1, 1000);
            N = P * Q;
            GenerateKeyE();
        }
        
        //Gera a chave pública E
        private void GenerateKeyE()
        {
            int funcT = TotientFunction();
            int e = RandomE(funcT);

            while (!Etest)
            {
                 CalculateMDC(e, funcT);

                if (!Etest) {
                    e = RandomE(funcT);
                }                  
            }

            E = e;
        }

        //Função totiente de N
        private int TotientFunction()
        {
            int tf = (P - 1) * (Q - 1);
            return tf;
        }

        //Testa se existem divisores em comum
        private void CalculateMDC(int n1, int n2)
        {
            int divisor = 2;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();

            while (n1 > 1)
            {
                if (n1 % divisor == 0)
                {
                    n1 = n1 / divisor;
                    list.Add(divisor);
                    if ((n1 % divisor != 0) && (n1 > 1))
                    {
                        divisor++;
                    }
                }
                else
                {
                    divisor++;
                }
            }

            divisor = 2;

            while (n2 > 1)
            {
                if (n2 % divisor == 0)
                {
                    n2 = n2 / divisor;
                    list2.Add(divisor);

                    if ((n2 % divisor != 0) && (n2 > 1))
                    {
                        divisor++;
                    }
                }
                else
                {
                    divisor++;
                }
            }

            foreach (int x in list)
            {
                foreach (int y in list2)
                {
                    if (x == y)
                    {
                        Etest = false;
                        return;
                    }
                }
            }
            Etest = true;
        }

        //Gera uma tentativa para E aleatória
        private int RandomE(int ntotient)
        {
            Random r = new Random();
            return r.Next(1, ntotient);
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
    }
}
