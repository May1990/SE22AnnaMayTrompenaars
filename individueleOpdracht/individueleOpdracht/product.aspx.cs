using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace individueleOpdracht
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductClass product = (ProductClass)Session["product"];

            if (!IsPostBack)
            {
                
                LblAparaat.Text = product.Aparaat;
                LblCategorie.Text = Convert.ToString(product.Categorie);
                LblMerk.Text = product.Merk;
                LblPrijs.Text = Convert.ToString(product.Prijs);
                LblSerie.Text = product.Serie;
                LblVersie.Text = product.Versie;

                List<ReviewClass> reviews = new List<ReviewClass>();
                if ((List<ReviewClass>) Session["reviews"] != null)
                {
                    reviews = (List<ReviewClass>)Session["reviews"];
                    LstBxProduct.Items.Clear();
                    foreach (ReviewClass review in reviews)
                    {
                        LstBxProduct.Items.Add(review.ToString());
                    }
                }
            }
        }

        protected void BttnNwRev_Click(object sender, EventArgs e)
        {
            
            Server.Transfer("reviewMaken.aspx");
        }

        protected void BttnBkRev_Click(object sender, EventArgs e)
        {
            List<ReviewClass> reviews = (List<ReviewClass>) Session["reviews"];
            int select = LstBxProduct.SelectedIndex;
            ReviewClass review = reviews[select];
            Session["review"] = review;
            Server.Transfer("review.aspx");
        }

        protected void BttnMain_Click(object sender, EventArgs e)
        {
            Server.Transfer("main.aspx");
        }

        protected void BttnLogUit_Click(object sender, EventArgs e)
        {
            AdministratieClass administratie = new AdministratieClass();
            if ((AdministratieClass)Session["administratie"] != null)
            {
                administratie = (AdministratieClass)Session["administratie"];
            }

            if (administratie.Account.AccountId == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "U bent niet ingelogd." + "');", true);
            }
            else
            {
                Session.Contents.Remove("accountype");
                Session.Contents.Remove("administrator");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "U bent succevol uitgelogd." + "');", true);
                BttnAccount.Text = "Inloggen";
            }

        }

        protected void BttnAccount_Click(object sender, EventArgs e)
        {
            if (BttnAccount.Text == "Inloggen")
            {
                Server.Transfer("logIn.aspx");
            }
            else
            {
                Server.Transfer("account.aspx");
            }
        }
    }
}