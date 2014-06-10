using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class GeregistreerdeClass: AccountClass
    {
        private Databasemanager data;
        public GeregistreerdeClass()
        {

        }
        public GeregistreerdeClass(uint accountId,string naam, DateTime geboortedatum, Geslacht geslacht, AdresClass adres, string beroep,
            string opleiding, string email, string skype, AbbonementClass abbonement, Modstatus modstatus, string wachtwoord)
        {
            base.AccountId = accountId;
            base.Naam = naam;
            base.GeboorteDatum = geboortedatum;
            base.Geslacht = geslacht;
            base.Adres = adres;
            base.Beroep = beroep;
            base.Opleiding = opleiding;
            base.Email = email;
            base.Skype = skype;
            base.Abbonement = abbonement;
            base.Modstatus = modstatus;
            base.Wachtwoord = wachtwoord;
            base.Reviews = new List<ReviewClass>();
            this.Data = new Databasemanager();
        }

        public Databasemanager Data
        {
            get { return data; }
            set { data = value; }
        }

        public override void AanpassenWachtwoord(string oudWw, string nieuwWw)
        {
            data.UpdateWachtwoord(oudWw, nieuwWw, base.AccountId);
        }

        public override void VerwijderenReview(ReviewClass review)
        {
            
        }
    }
}