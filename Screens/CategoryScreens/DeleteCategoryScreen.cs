using Quiz_V2.Data;

namespace Quiz_V2.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            System.Console.WriteLine("-----DELETAR CATEGORIA-----");
            System.Console.WriteLine("(1) - Deletar categoria");
            System.Console.WriteLine("(0) - Voltar");
            System.Console.WriteLine("OBS: Ao deletar uma categoria, todas as perguntas presentes nela serão deletadas.");
            if (int.TryParse(Console.ReadLine(), out var option))
            {
                if (option == 0)
                    MenuCategoryScreen.Load();
                Console.Clear();
                Console.WriteLine("Deletar categoria");
                Console.WriteLine("-------------");
                ListCategoryScreen.List();
                Delete();
            }
            else
            {
                Console.WriteLine("Opção inválida. Insira um número válido.");
                Load();
            }
        }

        private static void Delete()
        {
            using var context = new QuizDataContext();
            Console.Write("Escreva o ID: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var category = context.Categories.FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    Console.WriteLine("Categoria deletada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Categoria não encontrada. Certifique-se de que o ID esteja correto.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Insira um número válido.");
                Delete();
            }

        }
    }
}