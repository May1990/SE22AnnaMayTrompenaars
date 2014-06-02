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

        public WerknemerClass()
        {

        }
        public WerknemerClass(string naam, DateTime geboortedatum, Geslacht geslacht, AdresClass adres, string beroep, 
            string opleiding, string email, string skype, AbbonementClass abbonement, Modstatus modstatus, List<ReviewClass> reviews
            ,double salaris, string functie, DateTime aangenomeop)
        {
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
            base.Reviews = reviews;

            this.Salaris = salaris;
            this.Functie = functie;
            this.AangenomenOp = aangenomeop;
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
    }
}