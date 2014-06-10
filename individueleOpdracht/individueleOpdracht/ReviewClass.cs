using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class ReviewClass
    {
        private string inhoud;
        private int reviewId;
        private string titel;
        private DateTime geplaatstOp;
        private List<CommentaarClass> commentaren;
        private ProductClass product;
        private AccountClass account;
        private Databasemanager data;

        public ReviewClass(string inhoud, int reviewId, string titel, DateTime geplaatstOp
            , ProductClass product, AccountClass account)
        {
            this.Inhoud = inhoud;
            this.ReviewId = reviewId;
            this.Titel = titel;
            this.GeplaatstOp = geplaatstOp;
            this.Commentaren = new List<CommentaarClass>();
            this.Product = product;
            this.Account = account;
            this.Data = new Databasemanager();
        }

        public Databasemanager Data
        {
            get { return data; }
            set { data = value; }
        }

        public AccountClass Account
        {
            get { return account; }
            set { account = value; }
        }
        

        public ProductClass Product
        {
            get { return product; }
            set { product = value; }
        }
        

        public List<CommentaarClass> Commentaren
        {
            get { return commentaren; }
            set { commentaren = value; }
        }
        

        public DateTime GeplaatstOp
        {
            get { return geplaatstOp; }
            set { geplaatstOp = value; }
        }
        

        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }
        

        public int ReviewId
        {
            get { return reviewId; }
            set { reviewId = value; }
        }
        

        public string Inhoud
        {
            get { return inhoud; }
            set { inhoud = value; }
        }
        
        public void ToevoegenCommentaar(AccountClass account, string inhoud)
        {
            int commentId = Convert.ToInt32(data.KrijgLaatsteCommentId());
            data.ToevoegenCommentaar(Convert.ToInt32(ReviewId), Convert.ToInt32(account.AccountId), inhoud, Convert.ToInt32(Product.ProductId), commentId + 1);
        }

        public void OphalenCommentaren(int reviewIdddd)
        {
            Commentaren = new List<CommentaarClass>();
            List<List<string>> commentaarstrings = new List<List<string>>();
            commentaarstrings = data.OphalenCommentaren(reviewIdddd);

            foreach (List<string> commentaarstring in commentaarstrings)
            {
                
                List<string> accountstring = data.AccountOphalenAccountId(Convert.ToInt32(commentaarstring[0]));
                List<string> werknemerstring = data.ZoekWerknemer(Convert.ToInt32(commentaarstring[0]));

                Geslacht geslacht;
                if (accountstring[3] == "n")
                {
                    geslacht = Geslacht.Man;
                }
                else
                {
                    geslacht = Geslacht.Vrouw;
                }

                AdresClass adres = new AdresClass(accountstring[4], accountstring[5], accountstring[6]);

                AbbonementClass abbonement;
                if (accountstring[11] == "Bannervrij")
                {
                    abbonement = AbbonementClass.Bannervrij;
                }
                else
                {
                    abbonement = AbbonementClass.Gratis;
                }

                if (werknemerstring.Count == 0)
                {
                    GeregistreerdeClass geregistreerde = new GeregistreerdeClass(Convert.ToUInt32(accountstring[0]), accountstring[1], Convert.ToDateTime(accountstring[2]), geslacht, adres, accountstring[7], accountstring[8], accountstring[9], accountstring[10], abbonement, Modstatus.Actief, accountstring[13]);
                    Commentaren.Add(new CommentaarClass(commentaarstring[2], geregistreerde));
                }
                else
                {
                    WerknemerClass werknemerClass = new WerknemerClass(Convert.ToUInt32(accountstring[0]), accountstring[1], Convert.ToDateTime(accountstring[2]), geslacht, adres, accountstring[7], accountstring[8], accountstring[9], accountstring[10], abbonement, Modstatus.Actief, accountstring[13], Convert.ToDouble(werknemerstring[0]), werknemerstring[2], Convert.ToDateTime(werknemerstring[1]));
                    Commentaren.Add(new CommentaarClass(commentaarstring[2], werknemerClass));
                }
            }
        }

        public string ToString()
        {
            return "Titel: " + Titel + "    Geplaatst op: " + geplaatstOp.ToString("dd MMM yyyy") + "    Geplaatst door: " + account.Naam;
        }
    }
}