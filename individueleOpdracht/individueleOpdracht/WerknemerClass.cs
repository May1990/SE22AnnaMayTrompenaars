using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class WerknemerClass: AccountClass
    {
        private double salaris;
        private string functie;
        private DateTime aangenomenOp;
        private Databasemanager data;

        public WerknemerClass()
        {

        }
        //public WerknemerClass(string naam, DateTime geboortedatum, Geslacht geslacht, AdresClass adres, string beroep, 
        //    string opleiding, string email, string skype, AbbonementClass abbonement, Modstatus modstatus, List<ReviewClass> reviews
        //    ,double salaris, string functie, DateTime aangenomeop)
        //{
        //    base.Naam = naam;
        //    base.GeboorteDatum = geboortedatum;
        //    base.Geslacht = geslacht;
        //    base.Adres = adres;
        //    base.Beroep = beroep;
        //    base.Opleiding = opleiding;
        //    base.Email = email;
        //    base.Skype = skype;
        //    base.Abbonement = abbonement;
        //    base.Modstatus = modstatus;
        //    base.Reviews = reviews;

        //    this.Salaris = salaris;
        //    this.Functie = functie;
        //    this.AangenomenOp = aangenomeop;
        //}

        public WerknemerClass(uint accountId, string naam, DateTime geboortedatum, Geslacht geslacht, AdresClass adres, string beroep,
            string opleiding, string email, string skype, AbbonementClass abbonement, Modstatus modstatus, string wachtwoord
            , double salaris, string functie, DateTime aangenomeop)
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

            this.Salaris = salaris;
            this.Functie = functie;
            this.AangenomenOp = aangenomeop;
            this.Data = data;
        }

        public Databasemanager Data
        {
            get { return data; }
            set { data = value; }
        }

        public DateTime AangenomenOp
        {
            get { return aangenomenOp; }
            set { aangenomenOp = value; }
        }
        

        public string Functie
        {
            get { return functie; }
            set { functie = value; }
        }
        

        public double Salaris
        {
            get { return salaris; }
            set { salaris = value; }
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