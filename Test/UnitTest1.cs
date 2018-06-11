using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadTest()
        {
            var Tester = new WczytywanieZBazy();
            List<string> AllegedResult = new List<string>() { "2", "Stefan", "Nowak", "Kardiolog" };
            var TestedRecord = Tester.LoadData("Lekarz", new List<string> { "ID", "Imie", "Nazwisko", "Specjalizacja" });
            List<string> TestedDoctor = new List<string>();
            foreach (var item in TestedRecord)
            {
                if (item[0] == AllegedResult[0])
                {
                    TestedDoctor = item;
                    break;
                }
            }
            CollectionAssert.AreEqual(AllegedResult, TestedDoctor);
        }
        [TestMethod]
        public void LoadWithConditionTest()
        {
            var tester = new WczytywanieZBazy();
            List<string> AllegedResult = new List<string>() { "Szczepienie", "Przeciwko Gruźlicy", "50" };
            var TestedRecotd = tester.LoadData("Oferta", new List<string> { "Nazwa", "Opis", "Cena" }, "ID=4");
            CollectionAssert.AreEqual(AllegedResult, TestedRecotd[0]);
        }
    }
}
