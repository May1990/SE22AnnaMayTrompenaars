using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    abstract public class AccountClass
    {
        private uint accountId; 
        private string naam;
        private DateTime geboorteDatum;
        private Geslacht geslacht;
        private AdresClass adres;
        private string beroep;
        private string opleiding;
        private string email;
        private string skype;
        private AbbonementClass abbonement;
        private Modstatus modstatus;
        private List<ReviewClass> reviews;
        private string wachtwoord;

        //public AccountClass(string naam, DateTime geboorteDatum, Geslacht geslacht, AdresClass adres, string beroep,
        //                        string opleiding, string email, string skype, AbbonementClass abbonement, Modstatus modstatus)
        //{
            
        //}
        public string Wachtwoord
        {
            get { return wachtwoord; }
            set { wachtwoord = value; }
        }

        public List<ReviewClass> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }
        

        public Modstatus Modstatus
        {
            get { return modstatus; }
            set { modstatus = value; }
        }
        

        public AbbonementClass Abbonement
        {
            get { return abbonement; }
            set { abbonement = value; }
        }
        

        public string Skype
        {
            get { return skype; }
            set { skype = value; }
        }
        

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        

        public string Opleiding
        {
            get { return opleiding; }
            set { opleiding = value; }
        }
        

        public string Beroep
        {
            get { return beroep; }
            set { beroep = value; }
        }
        

        public AdresClass Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        

        public Geslacht Geslacht
        {
            get { return geslacht; }
            set { geslacht = value; }
        }
        

        public DateTime GeboorteDatum
        {
            get { return geboorteDatum; }
            set { geboorteDatum = value; }
        }
        

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public uint AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public abstract void VerwijderenReview(ReviewClass review);

        public abstract void AanpassenWachtwoord(string oudWw, string nieuwWw);

    }
}