using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class Keys
    {
        private int P { get; set; }
        private int Q { get; set; }
        private int N { get; set; }
        private PrimeNumbers Pn;

        public Keys()
        {
            P = 0;
            Q = 0;
            Pn = new PrimeNumbers();

        }

        //Gera as Keys
        public void GenerateKeys()
        {
            P = Pn.RandomNum(1, 1000);
            Q = Pn.RandomNum(1, 1000);
            N = P * Q;
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

        //Seta Q
        public void SetN(int num)
        {
            N = num;
        }
    }
}
