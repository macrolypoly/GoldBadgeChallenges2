using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeThree.Repository;

namespace ChallengeThree.Console
{
    class ProgramUI
    {
        Badge badge = new Badge();
        BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            SeedBadges();
            Menu();
        }
        public void SeedBadges()
        {
            badge.BadgeID = (12345);
            List<string> student = new List<string>();
            student.Add("A7");
            badge.DoorNames = student;
            badge.BadgeName = "student";
            _repo.AddBadgeToDict(badge);

            badge.BadgeID = 22345;
            List<string> TA = new List<string>();
            TA.Add("A1");
            TA.Add("A4");
            TA.Add("B1");
            TA.Add("B2");
            badge.DoorNames = TA;
            badge.BadgeName = "TA";
            _repo.AddBadgeToDict(badge);

            badge.BadgeID = 32345;
            List<string> professor = new List<string>();
            professor.Add("A4");
            professor.Add("A5");
            badge.DoorNames = professor;
            badge.BadgeName = "professor";
            _repo.AddBadgeToDict(badge);
        }
        public void Menu()
        {
            bool running = true;
            while (running)
            {
                System.Console.WriteLine("Hello Security Admin, what would you like to do? \n");
                System.Console.WriteLine("1. Add a badge\n 2. Edit a badge\n 3. List all badges\n 4. Delete Badge\n 5. Exit");
                
                int userInput = Int32.Parse(System.Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        EditBadge();
                        break;
                    case 3:
                        ListAllBadges();
                        break;
                    case 4:
                        DeleteBadge();
                        break;
                    case 5:
                        running = false;
                        break;
                }
            }
        }

        public void AddBadge()
        {
            System.Console.Clear();
            bool bluh = true;
            Badge newBadge = new Badge();

            System.Console.WriteLine("What is the number on the badge: ");
            newBadge.BadgeID = Int32.Parse(System.Console.ReadLine());

            while (bluh)
            {
                System.Console.WriteLine("List a door that it needs access to: ");
                List<string> newDoor = new List<string>();
                newDoor.Add(System.Console.ReadLine());
                newBadge.DoorNames = newDoor;

                System.Console.WriteLine("Any other doors(y/n)?");
                string ui = System.Console.ReadLine();
                switch (ui)
                {
                    case "y":
                        bluh = true;
                        break;
                    case "n":
                        bluh = false;
                        break;
                }
            }
            System.Console.WriteLine("what is the name of this badge?");
            newBadge.BadgeName = System.Console.ReadLine();
            _repo.AddBadge(newBadge);
            _repo.AddBadgeToDict(newBadge);
            Menu();
        }
        public void EditBadge()
        {
            System.Console.WriteLine("What is the badge number to update?");
            string oldBadge = System.Console.ReadLine();

            KeyValuePair<int,List<string>> potato = _repo.GetBadgeByID(oldBadge);
            
            
            System.Console.Write(oldBadge.ToString() + " has access to doors ");
                foreach (var item in potato.Value)
                {
                    System.Console.Write(item);
                    System.Console.WriteLine(" ");
                }
                System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("  1. Remove a door\n  2. Add a door");
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("which door would you like to remove?");
                    userInput = System.Console.ReadLine();
                    potato.Value.Remove(userInput);
                    break;
                case "2":
                    System.Console.WriteLine("Which door would you like to add?");
                    userInput = System.Console.ReadLine();
                    potato.Value.Add(userInput);
                    break;
            }
                



        }
        public void ListAllBadges()
        {
            System.Console.Clear();
            Dictionary<int, List<string>> dictBadge = _repo.ReturnBadge();
            System.Console.WriteLine("Badge #	Door Access");

            foreach (KeyValuePair<int, List<string>> kvp in dictBadge)
            {
                System.Console.Write("{0}	", kvp.Key); 
                foreach (var item in kvp.Value)
                {
                    System.Console.Write(item);
                    System.Console.Write(" ");
                }
                System.Console.WriteLine("\n");
            }
            System.Console.ReadKey();
        }
        public void DeleteBadge()
        {
            Dictionary<int, List<string>> dictBadge = _repo.ReturnBadge();
            System.Console.WriteLine("please enter badge id you want to remove");
            string input = System.Console.ReadLine();
            bool wasDeleted = _repo.DeleteBadge(input);
            if (wasDeleted)
            {
                System.Console.WriteLine("The content was successfully deleted.");
            }
            else
            {
                System.Console.WriteLine("the content could not be deleted.");
            }

        }
    }

}
