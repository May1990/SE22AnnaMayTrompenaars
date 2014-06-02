using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class ProductClass
    {
        private int productId;
        private string aparaat;
        private string merk;
        private string serie;
        private string versie;
        private double prijs;
        private Categorie categorie;
        private List<ReviewClass> reviews;

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
        

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        
        public List<ReviewClass> Ophalenreviews()
        {
            return reviews;
        }

        public void ToevoegenReview(string titel, string inhoud)
        {

        }

        public void VerwijderenReview(ReviewClass review)
        {

        }
    }
}