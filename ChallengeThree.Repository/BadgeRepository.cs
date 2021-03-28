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
        public void DeleteBadge(int num)
        {
            Dictionary<int, string> kvp = _listOfBadges;
            kvp.Remove(GetBadgeByID(num));
        }
        public Dictionary<int,string> GetBadgeByID(int num)
        {
            Dictionary<int, string> potato = _listOfBadges;
            foreach (Dictionary<int,string> kvp in _listOfBadges)
            {
                if (kvp.ContainsKey(num))
                {
                    return kvp;
                }
            }
            return null;
        }
    }
}
