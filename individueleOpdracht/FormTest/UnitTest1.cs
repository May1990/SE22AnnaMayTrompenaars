using System;
using System.Collections.Generic;
using individueleOpdracht;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormTest
{
    [TestClass]
    public class UnitTest1
    {
        //administratieclass
        [TestMethod]
        public void Testinloggen()
        {
            AdministratieClass admin = new AdministratieClass();
            string accountype = admin.Inloggen("hartendiefje@gmail.com", "UniqueBarber");

            Geslacht geslacht = Geslacht.Man;

            AdresClass adres = new AdresClass("Smirnofstraat", "5", "Den Bosch");

            AbbonementClass abbonement = AbbonementClass.Gratis;

            DateTime geboortedatum = Convert.ToDateTime("5-2-1989 12:00:00");

            GeregistreerdeClass barrie = new GeregistreerdeClass(1, "BarrieVanDerSloot", geboortedatum, geslacht, adres, "Koekenbakker", "Media Design", "hartendiefje@gmail.com", "liefje8976", abbonement, Modstatus.Actief, "UniqueBarber");

            try
            {
                Assert.AreEqual("bezoeker", accountype);

                Assert.AreEqual(barrie.AccountId, admin.Account.AccountId);
                Assert.AreEqual(barrie.Naam, admin.Account.Naam);
                Assert.AreEqual(barrie.GeboorteDatum, admin.Account.GeboorteDatum);
                Assert.AreEqual(barrie.Geslacht, admin.Account.Geslacht);
                Assert.AreEqual(barrie.Adres.Straat, admin.Account.Adres.Straat);
                Assert.AreEqual(barrie.Adres.Huisnummer, admin.Account.Adres.Huisnummer);
                Assert.AreEqual(barrie.Adres.Plaats, admin.Account.Adres.Plaats);
                Assert.AreEqual(barrie.Beroep, admin.Account.Beroep);
                Assert.AreEqual(barrie.Opleiding, admin.Account.Opleiding);
                Assert.AreEqual(barrie.Email, admin.Account.Email);
                Assert.AreEqual(barrie.Skype, admin.Account.Skype);
                Assert.AreEqual(barrie.Abbonement, admin.Account.Abbonement);
                Assert.AreEqual(barrie.Modstatus, admin.Account.Modstatus);
                Assert.AreEqual(barrie.Wachtwoord, admin.Account.Wachtwoord);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assert has failed.");
            }
        }


        [TestMethod]
        public void TestOphalenProducten()
        {
            AdministratieClass admin = new AdministratieClass();
            admin.OphalenProducten("Samsung Galaxy S4 16 GB Zwart", "Mobiele telefoons");

            ProductClass Samsung = new ProductClass(23, "Samsung Galaxy S4 16 GB Zwart", "Samsung", "Galaxy S", "16 GB Zwart", 299.6, Categorie.MobieleTelefoons);

            try
            {
                Assert.AreEqual(Samsung.ProductId, admin.Producten[0].ProductId);
                Assert.AreEqual(Samsung.Aparaat, admin.Producten[0].Aparaat);
                Assert.AreEqual(Samsung.Merk, admin.Producten[0].Merk);
                Assert.AreEqual(Samsung.Serie, admin.Producten[0].Serie);
                Assert.AreEqual(Samsung.Versie, admin.Producten[0].Versie);
                Assert.AreEqual(Samsung.Prijs, admin.Producten[0].Prijs);
                Assert.AreEqual(Samsung.Categorie, admin.Producten[0].Categorie);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assert has failed.");
            }
        }

        [TestMethod]
        public void TestOphalenreviewsAccount()
        {
            AdministratieClass admin = new AdministratieClass();
            Geslacht geslacht = Geslacht.Man;

            AdresClass adres = new AdresClass("Smirnofstraat", "5", "Den Bosch");

            AbbonementClass abbonement = AbbonementClass.Gratis;

            DateTime geboortedatum = Convert.ToDateTime("5-2-1989 12:00:00");

            GeregistreerdeClass barrie = new GeregistreerdeClass(1, "BarrieVanDerSloot", geboortedatum, geslacht, adres, "Koekenbakker", "Media Design", "hartendiefje@gmail.com", "liefje8976", abbonement, Modstatus.Actief, "UniqueBarber");
            admin.Account = barrie;
            admin.OphalenreviewsAccount();

            DateTime geplaatstOp = Convert.ToDateTime("5-3-2012 00:00:00");

            ReviewClass BarriesRieview = new ReviewClass("Wat een fantastische telefoon. O, wat ben ik er blij mee. Blablablabla", 5, "Samsung Galaxy S4 Rulez", geplaatstOp, null, barrie);

            try
            {
                Assert.AreEqual(BarriesRieview.Inhoud, admin.Reviews[0].Inhoud);
                Assert.AreEqual(BarriesRieview.ReviewId, admin.Reviews[0].ReviewId);
                Assert.AreEqual(BarriesRieview.Titel, admin.Reviews[0].Titel);
                Assert.AreEqual(BarriesRieview.GeplaatstOp, admin.Reviews[0].GeplaatstOp);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assert has failed.");
            }
        }

        //databasemanager
        [TestMethod]
        public void TestDataInloggen()
        {
            Databasemanager data = new Databasemanager();
            List<string> BarrieStrings = data.Inloggen("hartendiefje@gmail.com", "UniqueBarber");

            List<string> verwacht = new List<string>();

            verwacht.Add("1"); // accountid
            verwacht.Add("BarrieVanDerSloot"); // accountname
            verwacht.Add("5-2-1989 12:00:00"); // dateofbirth
            verwacht.Add("n"); // sex
            verwacht.Add("Smirnofstraat"); // street
            verwacht.Add("5"); // housenumber
            verwacht.Add("Den Bosch"); // place
            verwacht.Add("Koekenbakker"); // profession
            verwacht.Add("Media Design"); // education
            verwacht.Add("hartendiefje@gmail.com"); // email
            verwacht.Add("liefje8976"); // skype
            verwacht.Add("Free"); // subscription
            verwacht.Add("Actief"); // modstatus
            verwacht.Add("UniqueBarber"); // accountpassword

            try
            {
                Assert.AreEqual(verwacht[0], BarrieStrings[0]);
                Assert.AreEqual(verwacht[1], BarrieStrings[1]);
                Assert.AreEqual(verwacht[2], BarrieStrings[2]);
                Assert.AreEqual(verwacht[3], BarrieStrings[3]);
                Assert.AreEqual(verwacht[4], BarrieStrings[4]);
                Assert.AreEqual(verwacht[5], BarrieStrings[5]);
                Assert.AreEqual(verwacht[6], BarrieStrings[6]);
                Assert.AreEqual(verwacht[7], BarrieStrings[7]);
                Assert.AreEqual(verwacht[8], BarrieStrings[8]);
                Assert.AreEqual(verwacht[9], BarrieStrings[9]);
                Assert.AreEqual(verwacht[10], BarrieStrings[10]);
                Assert.AreEqual(verwacht[11], BarrieStrings[11]);
                Assert.AreEqual(verwacht[12], BarrieStrings[12]);
                Assert.AreEqual(verwacht[13], BarrieStrings[13]);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assert has failed.");
            }
        }

        //reviewclass
        public void TestOphalenCommentaren()
        {
            Geslacht geslacht = Geslacht.Man;

            AdresClass adres = new AdresClass("Smirnofstraat", "5", "Den Bosch");

            AbbonementClass abbonement = AbbonementClass.Gratis;

            DateTime geboortedatum = Convert.ToDateTime("5-2-1989 12:00:00");

            GeregistreerdeClass barrie = new GeregistreerdeClass(1, "BarrieVanDerSloot", geboortedatum, geslacht, adres, "Koekenbakker", "Media Design", "hartendiefje@gmail.com", "liefje8976", abbonement, Modstatus.Actief, "UniqueBarber");

            DateTime geplaatstOp = Convert.ToDateTime("5-3-2012 00:00:00");
            ReviewClass BarriesRieview = new ReviewClass("Wat een fantastische telefoon. O, wat ben ik er blij mee. Blablablabla", 5, "Samsung Galaxy S4 Rulez", geplaatstOp, null, barrie);

            BarriesRieview.OphalenCommentaren();

        }
    }
}



