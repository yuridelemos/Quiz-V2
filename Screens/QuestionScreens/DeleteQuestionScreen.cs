using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz_V2.Data;

namespace Quiz_V2.Screens.QuestionScreens
{
    internal class DeleteQuestionScreen
    {
        internal static void Load()
        {
            System.Console.WriteLine("-----DELETAR QUESTÃO-----");
            System.Console.WriteLine("(1) - Deletar questão");
            System.Console.WriteLine("(0) - Voltar");
            System.Console.WriteLine("OBS: Ao deletar uma questão, irá deletar todas as respostas presentes nela.");
            if (int.TryParse(Console.ReadLine(), out var option))
            {
                if (option == 0)
                    MenuQuestionScreen.Load();
                Console.Clear();
                Console.WriteLine("Deletar questão");
                Console.WriteLine("-------------");
                ListQuestionScreen.List();
                Delete();
            }
            else
            {
                Console.WriteLine("Opção inválida. Insira um número válido.");
                Load();
            }
            MenuQuestionScreen.Load();
        }
        internal static void Delete()
        {
            using var context = new QuizDataContext();
            Console.Write("Escreva o ID: ");
            try
            {
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var question = context.Questions.FirstOrDefault(y => y.Id == id);

                    if (question != null)
                    {
                        context.Questions.Remove(question);
                        context.SaveChanges();
                        Console.WriteLine("Questão deletada com sucesso!");
                    }
                    else
                        Console.WriteLine("Questão não encontrada. Certifique-se de que o ID esteja correto.");
                }
                else
                    Console.WriteLine("ID inválido. Insira um número válido");
                Load();
            }
            catch (Exception e)
            {
                Console.WriteLine("Infelizmente não foi possível deletar a questão. Error: " + e.Message);
            }
        }
    }
}