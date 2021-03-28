using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repository
{
    public class BadgeRepository
    {
        Dictionary<int, string> _listOfBadges = new Dictionary<int,string>();

        //CRUD

        public Dictionary<int,string> ReturnBadge()
        {
            return _listOfBadges;
        }

        public void AddBadge(Badge badge)
        {
            _listOfBadges.Add(badge.BadgeID,badge.BadgeName);
        }
        public bool AddBadgeToDict(Badge content)
        {
            int startingCount = _listOfBadges.Count();
            _listOfBadges.Add(content.BadgeID,content.BadgeName);
            bool wasAdded = (_listOfBadges.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool DeleteBadge(string num)
        {
            Dictionary<int, string> kvp = GetBadgeByID(num);
            if (kvp == null)
            {
                return false;
            }

            int initialCount = _listOfBadges.Count();
            _listOfBadges.Remove(kvp);
            if (initialCount > _listOfBadges.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Dictionary<int,string> GetBadgeByID(string num)
        {
            Dictionary<int, string> potato = _listOfBadges;
            foreach(var item in potato.Keys)
            {
                if (item.Equals(num))
                {
                    int ID = item;
                    return potato;
                }
            }
            return null;
        }
        public bool UpdateBadge(string oldBadge, Dictionary<int,string> kvp)
        {
            return false;
        }
    }
}
