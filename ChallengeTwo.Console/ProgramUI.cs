using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwo.Repository;

namespace ChallengeTwo.Console
{
    public class ProgramUI
    {
        Claim claims = new Claim();
        ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            SeedClaim();
            Menu();
        }
        public void SeedClaim()
        {
            DateTime example = new DateTime(2018,4,25);
            DateTime example2 = new DateTime(2018, 4, 27);
            DateTime c2 = new DateTime(2018, 4, 11);
            DateTime c22 = new DateTime(2018, 4, 12);
            DateTime c3 = new DateTime(2018, 4, 27);
            DateTime c32 = new DateTime(2018, 6, 01);
            Claim claim1 = new Claim(1, Claim.ClaimType.Car, "Car accident on 465.", 400, example, example2, true);
            Claim claim2 = new Claim(2, Claim.ClaimType.Home, "House fire in kitchen.", 4000, c2, c22, true);
            Claim claim3 = new Claim(3, Claim.ClaimType.Theft, "Stolen pancakes.", 4, c3, c32, true);
            _repo.AddClaim(claim1);
            _repo.AddClaim(claim2);
            _repo.AddClaim(claim3);
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                System.Console.WriteLine("choose an option.");
                System.Console.WriteLine("1: see all claims");
                System.Console.WriteLine("2: take care of next claim");
                System.Console.WriteLine("3: enter new claim");
                System.Console.WriteLine("4: exit");
                string caseSwitch = System.Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        DisplayClaims();
                        break;
                    case "2":
                        TakeCare();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;

                }
            }
        }
        public void DisplayClaims()
        {
            System.Console.Clear();

            List<Claim> listClaim = _repo.ReturnClaims();
            string s = string.Format("ClaimID	Type	Description	        Amount	DateOfAccident	DateOfClaim");
            System.Console.WriteLine(s);
            foreach (Claim content in listClaim)
                
            {
                string l = string.Format("{0}	{1}	{2}	${3}	{4}	{5} \n", content.ClaimID, content.property, content.Description, content.ClaimAmount, content.DateOfIncident, content.DateOfClaim);
                System.Console.WriteLine(l);
                /*System.Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                    $"Claim Type: { content.property}\n" +
                    $"Claim Description: {content.Description}\n" +
                    $"Claim Amount: ${content.ClaimAmount}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is valid: {content.IsValid}\n"); */
            }
            System.Console.ReadKey();
        }
        public void TakeCare()
        {
            System.Console.WriteLine("Here are the details for the next claim to be handled:");

            List<Claim> listClaim = _repo.ReturnClaims();
            var content = listClaim.ElementAt(0);
            string p = string.Format("ClaimID: {0} \nType: {1} \nDescription: {2} \nAmount: ${3} \nDateOfAccident: {4} \nDateOfClaim: {5} \nIsValid: {6}", content.ClaimID, content.property, content.Description, content.ClaimAmount, content.DateOfIncident, content.DateOfClaim, content.IsValid); ;
            System.Console.WriteLine(p);
            System.Console.WriteLine("do you want to deal with this claim now(y/n)?");
            string input = System.Console.ReadLine();
            switch (input)
            {
                case "y":
                    int num;
                    System.Console.WriteLine("confirm Claim ID:");
                    num = Int32.Parse(System.Console.ReadLine());
                    DeleteItems(num);
                    break;
                case "n":
                    break;
            }
        }

        private void DeleteItems(int num)
        {
         
            bool wasDeleted = _repo.DeleteItems(1);
            if (wasDeleted)
            {
                System.Console.WriteLine("The claim was successfully");
            }
            else
            {
                System.Console.WriteLine("the content could not be deleted.");
            }
        }
        public void NewClaim()
        {
            System.Console.Clear();
            Claim newClaim = new Claim();
            System.Console.WriteLine("Enter the claim id: ");
            newClaim.ClaimID = Int32.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Enter the claim type: ");
            string input;
            input = System.Console.ReadLine();
           if (input.ToLower() == "car")
            {
                newClaim.property = Claim.ClaimType.Car;
            }
           else if (input.ToLower() == "home")
            {
                newClaim.property = Claim.ClaimType.Home;
            }
           else if (input.ToLower() == "theft")
            {
                newClaim.property = Claim.ClaimType.Theft;
            }

            System.Console.WriteLine("Enter a claim description: ");
            newClaim.Description = System.Console.ReadLine();

            System.Console.WriteLine("Amount of Damage: ");
            newClaim.ClaimAmount = Int32.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Date of Accident:");
            System.Console.WriteLine("Enter year:");
            int e = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter month:");
            int e2 = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter day:");
            int e3 = Int32.Parse(System.Console.ReadLine());
            DateTime input2 = new DateTime(e,e2,e3);

            newClaim.DateOfIncident = input2;

            System.Console.WriteLine("Date of Claim:");
            System.Console.WriteLine("Enter year:");
            int c = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter month:");
            int c2 = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter day:");
            int c3 = Int32.Parse(System.Console.ReadLine());
            DateTime p2 = new DateTime(e, e2, e3);

            newClaim.DateOfIncident = p2;

            System.Console.WriteLine("Is this claim valid? (Y/N)");
            string userInput = System.Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "y":
                    newClaim.IsValid = true;
                    break;
                case "n":
                    newClaim.IsValid = false;
                    break;
            }
            _repo.AddClaim(newClaim);
        }

    }
  
    }
