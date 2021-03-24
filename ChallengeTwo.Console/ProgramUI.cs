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
            Claim claim1 = new Claim(1, Claim.ClaimType.Car, "Car accident on 465.", 400, 4 / 25 / 18, 4 / 27 / 18, true);
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
                    $"Claim Type: { content.GetType()}\n" +
                    $"Claim Description: {content.Description}\n" +
                    $"Claim Amount: {content.ClaimAmount}\n" +
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
