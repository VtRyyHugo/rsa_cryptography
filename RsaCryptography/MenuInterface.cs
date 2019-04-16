using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class MenuInterface
    {
        public Cryptography c;

        public MenuInterface()
        {
            c = new Cryptography();
        }

        //Interface do console
        public void SelectOptions()
        {
            Console.WriteLine("\nSelecione uma opção :");
            Console.WriteLine("\t(1) GERAR PRIMO");
            Console.WriteLine("\t(2) CODIFICAR");
            Console.WriteLine("\t(3) DECODIFICAR");
            Console.WriteLine("\t(4) LIMPAR TELA");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    c.SetP(c.RandomNum(1, 5000));
                    Console.WriteLine(c.GetP());
                    SelectOptions();
                    break;

                case 2:
                    c.Encoder();
                    SelectOptions();
                    break;

                case 3:
                    c.Decoder(c.GetCodes());
                    SelectOptions();
                    break;

                case 4:
                    Console.Clear();
                    SelectOptions();
                    break;

                default:
                    Console.WriteLine("\nDigite uma opção válida!");
                    SelectOptions();
                    break;
            }

        }
    }
}
