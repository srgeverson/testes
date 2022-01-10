using System.Globalization;
using static System.Console;

namespace AppConsole
{
    class FormatacaoMoeda
    {
        public FormatacaoMoeda()
        {

        }

        public void FormatacaoComCultureInfo(double valor)
        {
            //Cultura atual
            WriteLine("\n--------- Exibindo Moeda na cultura atual ---------------\n");
            // Por padrão, o especificador de formato "C" exibe a mode até duas casas decimais
            WriteLine(valor.ToString("C", CultureInfo.CurrentCulture));
            // C2 exibe a moeda até dois digitos
            WriteLine(valor.ToString("C2", CultureInfo.CurrentCulture));
            // C3 exibe a moeda até 3 digitos
            WriteLine(valor.ToString("C3", CultureInfo.CurrentCulture));
            // C4 exibe a moeda até 4 digitos
            WriteLine(valor.ToString("C4", CultureInfo.CurrentCulture));
            // C5 exibe a moeda até 5 digitos
            WriteLine(valor.ToString("C5", CultureInfo.CurrentCulture));
            //Para o Japão
            WriteLine("\n--------- Exibe a moeda para o Japão ---------------\n");
            WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("ja-JP")));
            //Para a Suécia
            WriteLine("\n--------- Exibe a moeda para a Suécia---------------\n");
            WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("se-SE")));
            //Para a Argentina
            WriteLine("\n--------- Exibe a moeda para a Argentina  --------------\n");
            WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
            Read();
        }
    }
}
