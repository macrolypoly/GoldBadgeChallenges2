using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repository
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _listOfBadges = new Dictionary<int,List<string>>();

        //CRUD

        public Dictionary<int,List<string>> ReturnBadge()
        {
            return _listOfBadges;
        }

        public void AddBadge(Badge badge)
        {
            _listOfBadges.Add(badge.BadgeID, badge.DoorNames);
        }
        public bool AddBadgeToDict(Badge content)
        {
            int startingCount = _listOfBadges.Count();
            _listOfBadges.Add(content.BadgeID, content.DoorNames);
            bool wasAdded = (_listOfBadges.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool DeleteBadge(string num)
        {
            KeyValuePair<int, List<string>> kvp = GetBadgeByID(num);
            Dictionary<int, List<string>> badge = _listOfBadges;
            if (badge == null)
            {
                return false;
            }

            int initialCount = _listOfBadges.Count();
            _listOfBadges.Remove(Int32.Parse(num));
            if (initialCount > _listOfBadges.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public KeyValuePair<int,List<string>> GetBadgeByID(string num)
        {
            Dictionary<int, List<string>> dictBadge = _listOfBadges;
            foreach(KeyValuePair<int, List<string>> kvp in dictBadge)
            {
                if (kvp.Key.ToString() == num)
                {
                    return kvp;
                }
            }
            return default;
        }
        public bool UpdateBadge(string oldBadge, Dictionary<int,string> kvp)
        {
            return false;
        }
    }
}
