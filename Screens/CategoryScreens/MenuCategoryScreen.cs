using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_V2.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de categorias");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("(1) - Listar categorias");
            Console.WriteLine("(2) - Cadastrar categoria");
            Console.WriteLine("(3) - Atualizar categoria");
            Console.WriteLine("(4) - Excluir categoria");
            Console.WriteLine("(0) - Voltar");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListCategoryScreen.Load();
                    break;
                case 2:
                    CreateCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
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