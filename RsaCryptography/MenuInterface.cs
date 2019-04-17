using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class MenuInterface
    {
        private Cryptography Crypto;
        private Keys Key;
        private PrimeNumbers Pn;

        public MenuInterface()
        {
            Crypto = new Cryptography();
            Key = new Keys();
            Pn = new PrimeNumbers();
        }

        //Interface do console
        public void SelectOptions()
        {
            Console.WriteLine("\nSelecione uma opção :");
            Console.WriteLine("\t(1) GERAR KEYS");
            Console.WriteLine("\t(2) CODIFICAR");
            Console.WriteLine("\t(3) DECODIFICAR");
            Console.WriteLine("\t(4) LIMPAR TELA");
            Console.WriteLine("\t(5) TESTAR DIVISORES");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    Key.GeneratePublicKeys();
                    Console.WriteLine("P: " + Key.GetP());
                    Console.WriteLine("Q: " + Key.GetQ());
                    Console.WriteLine("Public Key N: " + Key.GetN());
                    SelectOptions();
                    break;

                case 2:
                    Crypto.Encoder();
                    SelectOptions();
                    break;

                case 3:
                    Crypto.Decoder(Crypto.GetCodes());
                    SelectOptions();
                    break;

                case 4:
                    Console.Clear();
                    SelectOptions();
                    break;

                case 5:
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    Key.CalculateMDC(a,b);
                    break;

                default:
                    Console.WriteLine("\nDigite uma opção válida!");
                    SelectOptions();
                    break;
            }

        }
    }
}
