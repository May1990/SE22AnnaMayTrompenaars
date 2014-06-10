using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace individueleOpdracht
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdministratieClass administratie = (AdministratieClass) Session["administratie"];

            if (!IsPostBack)
            {
                List<ReviewClass> reviews = new List<ReviewClass>();
                try
                {
                    administratie.OphalenreviewsAccount();
                    reviews = administratie.Reviews;
                    Session["reviews"] = reviews;
                }
                catch (Exception)
                {
                    throw;
                }
                
                LstBxEigRev.Items.Clear();
                foreach (ReviewClass review in reviews)
                {
                    LstBxEigRev.Items.Add(review.ToString());
                }

                LblNaam.Text = administratie.Account.Naam;
                LblGeslacht.Text = administratie.Account.Geslacht.ToString();
                LblGebDatum.Text = administratie.Account.GeboorteDatum.ToString();
                LblAdres.Text = administratie.Account.Adres.ToString();
                LblBeroep.Text = administratie.Account.Beroep;
                LblOpleiding.Text = administratie.Account.Opleiding;
                LblEmail.Text = administratie.Account.Email;
                LblSkype.Text = administratie.Account.Skype;
                LblAbbo.Text = administratie.Account.Abbonement.ToString();
                LblMStatus.Text = administratie.Account.Modstatus.ToString();
            }

        }

        protected void BttnAanpWW_Click(object sender, EventArgs e)
        {
            string oudWw = TxtBxOudWW.Text;
            string nieuwWw = TxtBxNieuwWW.Text;
            AdministratieClass administratie = (AdministratieClass)Session["administratie"];

            if (oudWw == string.Empty || nieuwWw == string.Empty)
            {
                return;
            }

            try
            {
                administratie.Account.AanpassenWachtwoord(oudWw, nieuwWw);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Het veranderen van het wachtwoord is geslaagd." + "');", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Het veranderen van het wachtwoord is niet gelukt." + "');", true);
            }
        }

        protected void BttnAanp_Click(object sender, EventArgs e)
        {
            //to do
            // voor nu even buiten beschouwing laten
        }

        protected void BttnKijkRev_Click(object sender, EventArgs e)
        {
            List<ReviewClass> reviews = (List<ReviewClass>)Session["reviews"];
            int select = LstBxEigRev.SelectedIndex;
            ReviewClass review = reviews[select];
            Session["review"] = review;
            Server.Transfer("review.aspx");
        }

        protected void BttnVerwRev_Click(object sender, EventArgs e)
        {
            //to do
        }
    }
}