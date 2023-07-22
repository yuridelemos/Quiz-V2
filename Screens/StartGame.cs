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
            Random rand = new Random();
            // int rightQuestions = 0, questionNumber = 1;
            List<int> questionsAlreadyAsked = new List<int>();


            // System.Console.WriteLine($"Seu resultado foi de {rightQuestions} acertos!");
        }
    }
}