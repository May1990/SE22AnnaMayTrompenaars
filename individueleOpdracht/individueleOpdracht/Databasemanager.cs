//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;



namespace individueleOpdracht
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System.Configuration;
    //using System.Data.OracleClient;
    using System.Web.Providers.Entities;

    public class Databasemanager
    {
        private OracleConnection connectie;

        //private string Pcn = "dbi296086";
        //private string wachtwoord = "L79567vuYu";
        //public string DataSource { get; private set; }

        public Databasemanager()
        {
            //if (System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString !=
            //    null)
            //{
                this.connectie = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //}
            //else
            //{
            //    this.connectie.ConnectionString =
            //        string.Format("User Id= {0};Password={1};Data Source=//192.168.15.50:1521/fhictora;", Pcn , wachtwoord , DataSource);
            //}
            
        }

        public List<string> Inloggen(string email, string wachtwoord)
        {
            connectie.Open();
            string query = "SELECT * FROM AACCOUNT WHERE EMAIL= :EMAIL AND ACCOUNTPASSWORD = :PASSWORD";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("EMAIL", email));
            command.Parameters.Add(new OracleParameter("PASSWORD", wachtwoord));
            OracleDataReader reader = command.ExecuteReader();

            List<string> accountInfo = new List<string>();

            try
            {
                while (reader.Read())
                {
                    accountInfo.Add((string)reader["AccountId"].ToString());
                    accountInfo.Add((string)reader["AccountName"]);
                    accountInfo.Add((string)reader["DatOfBirth"].ToString());
                    accountInfo.Add((string)reader["Sex"]);
                    accountInfo.Add((string)reader["Street"]);
                    accountInfo.Add((string)reader["HouseNumber"]);
                    accountInfo.Add((string)reader["Place"]);
                    accountInfo.Add((string)reader["Profession"]);
                    accountInfo.Add((string)reader["Education"]);
                    accountInfo.Add((string)reader["Email"]);
                    accountInfo.Add((string)reader["Skype"]);
                    accountInfo.Add((string)reader["Subcription"]);
                    accountInfo.Add((string)reader["Modstatus"]);
                    accountInfo.Add((string)reader["AccountPassword"]);
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
            return accountInfo;
        }

        public List<string> ZoekWerknemer(int ACCOUNTID)
        {
            connectie.Open();

            string query = "SELECT * FROM EMPLOYEE WHERE ACCOUNTID= :ACCOUNTID";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("ACCOUNTID", ACCOUNTID));
            OracleDataReader reader = command.ExecuteReader();

            List<string> werknemerInfo = new List<string>();
            try
            {
                while (reader.Read())
                {
                    werknemerInfo.Add((string)reader["Salary"].ToString());
                    werknemerInfo.Add((string)reader["HiredSince"].ToString());
                    werknemerInfo.Add((string)reader["AFunction"]);
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
            return werknemerInfo;
        }

        public void ToevoegenAccount(string wachtwoord, string naam, DateTime geboortdatum, string geslacht,
            string huisnummer,
            string straat, string woonplaats, string beroep, string opleiding, string email, string skype,
            string abbonement, string modstatus, int accountid)
        {
            connectie.Open();



            string query = "INSERT INTO AACCOUNT VALUES ( :ACCOUNTID, :NAAM , :WACHTWOORD , :GEBOORTEDATUM , :SEX , :STRAAT , :HUISNUMMER, :WOONPLAATS, :BEROEP , :OPLEIDING , :EMAIL , :SKYPE , :ABBONEMENT, :MODSTATUS)";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("ACCOUNTID", accountid));
            command.Parameters.Add(new OracleParameter("NAAM", naam));
            command.Parameters.Add(new OracleParameter("WACHTWOORD", wachtwoord));
            command.Parameters.Add(new OracleParameter("GEBOORTEDATUM", geboortdatum ));
            command.Parameters.Add(new OracleParameter("SEX", geslacht));
            command.Parameters.Add(new OracleParameter("STRAAT", straat));
            command.Parameters.Add(new OracleParameter("HUISNUMMER", huisnummer));
            command.Parameters.Add(new OracleParameter("WOONPLAATS", woonplaats));
            command.Parameters.Add(new OracleParameter("BEROEP", beroep));
            command.Parameters.Add(new OracleParameter("OPLEIDING", opleiding));
            command.Parameters.Add(new OracleParameter("EMAIL", email));
            command.Parameters.Add(new OracleParameter("SKYPE", skype));
            command.Parameters.Add(new OracleParameter("ABBONEMENT", abbonement));
            command.Parameters.Add(new OracleParameter("MODSTATUS", modstatus));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
        }

        public string KrijgLaatsteAccountId()
        {
            connectie.Open();

            string query = "SELECT MAX(ACCOUNTID) AS ACCOUNTID FROM AACCOUNT";

            string accountId = "400";


            try
            {
                OracleCommand command = new OracleCommand(query, connectie);
                OracleDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    accountId = (string)reader[0].ToString();
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }

            return accountId;
        }

        public void ToevoegenWerknemer(uint accountId, double salaris, DateTime aangenomenop, string functie)
        {
            connectie.Open();

            string query = "INSERT INTO EMPLOYEE VALUES ( :ACCOUNTID , :SALARIS , :AANGENOMENOP , :FUNCTIE)";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("ACCOUNTID", accountId));
            command.Parameters.Add(new OracleParameter("SALARIS", salaris));
            command.Parameters.Add(new OracleParameter("AANGENOMENOP", aangenomenop));
            command.Parameters.Add(new OracleParameter("FUNCTIE", functie));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
        }

        public string OphalenAccountId(string email)
        {
            connectie.Open();

            string query = "SELECT ACCOUNTID FROM AACCOUNT WHERE EMAIL = :EMAIL";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("EMAIL", email));
            OracleDataReader reader = command.ExecuteReader();

            string accountId = "0";
            try
            {
                while (reader.Read())
                {
                    accountId = (string)reader["ACCOUNTID"];
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
            return accountId;
        }

        public void UpdateWachtwoord(string oudWW, string nieuwWW, uint accountid)
        {
            connectie.Open();

            string query = "UPDATE AACCOUNT SET PASSWORD = :NIEUWWW WHERE ACCOUNTID = :ACCOUNTID AND PASSWORD = :OUDWW";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("NIEUWWW", nieuwWW));
            command.Parameters.Add(new OracleParameter("ACCOUNTID", accountid));
            command.Parameters.Add(new OracleParameter("OUDWW", oudWW));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
        }

        public List<List<string>> OphalenProducten(string ELEKTRONICNAME, string CATEGORYNAME)
        {
            connectie.Open();

            string query = "SELECT * FROM ELEKTRONIC WHERE CATEGORYID = (SELECT CATEGORYID FROM ACATEGORY WHERE CATEGORYNAME = :CATEGORYNAME) AND ELEKTRONICNAME = :ELEKTRONICNAME";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("CATEGORYNAME", CATEGORYNAME));
            command.Parameters.Add(new OracleParameter("ELEKTRONICNAME", ELEKTRONICNAME));
            OracleDataReader reader = command.ExecuteReader();

            List<List<string>> producten = new List<List<string>>();
            try
            {
                
                while (reader.Read())
                {
                    List<string> product = new List<string>();
                    product.Add((string)reader["ELEKTRONICID"].ToString());
                    product.Add((string)reader["CATEGORYID"].ToString());
                    product.Add((string)reader["ELEKTRONICNAME"]);
                    product.Add((string)reader["BRAND"]);
                    product.Add((string)reader["SERIE"]);
                    product.Add((string)reader["AVERSION"]);
                    product.Add((string)reader["PRICE"].ToString());
                    producten.Add(product);
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
            return producten;
        }

        public void ToevoegenReview(int productid, int accountid, string titel, string content, int reviewId)
        {
            connectie.Open();

            //string vandaag = DateTime.Today.ToString("yyyy-MM-dd");
            //DateTime vandaag = DateTime.Now;
            string vandaag = DateTime.Now.ToString("dd-MM-yyyy");
            //string vandaag = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            string query = "INSERT INTO REVIEW VALUES ( :REVIEWID , :ACCOUNTID , :PRODUCTID , :TITEL , :CONTENT , 0 , :VANDAAG , 0)";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("REVIEWID", reviewId));
            command.Parameters.Add(new OracleParameter("ACCOUNTID", accountid));
            command.Parameters.Add(new OracleParameter("PRODUCTID", productid));
            command.Parameters.Add(new OracleParameter("TITEL", titel));
            command.Parameters.Add(new OracleParameter("CONTENT", content));
            command.Parameters.Add(new OracleParameter("VANDAAG", vandaag) );
            //command.Parameters.Add(new OracleParameter("VANDAAG", vandaag));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
        }

        public string KrijgLaatsteReviewId()
        {
            connectie.Open();

            string query = "SELECT MAX(REVIEWID) AS REVIEWID FROM REVIEW";

            OracleCommand command = new OracleCommand(query, connectie);
            OracleDataReader reader = command.ExecuteReader();

            string reviewId = "400";

            try
            {
                while (reader.Read())
                {
                    reviewId = (string)reader[0].ToString();
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }

            return reviewId;
        }

        public List<List<string>> OphalenCommentaren(int REVIEWID)
        {
            connectie.Open();

            string query = "SELECT * FROM ACOMMENT WHERE REVIEWID = :REVIEWID ORDER BY COMMENTID";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("REVIEWID", REVIEWID));
            OracleDataReader reader = command.ExecuteReader();

            List<List<string>> commentaren = new List<List<string>>();
            try
            {
                while (reader.Read())
                {
                    List<string> commentaar = new List<string>();
                    commentaar.Add((string)reader["ACCOUNTID"].ToString());
                    commentaar.Add((string)reader["ELEKTRONICID"].ToString());
                    commentaar.Add((string)reader["ACONTENT"]);
                    commentaren.Add(commentaar);
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }

            return commentaren;
        }

        public void ToevoegenCommentaar(int REVIEWID, int ACCOUNTID, string ACONTENT, int ELEKTRONICID, int COMMENTID)
        {
            connectie.Open();

            string query =
                "INSERT INTO ACOMMENT VALUES ( :COMMENTID , :ACCOUNTID , :REVIEWID , :ELEKTRONICID , 1 , :ACONTENT)";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("COMMENTID", COMMENTID));
            command.Parameters.Add(new OracleParameter("ACCOUNTID", ACCOUNTID));
            command.Parameters.Add(new OracleParameter("REVIEWID", REVIEWID));
            command.Parameters.Add(new OracleParameter("ELEKTRONICID", ELEKTRONICID));

            command.Parameters.Add(new OracleParameter("ACONTENT", ACONTENT));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
        }

        public string KrijgLaatsteCommentId()
        {
            connectie.Open();

            string query = "SELECT MAX(COMMENTID) AS COMMENTID FROM ACOMMENT";

            OracleCommand command = new OracleCommand(query, connectie);
            OracleDataReader reader = command.ExecuteReader();

            string commentId = "400";

            try
            {
                while (reader.Read())
                {
                    commentId = (string)reader[0].ToString();
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }

            return commentId;
        }

        public List<List<string>> OphalenReviewsAccount(int accountid)
        {
            connectie.Open();

            string query = "SELECT * FROM REVIEW WHERE ACCOUNTID = :ACCOUNTID";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("ACCOUNTID", accountid));
            OracleDataReader reader = command.ExecuteReader();

            List<List<string>> reviews = new List<List<string>>();
            try
            {
                while(reader.Read())
                {
                    List<string> review = new List<string>();
                    review.Add((string)reader["ReviewID"].ToString());
                    review.Add((string)reader["AccountID"].ToString());
                    review.Add((string)reader["ElektronicID"].ToString());
                    review.Add((string)reader["Titel"]);
                    review.Add((string)reader["aContent"]);
                    review.Add((string)reader["Rating"].ToString());
                    review.Add((string)reader["PublishDate"].ToString());
                    review.Add((string)reader["aViews"].ToString());
                    reviews.Add(review);
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
            return reviews;
        }

        public List<List<string>> OphalenReviews(int ELEKTRONICID)
        {
            connectie.Open();

            string query = "SELECT * FROM REVIEW WHERE ELEKTRONICID = :ELEKTRONICID ";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("ELEKTRONICID", ELEKTRONICID));
            OracleDataReader reader = command.ExecuteReader();

            List<List<string>> reviews = new List<List<string>>();
            try
            {
                while(reader.Read())
                {
                    List<string> review = new List<string>();
                    review.Add((string)reader["ReviewID"].ToString());
                    review.Add((string)reader["AccountID"].ToString());
                    review.Add((string)reader["ElektronicID"].ToString());
                    review.Add((string)reader["Titel"]);
                    review.Add((string)reader["aContent"]);
                    review.Add((string)reader["Rating"].ToString());
                    review.Add((string)reader["PublishDate"].ToString());
                    review.Add((string)reader["aViews"].ToString());
                    reviews.Add(review);
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }

            return reviews;
        }

        public List<string> AccountOphalenAccountId(int ACCOUNTID)
        {
            connectie.Open();

            string query = "SELECT * FROM AACCOUNT WHERE ACCOUNTID= :ACCOUNTID";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("ACCOUNTID", ACCOUNTID));
            OracleDataReader reader = command.ExecuteReader();

            List<string> accountInfo = new List<string>();

            try
            {
                while(reader.Read())
                {
                    accountInfo.Add((string)reader["AccountId"].ToString());
                    accountInfo.Add((string)reader["AccountName"]);
                    accountInfo.Add((string)reader["DatOfBirth"].ToString());
                    accountInfo.Add((string)reader["Sex"]);
                    accountInfo.Add((string)reader["Street"]);
                    accountInfo.Add((string)reader["HouseNumber"]);
                    accountInfo.Add((string)reader["Place"]);
                    accountInfo.Add((string)reader["Profession"]);
                    accountInfo.Add((string)reader["Education"]);
                    accountInfo.Add((string)reader["Email"]);
                    accountInfo.Add((string)reader["Skype"]);
                    accountInfo.Add((string)reader["Subcription"]);
                    accountInfo.Add((string)reader["Modstatus"]);
                    accountInfo.Add((string)reader["AccountPassword"]);
                }
                //command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }

            return accountInfo;
        }

        public void VerwijderenReview(uint reviewid)
        {
            connectie.Open();

            string query = "DELETE * FROM REVIEW WHERE REVIEWID = :REVIEWID";

            OracleCommand command = new OracleCommand(query, connectie);
            command.Parameters.Add(new OracleParameter("REVIEWID", reviewid));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connectie.Close();
            }
        }

    }
}
