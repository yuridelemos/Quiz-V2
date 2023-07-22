using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz_V2.Data;

namespace Quiz_V2.Screens.CategoryScreens
{
    public class ListCategoryScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de categorias");
            Console.WriteLine("--------------");
            List();
            Console.WriteLine();
            System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
        internal static void List()
        {
            using var context = new QuizDataContext();
            var categories = context
                .Categories
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var category in categories)
                Console.WriteLine($"{category.Id} - {category.Name}");
        }
    }
}