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

        public void SelectOptions()
        {
            Console.WriteLine("\nSelecione uma opção :");
            Console.WriteLine("\t(1) CODIFICAR");
            Console.WriteLine("\t(2) DECODIFICAR");
            Console.WriteLine("\t(3) LIMPAR TELA");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    c.Encoder();
                    SelectOptions();
                    break;

                case 2:
                    c.Decoder(c.GetCodes());
                    SelectOptions();
                    break;

                case 3:
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
