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

        public ReviewClass(string inhoud, int reviewId, string titel, DateTime geplaatstOp, List<CommentaarClass> commentaren
            , ProductClass product, AccountClass account)
        {
            this.Inhoud = inhoud;
            this.ReviewId = reviewId;
            this.Titel = titel;
            this.GeplaatstOp = geplaatstOp;
            this.Commentaren = commentaren;
            this.Product = product;
            this.Account = account;
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

        }
    }
}