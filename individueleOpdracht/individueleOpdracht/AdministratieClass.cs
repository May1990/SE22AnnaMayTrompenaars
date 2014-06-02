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

        public AdministratieClass(List<ProductClass> producten, AccountClass account)
        {
            this.Producten = new List<ProductClass>();
            this.Account = new WerknemerClass(); 
        }

        public AdministratieClass(List<ProductClass> producten, AccountClass account)
        {
            this.Producten = new List<ProductClass>();
            this.Account = new GeregistreerdeClass();
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

        public void DezeAccount (string naam, DateTime geboorte, Geslacht geslacht, AdresClass adres,
            string beroep, string opleiding, string email, string skype, double salaris, string functie, DateTime aangenomenOp)
        {

        }

        public void DezeAccount (string naam, DateTime geboorte, Geslacht geslacht, AdresClass adres,
            string beroep, string opleiding, string email, string skype)
        {

        }

        public List<ProductClass> OphalenProducten(string productnaam, Categorie categorie)
        {
            return producten;
        }
    }
}