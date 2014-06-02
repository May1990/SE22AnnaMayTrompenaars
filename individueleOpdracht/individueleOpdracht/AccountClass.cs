using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    abstract public class AccountClass
    {
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
        
        public void AanpassenWachtwoord(string oudWW, string nieuwWW)
        {

        }

        public List<ReviewClass> Ophalenreviews()
        {
            return reviews;
        }

        public void VerwijderenReview(ReviewClass review)
        {

        }
    }
}