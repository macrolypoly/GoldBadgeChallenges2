using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repository
{
   public class Claim
    {
        public int ClaimID { get; set; }
        public enum ClaimType{ Car = 1, Home, Theft }
        public ClaimType property;
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public void Enums()
        {
            ClaimType Car = ClaimType.Car;
            ClaimType Home = ClaimType.Home;
            ClaimType Theft = ClaimType.Theft;
        }

        public Claim() {}

        public Claim(int claimID, ClaimType claimType, string description, int claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            property = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }
}
