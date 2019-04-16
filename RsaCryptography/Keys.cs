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

        public Keys()
        {
            P = 0;
            Q = 0;
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
