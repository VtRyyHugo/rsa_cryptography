using System;

namespace RsaCryptography
{
    class MenuInterface
    {
        private Cryptography Crypto; //Objeto da classe Cryptography
        private Keys Key; //Objeto da classe Keys
        private PrimeNumbers Pn; //Objeto da classe PrimeNumbers

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
            Console.WriteLine("\t(5) MOSTRAR KEYS");
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (n)
                {
                    case 1:
                        Key.GenerateKeys();
                        Console.WriteLine("P: " + Key.GetP());
                        Console.WriteLine("Q: " + Key.GetQ());
                        Console.WriteLine("N: " + Key.GetN());
                        Console.WriteLine("E: " + Key.GetE());
                        Console.WriteLine("D: " + Key.GetD());
                        Console.WriteLine("Função Totiente de N: " + Key.TotientFunction());
                        SelectOptions();
                        break;

                    case 2:
                        try
                        {
                            Crypto.Encoder(Key);
                            SelectOptions();
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Gere as keys para codificar uma mensagem.");
                            SelectOptions();
                        }
                        break;

                    case 3:
                        try
                        {
                            Crypto.Decoder(Crypto.GetCodes(), Key);
                            SelectOptions();
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("1º gere as keys e codifique uma mensagem.");
                            SelectOptions();
                        }
                        break;

                    case 4:
                        Console.Clear();
                        SelectOptions();
                        break;

                    case 5:
                        Console.WriteLine("P: " + Key.GetP());
                        Console.WriteLine("Q: " + Key.GetQ());
                        Console.WriteLine("N: " + Key.GetN());
                        Console.WriteLine("E: " + Key.GetE());
                        Console.WriteLine("D: " + Key.GetD());
                        Console.WriteLine("Função Totiente de N: " + Key.TotientFunction());
                        SelectOptions();
                        break;

                    default:
                        Console.WriteLine("\nDigite uma opção válida!");
                        SelectOptions();
                        break;
                }

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Digite um número dentre as opções!");
                SelectOptions();
            }
            
            
            

            

        }
    }
}
