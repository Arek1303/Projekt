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
        public void TestWczytywania()
        {
            var tester = new WczytywanieZBazy();
            List<string> przypuszczanyWynik = new List<string>() { "2", "Stefan", "Nowak", "Kardiolog" };
            var testowanyRekord = tester.WczytajRekordy("Lekarz", new List<string> { "ID", "Imie", "Nazwisko", "Specjalizacja" });
            List<string> testowanyLekarz = new List<string>();
            foreach (var item in testowanyRekord)
            {
                if (item[0] == przypuszczanyWynik[0])
                {
                    testowanyLekarz = item;
                    break;
                }
            }
            CollectionAssert.AreEqual(przypuszczanyWynik, testowanyLekarz);
        }
        [TestMethod]
        public void TestWczytywaniaZWarunkiem()
        {
            var tester = new WczytywanieZBazy();
            List<string> przypuszczanyWynik = new List<string>() { "Szczepienie", "Przeciwko Gruźlicy", "50" };
            var testowanyRekord = tester.WczytajRekordy("Oferta", new List<string> { "Nazwa", "Opis", "Cena" }, "ID=4");
            CollectionAssert.AreEqual(przypuszczanyWynik, testowanyRekord[0]);
        }
    }
}
