using Microsoft.EntityFrameworkCore;
using Quiz_V2.Data;
namespace Quiz_V2.Screens
{
    public class StartGame
    {
        public static void Load()
        {
            Console.WriteLine("-------------Iniciando o jogo-------------");
            Console.WriteLine("Escolha a quantidade de questões para iniciar seu quiz");
            Console.WriteLine("Você pode escolher quantas perguntas deseja responder (máximo de 20), mas caso não escolha, a quantidade será de 10 perguntas.");
            Console.Write("----------------: ");
            var numberOfQuestions = short.Parse(Console.ReadLine());
            if (numberOfQuestions > 20)
                numberOfQuestions = 20;
            else if (numberOfQuestions < 0)
                numberOfQuestions = 10;
            Random random = new Random();
            int rightQuestions = 0, questionNumber = 1, answerNumber = 1, rightAnswer = 0;

            var context = new QuizDataContext();
            var questions = context
                .Questions
                .Include(y => y.Answers)
                .AsNoTracking()
                .OrderBy(y => y.Id)
                .ToList();

            foreach (var question in questions.OrderBy(y => random.Next()))
            {
                Console.WriteLine($" {questionNumber} - {question.Body}");
                foreach (var answer in question.Answers.OrderBy(y => random.Next()))
                {
                    Console.WriteLine($"({answerNumber}) - {answer.Body}");
                    if (answer.IsCorrect == true)
                        rightAnswer = answerNumber;
                    answerNumber++;
                }
                Console.WriteLine("Qual a resposta correta?");
                Console.Write("======================: ");
                var chosenAnswer = short.Parse(Console.ReadLine());
                if (chosenAnswer == rightAnswer)
                {
                    Console.WriteLine("Certa resposta!");
                    rightQuestions++;
                }
                else
                    Console.WriteLine("Resposta errada!");
                questionNumber++;
                answerNumber = 1;
                if (questionNumber > numberOfQuestions)
                    break;
            }
            System.Console.WriteLine($"Seu resultado foi de {rightQuestions} acertos!");
        }
    }
}