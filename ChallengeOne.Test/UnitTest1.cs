using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Repository_Komodo;
using System.Collections.Generic;

namespace KomodoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_AddMenu()
        {
            Menu menu = new Menu();
            MenuRepository repo = new MenuRepository();
            List<Menu> localList = repo.ReturnList();

            int beforeCount = localList.Count;
            repo.AddItems(menu);
            int actual = localList.Count;
            int expected = beforeCount + 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
