using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace individueleOpdracht
{
    public partial class reviewMaken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BttnPlRev_Click(object sender, EventArgs e)
        {
            string titel = TxtBxTitel.Text;
            string inhoud = TxtBxInhoud.Text;
            AdministratieClass administratie = (AdministratieClass)Session["administratie"];
            ProductClass product = (ProductClass) Session["product"];

            //voor test
            AdresClass adres = new AdresClass("Smirnofstraat", "5", "Den Bosch");
            AccountClass a = new GeregistreerdeClass(1, "BarrieVanDerSloot", Convert.ToDateTime("05-02-89"), Geslacht.Man, adres, "Ramenwasser", "Media Design", "hartendiefje@gmail.com", "beestje445", AbbonementClass.Gratis, Modstatus.Actief, "UniqueBarber");

            try
            {
                product.ToevoegenReview(a.AccountId, titel, inhoud);
                
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Het toevoegen van het review is niet gelukt." + "');", true);
                return;
            }

            List<ReviewClass> reviews = new List<ReviewClass>();
            product.Ophalenreviews(product);
            reviews = product.Reviews;
            Session["reviews"] = reviews;

            Server.Transfer("product.aspx");
        }

        protected void BttnCan_Click(object sender, EventArgs e)
        {
            Server.Transfer("product.aspx");
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