using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class GeregistreerdeClass: AccountClass
    {
        public GeregistreerdeClass()
        {

        }
        public GeregistreerdeClass(string naam, DateTime geboortedatum, Geslacht geslacht, AdresClass adres, string beroep,
            string opleiding, string email, string skype, AbbonementClass abbonement, Modstatus modstatus, List<ReviewClass> reviews)
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
        }
    }
}