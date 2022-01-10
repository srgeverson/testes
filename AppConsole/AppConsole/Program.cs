using System;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando a aplicação!");
            new FormatacaoMoeda().FormatacaoComCultureInfo(7342587.5);
        }
    }
}
