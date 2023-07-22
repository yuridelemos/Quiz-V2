using Quiz_V2.Data;
using Quiz_V2.Models;
using Quiz_V2.Screens;

namespace Quiz_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu.Start();
            // using var context = new QuizDataContext();

            // var category = context.Categories.FirstOrDefault();
            // var question = new Question
            // {
            //     Body = "Quem descobriu o Brasil?",
            //     Category = category,
            //     Answers = new List<Answer>()
            //     {
            //         new Answer { AnswerOrder = 0, Body = "Pedro Alvares Cabral", IsCorrect = true },
            //         new Answer { AnswerOrder = 1, Body = "Cristóvão Colombo", IsCorrect = false },
            //         new Answer { AnswerOrder = 2, Body = "Fernão de Magalhães", IsCorrect = false },
            //         new Answer { AnswerOrder = 3, Body = "Américo Vespúcio", IsCorrect = false },
            //         new Answer { AnswerOrder = 4, Body = "Bartolomeu Dias", IsCorrect = false },
            //     }
            // };
            // context.Questions.Add(question);
            // context.SaveChanges();
        }
    }
}

// Quando for criar as perguntas, olhar o método do vídeo 11 do mapeamento, minuto 02:40
// Testar LastOrDefault