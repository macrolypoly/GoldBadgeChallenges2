using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repository
{
    public class ClaimRepository
    {
        List<Claim> _listOfClaims = new List<Claim>();

        //CRUD

        public List<Claim> ReturnClaims()
        {
            return _listOfClaims;
        }

        public void AddClaim(Claim claim)
        {
            _listOfClaims.Add(claim);
        }
        public bool DeleteItems(int num)
        {
            Claim claim = GetClaimByID(num);
            if (claim == null)
            {
                return false;
            }
            int initialCount = _listOfClaims.Count();
            _listOfClaims.Remove(claim);
            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Claim GetClaimByID(int num)
        {
            foreach (Claim claim in _listOfClaims)
            {
                if (claim.ClaimID == num)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
