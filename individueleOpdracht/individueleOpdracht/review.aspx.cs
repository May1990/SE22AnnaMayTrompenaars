using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace individueleOpdracht
{
    public partial class review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //vul de controls met de session die is gegeven, leeg daarna de sesie
            UpdatenComments();
            
        }

        protected void BttnComm_Click(object sender, EventArgs e)
        {
            string inhoudcomment = TxtBxComm.Text;
            AdministratieClass administratie = (AdministratieClass)Session["administratie"];
            ReviewClass review = (ReviewClass)Session["review"];

            // account is null op het moment, je kunt pas een commentaar zetten als je bent inglogd
            // default account gebruiken
            AdresClass adres = new AdresClass("Smirnofstraat", "5", "Den Bosch");
            AccountClass a = new GeregistreerdeClass(1, "BarrieVanDerSloot", Convert.ToDateTime("05-02-89"), Geslacht.Man, adres, "Ramenwasser", "Media Design", "hartendiefje@gmail.com", "beestje445", AbbonementClass.Gratis, Modstatus.Actief, "UniqueBarber");
            review.ToevoegenCommentaar(a, inhoudcomment);

            UpdatenComments();
        }

        public void UpdatenComments()
        {
            ReviewClass review = (ReviewClass)Session["review"];
            LblTitel.Text = review.Titel;
            TxtBxInhoud.Text = review.Inhoud;

            review.OphalenCommentaren();

            List<CommentaarClass> commentaren = review.Commentaren;
            for (int i = 0; i < commentaren.Count; i++)
            {
                if (i == 0)
                {
                    //LblAccComment.Visible = true;
                    //TxtBxAccComm.Visible = true;
                    //LblAccComment2.Text = "";
                    CommentaarClass commentaar = commentaren[commentaren.Count - 1];
                    LblAccComment.Text = commentaar.Account.Naam;
                    TxtBxAccComm.Text = commentaar.InhoudComm;
                }
                if (i == 1)
                {
                    //LblAccComment2.Visible = true;
                    //TxtBxAccComm2.Visible = true;
                    CommentaarClass commentaar = commentaren[commentaren.Count - 2];
                    LblAccComment2.Text = commentaar.Account.Naam;
                    TxtBxAccComm2.Text = commentaar.InhoudComm;
                }
                if (i == 2)
                {
                    //LblAccComment3.Visible = true;
                    //TxtBxAccComm3.Visible = true;
                    CommentaarClass commentaar = commentaren[commentaren.Count - 3];
                    LblAccComment3.Text = commentaar.Account.Naam;
                    TxtBxAccComm3.Text = commentaar.InhoudComm;
                }
                if (i == 3)
                {
                    //LblAccComment4.Visible = true;
                    //TxtBxAccComm4.Visible = true;
                    CommentaarClass commentaar = commentaren[commentaren.Count - 4];
                    LblAccComment4.Text = commentaar.Account.Naam;
                    TxtBxAccComm4.Text = commentaar.InhoudComm;
                }
            }
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