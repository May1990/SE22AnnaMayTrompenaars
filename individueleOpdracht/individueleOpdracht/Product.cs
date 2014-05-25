using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class Product
    {
        private int productId;
        private string aparaat;
        private string merk;
        private string serie;
        private string versie;


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
        
        

    }
}