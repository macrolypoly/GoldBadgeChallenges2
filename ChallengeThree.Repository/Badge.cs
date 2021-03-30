using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public string BadgeName { get; set; }

    public Badge(int badgeID, List<string> doorNames, string badgeName)
    {
            BadgeID = badgeID;
            DoorNames = doorNames;
            BadgeName = badgeName;
    }
        public Badge()
        {

        }
    }
}
