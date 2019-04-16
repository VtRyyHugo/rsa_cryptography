using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCryptography
{
    class MenuInterface
    {
        public Cryptography c;

        public MenuInterface() {
            c = new Cryptography();
        }

        public void SelectOptions()
            {
                Console.WriteLine("\nSelecione uma opção (1 / 2) :");
                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                    c.Encoder();
                        break;
                    case 2:

                        break;
                    default:
                        Console.WriteLine("\nDigite uma opção válida!");
                        SelectOptions();
                        break;
            }

        }
    }
}
