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
            Claim claim1 = new Claim(1, Claim.ClaimType.Car, "Car accident on 465.", 400, example, example2, true);
            _repo.AddClaim(claim1);
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

            foreach (Claim content in listClaim)
            {
                System.Console.WriteLine($"Claim ID: {content.ClaimID}\n" +
                    $"Claim Type: { content.property}\n" +
                    $"Claim Description: {content.Description}\n" +
                    $"Claim Amount: ${content.ClaimAmount}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is valid: {content.IsValid}\n");
            }
            System.Console.ReadKey();
        }
        public void TakeCare()
        {

        }
        public void NewClaim()
        {

        }
    }
}
