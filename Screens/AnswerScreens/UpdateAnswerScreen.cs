using Quiz_V2.Data;

namespace Quiz_V2.Screens.AnswerScreens
{
    internal class UpdateAnswerScreen
    {
        internal static void Load()
        {
            Console.WriteLine("-----ATUALIZAR RESPOSTA-----");
            Console.WriteLine("(1) - Atualizar resposta");
            Console.WriteLine("(0) - Voltar");
            if (int.TryParse(Console.ReadLine(), out var option))
            {
                if (option == 0)
                    MenuAnswerScreen.Load();
                Console.Clear();
                Console.WriteLine("Atualizar resposta");
                Console.WriteLine("-------------");
                ListAnswerScreen.List();
                Update();
            }
            else
            {
                Console.WriteLine("Opção inválida. Insira um número válido.");
                Load();
            }
            Thread.Sleep(2000);
            Console.Clear();
            MenuAnswerScreen.Load();
        }

        private static void Update()
        {
            using var context = new QuizDataContext();
            Console.Write("Selecione o ID: ");
            try
            {
                if (int.TryParse(Console.ReadLine(), out var answerOrder))
                {
                    Console.WriteLine("Escreva a nova resposta:");
                    var newBody = Console.ReadLine();

                    var answer = context.Answers.FirstOrDefault(y => y.Id == answerOrder);

                    if (answer.IsCorrect)
                    {
                        System.Console.WriteLine("Aviso!: Você está alterando a resposta correta!");
                        System.Console.WriteLine("Deseja continuar?");
                        System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
                        var option = Console.ReadLine();
                        if (option.ToUpper() == "N")
                            Load();
                        answer.Body = newBody;
                        context.Answers.Update(answer);
                        context.SaveChanges();
                        Console.WriteLine("Resposta atualizada com sucesso!");
                    }
                    else
                        Console.WriteLine("Questão não encontrada. Certifique-se de que o ID esteja correto.");
                }
                else
                {
                    Console.WriteLine("ID inválido. Insira um número válido.");
                    Update();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Infelizmente não foi possível atualizar a resposta. Erro " + e.Message);
            }
        }
    }
}