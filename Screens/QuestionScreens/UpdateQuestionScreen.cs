using Quiz_V2.Data;

namespace Quiz_V2.Screens.QuestionScreens
{
    public class UpdateQuestionScreen
    {
        public static void Load()
        {
            Console.WriteLine("-----ATUALIZAR QUESTÃO-----");
            Console.WriteLine("(1) - Atualizar questão");
            Console.WriteLine("(0) - Voltar");
            if (int.TryParse(Console.ReadLine(), out var option))
            {
                if (option == 0)
                    MenuQuestionScreen.Load();
                Console.Clear();
                Console.WriteLine("Atualizar questão");
                Console.WriteLine("-------------");
                ListQuestionScreen.List();
                Update();
            }
            else
            {
                Console.WriteLine("Opção inválida. Insira um número válido.");
                Load();
            }
            MenuQuestionScreen.Load();
        }

        private static void Update()
        {
            using var context = new QuizDataContext();
            Console.Write("Escreva o ID: ");
            try
            {
                if (int.TryParse(Console.ReadLine(), out var questionId))
                {
                    Console.Write("Escreva a nova questão: ");
                    var newBody = Console.ReadLine();

                    var question = context.Questions.FirstOrDefault(y => y.Id == questionId);
                    if (question != null)
                    {
                        question.Body = newBody;
                        context.Questions.Update(question);
                        context.SaveChanges();
                        Console.WriteLine("Questão atualizada com sucesso!");
                    }
                    else
                    {
                        System.Console.WriteLine("Questão não encontrada. Certifique-se de que o ID esteja correto.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido. Insira um número válido.");
                    Update();
                }
                // System.Console.WriteLine("Você deseja atualizar as respostas dessa pergunta?");
                // atualizar as respostas
            }
            catch (Exception e)
            {
                Console.WriteLine("Infelizmente não foi possível atualizar a questão. Erro " + e.Message);
            }
        }
    }
}