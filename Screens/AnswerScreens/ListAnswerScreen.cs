using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz_V2.Data;

namespace Quiz_V2.Screens.AnswerScreens
{
    internal class ListAnswerScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de respostas");
            Console.WriteLine("--------------");
            List();
            Console.WriteLine();
            System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            MenuAnswerScreen.Load();
        }

        internal static void List()
        {
            using var context = new QuizDataContext();
            var answers = context
                .Answers
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var answer in answers)
                Console.WriteLine($"{answer.Id} - {answer.Body}");
        }
    }
}