using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ChallengeThree.Repository;

namespace ChallengeThree.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_AddBadge()
        {
            Badge badge = new Badge();
            BadgeRepository repo = new BadgeRepository();
            Dictionary<int, List<string>> kvp = repo.ReturnBadge();

            int beforeCount = kvp.Count;
            repo.AddBadgeToDict(badge);
            int actual = kvp.Count;
            int expected = beforeCount + 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
