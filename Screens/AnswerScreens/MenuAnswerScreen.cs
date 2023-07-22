namespace Quiz_V2.Screens.AnswerScreens
{
    public class MenuAnswerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de respostas");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("(1) - Atualizar resposta");
            Console.WriteLine("(2) - Por que apenas posso apenas atualizar resposta?");
            System.Console.WriteLine("(0) - Voltar");
            Console.Write("-----------------: ");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    // UpdateAnswerScreen.Load();
                    break;
                case 2:
                    // RuleAnswerScreen.Load();
                    break;
                case 0:
                    MainMenu.Start();
                    break;
                default:
                    System.Console.WriteLine("Opção digitada inválida, pressione qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
                    Load();
                    break;
            }
        }
    }
}