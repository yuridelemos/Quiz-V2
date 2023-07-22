using Quiz_V2.Data;
using Quiz_V2.Models;

namespace Quiz_V2.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        internal static void Load()
        {
            System.Console.WriteLine("-----CRIAÇÃO DE CATEGORIA-----");
            System.Console.WriteLine("(1) - Criar categoria");
            System.Console.WriteLine("(0) - Voltar");
            if (int.TryParse(Console.ReadLine(), out var option))
            {
                if (option == 0)
                    MenuCategoryScreen.Load();

                Console.Clear();
                Console.WriteLine("Nova categoria");
                Console.WriteLine("-------------");
                Console.Write("Nome: ");
                var categoryName = Console.ReadLine();
                CreateCategory(categoryName);
            }
            else
            {
                Console.WriteLine("Opção inválida. Insira um número válido.");
            }
        }

        private static void CreateCategory(string categoryName)
        {
            using var context = new QuizDataContext();
            try
            {
                var category = new Category
                {
                    Name = categoryName
                };
                context.Categories.Add(category);
                context.SaveChanges();
                Console.WriteLine("Categoria criada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Infelizmente não foi possível criar a categoria. Erro: " + e.Message);
            }
        }
    }
}