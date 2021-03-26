using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }

        public List<string> Ingredients { get; set; }

        public int MealPrice { get; set; }

        public Menu()
        {
        }
        public Menu(int mealNum, string mealName, string mealDesc, List<string> ingredients, int mealPrice)
        {
            MealNumber = mealNum;
            MealName = mealName;
            MealDescription = mealDesc;
            Ingredients = ingredients;
            MealPrice = mealPrice;

        }

    }
}
