using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class AdministratieClass
    {
        private List<ProductClass> producten;
        private AccountClass account;
        private List<ReviewClass> reviews;
        private Databasemanager data;

        public AdministratieClass()
        {
            this.Producten = new List<ProductClass>();
            //dit mag niet, geregistreerde of werknemer
            this.Account = new WerknemerClass();
            this.Reviews = new List<ReviewClass>();
            this.data = new Databasemanager();
        }

        public AccountClass Account
        {
            get { return account; }
            set { account = value; }
        }
        

        public List<ProductClass> Producten
        {
            get { return producten; }
            set { producten = value; }
        }

        public List<ReviewClass> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        public string Inloggen(string email, string wachtwoord)
        {
            string accountType = "bezoeker";
            List<string> accListVanDb = new List<string>();
            try
            {
                accListVanDb = data.Inloggen(email, wachtwoord);
            }
            catch (Exception)
            {
                //inloggen mislukt
                throw;
            }
            

            Geslacht geslacht;
            if (accListVanDb[3] == "n")
            {
                geslacht = Geslacht.Man;
            }
            else
            {
                geslacht = Geslacht.Vrouw;
            }

            AdresClass adres = new AdresClass(accListVanDb[4], accListVanDb[5], accListVanDb[6]);

            AbbonementClass abbonement;
            if (accListVanDb[11] == "Bannervrij")
            {
                abbonement = AbbonementClass.Bannervrij;
            }
            else
            {
                abbonement = AbbonementClass.Gratis;
            }

            if (accListVanDb.Count == 13)
            {
                
                WerknemerClass werknemer = new WerknemerClass(Convert.ToUInt32(accListVanDb[0]), accListVanDb[1], Convert.ToDateTime(accListVanDb[2]), geslacht,
                    adres, accListVanDb[6], accListVanDb[7], accListVanDb[8], accListVanDb[9], abbonement, Modstatus.Actief, wachtwoord, Convert.ToDouble(accListVanDb[11]), accListVanDb[12], Convert.ToDateTime(accListVanDb[13]));
                
                Account = werknemer;
                accountType = "werknemer";
            }
            else
            {
                GeregistreerdeClass geregistreerde = new GeregistreerdeClass(Convert.ToUInt32(accListVanDb[0]),
                    accListVanDb[1], Convert.ToDateTime(accListVanDb[2]), geslacht,
                    adres, accListVanDb[7], accListVanDb[8], accListVanDb[9], accListVanDb[10], abbonement,
                    Modstatus.Actief, wachtwoord);

                Account = geregistreerde;
                
            }

            return accountType;
        }

        public void AccountToevoegen(string wachtwoord, string naam, DateTime geboortedatum, string geslacht, string straat, string huisnummer, string woonplaats, string beroep, string opleiding, string email, string skype)
        {
            Modstatus modstatus = Modstatus.Actief;
            AbbonementClass abbonement = AbbonementClass.Gratis;
            uint accountId = 0;
            try
            {
                int accountid = Convert.ToInt32(data.KrijgLaatsteAccountId()) + 1;
                data.ToevoegenAccount(wachtwoord ,naam, geboortedatum, geslacht, huisnummer, straat, woonplaats, beroep, opleiding, email, skype, Convert.ToString(abbonement), Convert.ToString(modstatus), accountid);
                //accountId = Convert.ToUInt32(data.OphalenAccountId(email));
            }
            catch (Exception e)
            {
                throw e;
            }

            AdresClass adres = new AdresClass(straat, huisnummer, woonplaats);
            Geslacht gelachtt = Geslacht.Man;
            if (geslacht == "Man")
            {
                gelachtt = Geslacht.Man;
            }
            else
            {
                gelachtt = Geslacht.Vrouw;
            }

            Account = new GeregistreerdeClass(accountId, naam, geboortedatum, gelachtt, adres, beroep, opleiding, email,
                skype, abbonement, modstatus, wachtwoord);
        }

        public void OphalenProducten(string productnaam, string categorie)
        {
            List<List<string>> productstrings = data.OphalenProducten(productnaam, categorie);
            Categorie categorieA = Categorie.Computers;

            if (categorie == "Laptops")
            {
                categorieA = Categorie.Laptops;
            }
            else if (categorie == "Computers")
            {
                categorieA = Categorie.Computers;
            }
            else if (categorie == "Tablets en telefoons")
            {
                categorieA = Categorie.TabletsEnTelefoons;
            }
            else if (categorie == "Mobiele telefoons")
            {
                categorieA = Categorie.MobieleTelefoons;
            }
            else if (categorie == "Laptops, dektops, en servers" )
            {
                categorieA = Categorie.LaptopDektopsEnServers;
            }

            foreach (List<string> productstring in productstrings)
            {
                producten.Add(new ProductClass(Convert.ToUInt32(productstring[0]), productstring[2], productstring[3], productstring[4], productstring[5], Convert.ToDouble(productstring[6]), categorieA));
            }
        }

        public void OphalenreviewsAccount()
        {
            List<List<string>> reviewstrings = data.OphalenReviewsAccount(Convert.ToInt32(Account.AccountId));

            foreach (List<string> reviewstring in reviewstrings)
            {
                Reviews.Add(new ReviewClass(reviewstring[4], Convert.ToInt32(reviewstring[0]), reviewstring[3], Convert.ToDateTime(reviewstring[6]), null, Account));
            }
        }
    }
}