using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace individueleOpdracht
{
    public partial class logIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BttnLogIn_Click(object sender, EventArgs e)
        {
            string email = TxtBxEmail.Text;
            string wachtwoord = TxtBxWW.Text;

            AdministratieClass administratie = new AdministratieClass();
            string account = string.Empty;
            
            try
            {
                Session["accountType"] = administratie.Inloggen(email, wachtwoord);
                Session["administratie"] = administratie;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Email en/of wachtwoord is incorrect" + "');", true);
                return;
            }

            Server.Transfer("main.aspx");
        }

        protected void BttnCanc_Click(object sender, EventArgs e)
        {
            Server.Transfer("main.aspx");
        }

        protected void BttnAanmAcc_Click(object sender, EventArgs e)
        {
            Server.Transfer("accountAanmaken.aspx");
        }
    }
}