﻿using System;
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
            badge.BadgeName = ("A7");
            _repo.AddBadgeToDict(badge);

            badge.BadgeID = 22345;
            badge.BadgeName = "A1, A4, B1, B2";
            _repo.AddBadgeToDict(badge);

            badge.BadgeID = 32345;
            badge.BadgeName = "A4, A5";
            _repo.AddBadgeToDict(badge);
        }
        public void Menu()
        {
            bool running = true;
            while (running)
            {
                System.Console.WriteLine("Hello Security Admin, what would you like to do? \n");
                System.Console.WriteLine("1. Add a badge\n 2. Edit a badge\n 3. List all badges");
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
                newBadge.BadgeName = System.Console.ReadLine();

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
            _repo.AddBadge(newBadge);
            _repo.AddBadgeToDict(newBadge);
            Menu();
        }
        public void EditBadge()
        {

        }
        public void ListAllBadges()
        {
            System.Console.Clear();
            Dictionary<int, string> dictBadge = _repo.ReturnBadge();
            System.Console.WriteLine("Badge #	Door Access");

            foreach (KeyValuePair<int, string> kvp in dictBadge)
            {
                System.Console.WriteLine("{0}	{1}", kvp.Key, kvp.Value);
            }
            System.Console.ReadKey();
        }
    }

}
