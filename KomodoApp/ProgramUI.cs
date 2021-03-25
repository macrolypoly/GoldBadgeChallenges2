using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Komodo;

namespace KomodoApp
{
    public class ProgramUI
    {
        Menu menu = new Menu();
        MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            SeedMenu();
            Menu();
        }
        private void SeedMenu()
        {
            List<string> ingredients = new List<string>();
            PopulateList(ingredients);
            Menu burger = new Menu(1, "Burger", "hamburger", ingredients, 2);

            _repo.AddItems(burger);
        }
        public void PopulateList(List<string> ingredients)
        {
            ingredients.Add("beef");
            ingredients.Add("onion");
            ingredients.Add("cheese");
            ingredients.Add("lettuce");
            ingredients.Add("tomato");
            ingredients.Add("bread");
            ingredients.Add("ketchup");
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("choose an option.");
                Console.WriteLine("1: return list");
                Console.WriteLine("2: add menu item");
                Console.WriteLine("3: delete menu item");
                Console.WriteLine("4: exit");
                string caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        DisplayList();
                        break;
                    case "2":
                        AddItems();
                        break;
                    case "3":
                        DeleteItems();
                        break;
                    case "4":
                        keepRunning = false;
                        break;

                }
            }
        }
        private void DisplayList()
        {
            Console.Clear();

            List<Menu> listMenu = _repo.ReturnList();

            foreach (Menu content in listMenu)
            {
                Console.WriteLine($"Meal number: {content.MealNumber}\n"+
                    $"Meal name: { content.MealName}\n" +
                    $"Meal description: {content.MealDescription}\n" +
                    $"Meal ingredients: {content.Ingredients}\n" +
                    $"Meal price: {content.MealPrice}\n");
            }
            Console.ReadKey();
        }
        private void AddItems()
        {
            Console.Clear();
            Menu newItem = new Menu();

            //meal num
            Console.WriteLine("Please enter the meal number.");
            newItem.MealNumber = Int32.Parse(Console.ReadLine());

            //meal 
            Console.WriteLine("Please enter the meal name.");
            newItem.MealName = Console.ReadLine();

            //meal desc
            Console.WriteLine("Please enter the meal description.");
            newItem.MealDescription = Console.ReadLine();

            //meal ingredients
            List<string> Ingredients = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("enter an ingredient.");
                Ingredients.Add(Console.ReadLine());
            }
            //meal price
            Console.WriteLine("please enter a price.");
            newItem.MealPrice = Int32.Parse(Console.ReadLine());

            _repo.AddItems(newItem);
        }
        private void DeleteItems()
        {
            DisplayList();

            Console.WriteLine("enter number of content you'd like to remove.");
            int input = Int32.Parse(Console.ReadLine());

            bool wasDeleted = _repo.DeleteItems(input);
            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("the content could not be deleted.");
            }
        }
    }
}
