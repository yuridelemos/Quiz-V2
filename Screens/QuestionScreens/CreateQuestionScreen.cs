using Quiz_V2.Data;
using Quiz_V2.Models;
using Quiz_V2.Screens.CategoryScreens;

namespace Quiz_V2.Screens.QuestionScreens
{
    public class CreateQuestionScreen
    {
        public static void Load()
        {
            System.Console.WriteLine("-----CRIAR QUESTÃO-----");
            System.Console.WriteLine("(1) - Criar questão");
            System.Console.WriteLine("(0) - Voltar");
            var option = int.Parse(Console.ReadLine());
            if (option == 0)
                MenuQuestionScreen.Load();
            Console.Clear();
            Console.WriteLine("Nova questão");
            Console.WriteLine("-------------");
            System.Console.WriteLine("Ao criar uma nova questão, será obrigado logo em seguida a colocação das 5 alternativas de respostas.");
            ListCategoryScreen.List();
            Console.Write("Categoria da questão: ");
            var categoryId = short.Parse(Console.ReadLine());
            Console.WriteLine("Digite a questão");
            var question = Console.ReadLine();
            List<string> answers = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Digite a resposta {i + 1}: ");
                var answer = Console.ReadLine();
                answers.Add(answer);
            }
            Console.WriteLine("Qual é a resposta verdadeira?\n(1),(2),(3),(4),(5)");
            var idCorrectAnswer = short.Parse(Console.ReadLine());

            Create(categoryId, question, answers, idCorrectAnswer);
            Console.ReadKey();
            MenuQuestionScreen.Load();
        }

        private static void Create(int categoryId, string body, List<string> answers, int idCorrectAnswer)
        {
            try
            {
                using var context = new QuizDataContext();
                var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
                var question = new Question
                {
                    Body = body,
                    Category = category,
                    Answers = new List<Answer>()
                };
                for (int i = 0; i < answers.Count; i++)
                {
                    if (i == (idCorrectAnswer - 1))
                    {
                        var answer = new Answer
                        {
                            AnswerOrder = i,
                            Body = answers[i],
                            IsCorrect = true
                        };
                        question.Answers.Add(answer);
                    }
                    else
                    {
                        var answer = new Answer
                        {
                            AnswerOrder = i,
                            Body = answers[i],
                            IsCorrect = false
                        };
                        question.Answers.Add(answer);
                    }
                }
                context.Questions.Add(question);
                context.SaveChanges();
                Console.WriteLine("Questão cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a questão");
                Console.WriteLine(ex.Message);
            }
        }
    }
}