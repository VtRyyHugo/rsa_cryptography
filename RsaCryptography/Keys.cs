using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Keys
    {
        private int P { get; set; } // Número primo P
        private int Q { get; set; } // Número primo Q
        private int N { get; set; } // Chave pública N
        private int E { get; set; } // Chave pública E      //REGRAS: 
                                                           /*--Deve ser qualquer valor entre 1 e função Tot. de N
                                                            Os divisores de E não podem pertencer 
                                                            aos divisores de função Tot. de N --> Não podem ter divisores comuns--*/
        private PrimeNumbers Pn;

        public Keys()
        {
            P = 0;
            Q = 0;
            Pn = new PrimeNumbers();
        }

        //Gera as Keys
        public void GeneratePublicKeys()
        {
            P = Pn.RandomNum(1, 1000);
            Q = Pn.RandomNum(1, 1000);
            N = P * Q;
        }

        //Função totiente de N
        private int TotientFunction()
        {
            int tf = (P - 1) * (Q - 1);
            return tf;
        }

        
        public void CalculateMDC(int n1, int n2)
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
                        Console.WriteLine("Tem divisores em comum: {0} ", x);
                        break;
                    }
                }
            }
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
