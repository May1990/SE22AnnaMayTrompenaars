using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace individueleOpdracht
{
    public partial class accountAanmaken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RdBttnMan.Checked == false && RdBttnVrouw.Checked == false)
            {
                RdBttnMan.Checked = true;
            }
        }

        protected void BttnAccAanm_Click(object sender, EventArgs e)
        {
            if (TxtBxNaam.Text == string.Empty || TxtBxGeboorte.Text == string.Empty || TxtBxStaat.Text == string.Empty ||
                TxtBxHsNr.Text == string.Empty || TxtBxPlaats.Text == string.Empty || 
                 TxtBxEmail.Text == string.Empty || TxtBxWWNieuw.Text == string.Empty)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Niet elk verplicht tekstveld is ingevulde." + "');", true);
                return;
            }

            string naam = TxtBxNaam.Text;
            DateTime geboorte = Convert.ToDateTime(TxtBxGeboorte.Text);
            string geslacht = string.Empty;
            if (RdBttnMan.Checked)
            {
                geslacht = "n";
            }
            else
            {
                geslacht = "y";
            }
            string straat = TxtBxStaat.Text;
            string huisnummer = TxtBxHsNr.Text;
            string plaats = TxtBxPlaats.Text;
            string beroep = TxtBxBeroep.Text;
            string opleiding = TxtBxOpleiding.Text;
            string email = TxtBxEmail.Text;
            string skype = TxtBxSkype.Text;
            string wachtwoord = TxtBxWWNieuw.Text;
            AdministratieClass administratie = new AdministratieClass();
            try
            {
                administratie.AccountToevoegen(wachtwoord, naam, geboorte, geslacht, straat, huisnummer, plaats, beroep, opleiding, email, skype);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Account toevoegen is mislukt." + "');", true);
                return;
            }
            Session["administratie"] = administratie;
            Server.Transfer("main.aspx");
        }

        protected void BttnCn_Click(object sender, EventArgs e)
        {
            Server.Transfer("logIn.aspx");
        }
    }
}