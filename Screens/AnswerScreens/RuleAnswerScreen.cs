using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_V2.Screens.AnswerScreens
{
    internal class RuleAnswerScreen
    {
        internal static void Load()
        {
            System.Console.WriteLine("\"Por que não há outra opção além de atualizar respostas?\"");
            System.Console.WriteLine("\"Por que não posso deletar respostas?\"");
            System.Console.WriteLine();
            System.Console.WriteLine("A possibilidade de exclusão foi removida para o usuário por escolha do autor do programa.");
            System.Console.WriteLine("Isso ocorre porque todas as perguntas requerem obrigatoriamente 5 respostas.");
            System.Console.WriteLine("Caso deseje \"deletar\" alguma resposta, basta acessar a opção de alteração e escrever algo novo.");
            System.Console.WriteLine();
            System.Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            MenuAnswerScreen.Load();
        }
    }
}