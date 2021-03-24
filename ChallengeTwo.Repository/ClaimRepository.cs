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
    }
}
