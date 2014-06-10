using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class ProductClass
    {
        private uint productId;
        private string aparaat;
        private string merk;
        private string serie;
        private string versie;
        private double prijs;
        private Categorie categorie;
        private List<ReviewClass> reviews;
        private Databasemanager data;

        public ProductClass(uint productId, string aparaat, string merk, string serie, string versie, double prijs, Categorie categorie)
        {
            this.ProductId = productId;
            this.Aparaat = aparaat;
            this.Merk = merk;
            this.Serie = serie;
            this.Versie = versie;
            this.Prijs = prijs;
            this.Categorie = categorie;
            this.Reviews = new List<ReviewClass>();
            this.Data = new Databasemanager(); 
        }

        public Databasemanager Data
        {
            get { return data; }
            set { data = value; }
        }

        public List<ReviewClass> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }

        public Categorie Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
        

        public double Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }
        

        public string Versie
        {
            get { return versie; }
            set { versie = value; }
        }
        

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }
        

        public string Merk
        {
            get { return merk; }
            set { merk = value; }
        }
        

        public string Aparaat
        {
            get { return aparaat; }
            set { aparaat = value; }
        }
        

        public uint ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        
        public void Ophalenreviews(ProductClass product)
        {
            List<List<string>> reviewstrings = data.OphalenReviews(Convert.ToInt32(productId));
            
            // de data zou een profiel erbij moeten geven

            foreach (List<string> reviewstring in reviewstrings)
            {
                List<string> accounttrings = data.AccountOphalenAccountId(Convert.ToInt32(reviewstring[1]));
                List<string> werknemerstrings = data.ZoekWerknemer(Convert.ToInt32(reviewstring[1]));

                Geslacht geslacht = Geslacht.Man;
                if (accounttrings[3] == "n")
                {
                    geslacht = Geslacht.Man;
                }
                else
                {
                    geslacht = Geslacht.Vrouw;
                }
                AbbonementClass abbonement = AbbonementClass.Gratis;
                if (accounttrings[11] == "Free")
                {
                    abbonement = AbbonementClass.Gratis;
                }
                else
                {
                    abbonement = AbbonementClass.Bannervrij;
                }
                AdresClass adres = new AdresClass(accounttrings[4], accounttrings[5], accounttrings[6]);

                if (werknemerstrings.Count == 0)
                {
                    GeregistreerdeClass geregistreerde = new GeregistreerdeClass(Convert.ToUInt32(accounttrings[0]), accounttrings[1], Convert.ToDateTime(accounttrings[2]), geslacht, adres, accounttrings[7], accounttrings[8], accounttrings[9], accounttrings[10], abbonement, Modstatus.Actief, accounttrings[13]);
                    Reviews.Add(new ReviewClass(reviewstring[4], Convert.ToInt32(reviewstring[0]), reviewstring[3], Convert.ToDateTime(reviewstring[6]), product, geregistreerde));
                }
                else
                {
                    WerknemerClass werknemer = new WerknemerClass(Convert.ToUInt32(accounttrings[0]), accounttrings[1], Convert.ToDateTime(accounttrings[2]), geslacht, adres, accounttrings[7], accounttrings[8], accounttrings[9], accounttrings[10], abbonement, Modstatus.Actief, accounttrings[13], Convert.ToDouble(werknemerstrings[0]), werknemerstrings[1], Convert.ToDateTime(werknemerstrings[2]));
                    Reviews.Add(new ReviewClass(reviewstring[4], Convert.ToInt32(reviewstring[0]), reviewstring[3], Convert.ToDateTime(reviewstring[6]), product, werknemer));
                }
                
            }
        }

        public void ToevoegenReview(uint accountId, string titel, string inhoud)
        {
            int reviewid = Convert.ToInt32(data.KrijgLaatsteReviewId()) + 1;
            data.ToevoegenReview(Convert.ToInt32(ProductId), Convert.ToInt32(accountId), titel, inhoud, reviewid);
        }

        public void VerwijderenReview(ReviewClass review)
        {

        }

        public string ToString()
        {
            return "Aparaat: " + aparaat + " Merk: " + merk + " Serie: " + serie + " Versie: " + versie + " Prijs: " +
                   prijs + " Categorie: " + categorie;
        }
    }
}