using Microsoft.EntityFrameworkCore;
using Quiz_V2.Data;

namespace Quiz_V2.Screens.QuestionScreens
{
    public class ListQuestionScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de questões");
            Console.WriteLine("--------------");
            List();
            Console.WriteLine();
            System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            MenuQuestionScreen.Load();
        }

        internal static void List()
        {
            using var context = new QuizDataContext();
            var questions = context
                .Questions
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var question in questions)
                Console.WriteLine($"{question.Id} - {question.Body}");
        }
    }
}