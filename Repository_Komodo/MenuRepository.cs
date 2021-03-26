using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo
{
    public class MenuRepository
    {
        List<Menu> _listOfMenuItems = new List<Menu>();

        //CRUD

        public List<Menu> ReturnList()
        {
            return _listOfMenuItems;
        }

        public void AddItems(Menu menu)
        {
            _listOfMenuItems.Add(menu);
        }
        public bool AddItemToMenu(Menu content)
        {
            int startingCount = _listOfMenuItems.Count();
            _listOfMenuItems.Add(content);
            bool wasAdded = (_listOfMenuItems.Count > startingCount) ? true : false;
            return wasAdded;
            //_listOfMenuItems.Add(content);
        }
        public bool DeleteItems(int num)
        {
            Menu menu = GetMenuByNum(num);
            if (menu == null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count();
            _listOfMenuItems.Remove(menu);
            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Menu GetMenuByNum(int num)
        {
            foreach (Menu menu in _listOfMenuItems)
            {
                if (menu.MealNumber == num)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}
