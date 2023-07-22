using Quiz_V2.Data;

namespace Quiz_V2.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Load()
        {
            System.Console.WriteLine("-----ATUALIZAR CATEGORIA-----");
            System.Console.WriteLine("(1) - Atualizar categoria");
            System.Console.WriteLine("(0) - Voltar");
            if (int.TryParse(Console.ReadLine(), out var option))
            {
                if (option == 0)
                    MenuCategoryScreen.Load();
                Console.Clear();
                Console.WriteLine("Atualizar categoria");
                Console.WriteLine("-------------");
                System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");
                ListCategoryScreen.List();
                Update();
            }
            else
            {
                Console.WriteLine("Opção inválida. Insira um número válido.");
                Load();
            }
        }

        private static void Update()
        {
            using var context = new QuizDataContext();
            Console.Write("Escreva o ID: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                Console.Write("Digite a nova matéria: ");
                var categoryName = Console.ReadLine();

                var category = context.Categories.FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    category.Name = categoryName;
                    context.Categories.Update(category);
                    context.SaveChanges();
                    Console.WriteLine("Categoria atualizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Categoria não encontrada. Certifique-se de que o ID esteja correto.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Insira um número válido.");
                Update();
            }
        }
    }
}