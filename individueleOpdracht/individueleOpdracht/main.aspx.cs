using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace individueleOpdracht
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LstBxResultaat.Items.Clear();
                if ((List<ProductClass>) Session["producten"] != null)
                {
                    List<ProductClass> producten = (List<ProductClass>)Session["producten"];
                    foreach (ProductClass product in producten)
                    {
                        LstBxResultaat.Items.Add(product.ToString());
                    }
                }

                AdministratieClass administratie = new AdministratieClass();
                if ((AdministratieClass)Session["administratie"] != null)
                {
                    administratie = (AdministratieClass)Session["administratie"];
                }

                if (administratie.Account.AccountId != 0)
                {
                    BttnAccount.Text = administratie.Account.Naam;
                }
            }
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

        protected void BttnZoek_Click(object sender, EventArgs e)
        {
            AdministratieClass administratie = new AdministratieClass();
            if ((AdministratieClass)Session["administratie"] != null)
            {
                administratie = (AdministratieClass)Session["administratie"];
            }

            string productnaam = TxtBxZoek.Text;
            string categorie = DDLstZoek.SelectedItem.Text;

            List<ProductClass> producten = new List<ProductClass>();
            
            administratie.OphalenProducten(productnaam, categorie);
            producten = administratie.Producten;
            Session["producten"] = producten;
            
            // misschien dubbelop met page load
            LstBxResultaat.Items.Clear();
            if (producten.Count != 0)
            {
                foreach (ProductClass product in producten)
                {
                    LstBxResultaat.Items.Add(product.ToString());
                }
            }
        }

        protected void BttnSelecteer_Click(object sender, EventArgs e)
        {
            List<ProductClass> producten = (List<ProductClass>) Session["producten"];
            int selectieNr = LstBxResultaat.SelectedIndex;
            ProductClass product = producten[selectieNr];
            List<ReviewClass> reviews = new List<ReviewClass>();
            product.Ophalenreviews(product);
            reviews = product.Reviews;
            Session["reviews"] = reviews;
            Session["product"] = product;
            Session.Contents.Remove("producten");
            Server.Transfer("product.aspx");
        }
    }
}