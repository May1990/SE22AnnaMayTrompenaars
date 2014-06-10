using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace individueleOpdracht
{
    public class Databasemanager
    {
       
        static string Pcn = "dbi296086";
        static string Wachtwoord = "L79567vuYu";
        private OracleConnection connection = new OracleConnection();

        public Databasemanager()
        {
            Pcn = "dbi296086";
            Wachtwoord = "L79567vuYu";
            connection.ConnectionString =
                string.Format("User Id={0};Password = {1};Data source=//192.168.15.50:1521/fhictora;", Pcn, Wachtwoord,
                    DataSource);
        }

        public string DataSource { get; private set; }

        public void SetUpConnection(string username, string wachtwoord, string dataSource)
        {
            Pcn = username;
            Wachtwoord = wachtwoord;
            DataSource = dataSource;
            connection.ConnectionString = string.Format("User Id={0};Password = {1};Data source={2};", Pcn, wachtwoord,
                DataSource);
        }

        private void OpenAConnection()
        {
            if (connection.ConnectionString == null || connection.ConnectionString == "")
            {
                connection.ConnectionString = "User Id=" + Pcn + ";Password=" + Wachtwoord + ";Data Source=" +
                                              DataSource + ";";
            }
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                throw; 
            }
        }

        public List<string> Inloggen(string email, string wachtwoord)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query = "SELECT * FROM ACCOUNT WHERE EMAIL=" + email + " AND PASSWORD =" + " '" + wachtwoord + "';";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<string> accountInfo = new List<string>();
            try
            {
                
                dataReader = command.ExecuteReader();
                dataReader.Read();
                accountInfo.Add((string) dataReader["AccountId"]);
                accountInfo.Add((string) dataReader["AccountName"]);
                accountInfo.Add((string) dataReader["DatOfBirth"].ToString());
                accountInfo.Add((string) dataReader["Sex"]);
                accountInfo.Add((string) dataReader["Street"]);
                accountInfo.Add((string) dataReader["HouseNumber"]);
                accountInfo.Add((string) dataReader["Place"]);
                accountInfo.Add((string) dataReader["Profession"]);
                accountInfo.Add((string) dataReader["Education"]);
                accountInfo.Add((string) dataReader["Email"]);
                accountInfo.Add((string) dataReader["Skype"]);
                accountInfo.Add((string) dataReader["Subscription"]);
                accountInfo.Add((string) dataReader["Modstatus"]);
                //List<string> werknemerinfo = ZoekWerknemer((string) dataReader["AccountId"]);
                //if (werknemerinfo.Count != 0)
                //{
                //    foreach (string werknemer in werknemerinfo)
                //    {
                //        accountInfo.Add(werknemer);
                //    }
                //}
                accountInfo.Add((string)dataReader["AccountPassword"]);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return accountInfo;
        }

        public List<string> ZoekWerknemer(int accountid)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query = "SELECT * FROM EMPLOYEE WHERE ACCOUNTID="+ accountid + ";";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<string> werknemerInfo = new List<string>();
            try
            {
                dataReader = command.ExecuteReader();
                dataReader.Read();
                werknemerInfo.Add((string) dataReader["Salary"]);
                werknemerInfo.Add((string) dataReader["HiredSince"]);
                werknemerInfo.Add((string) dataReader["Function"]);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return werknemerInfo;
        }

        public void ToevoegenAccount(string wachtwoord, string naam, DateTime geboortdatum, string geslacht, string huisnummer, 
            string straat, string woonplaats, string beroep, string opleiding, string email, string skype, string abbonement, string modstatus)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string sex;
            if (geslacht == "Man")
            {
                sex = "n";
            }
            else
            {
                sex = "y";
            }
            string queryAccount = "INSERT INTO ACCOUNT VALUES ( seq_Account.NEXTVAL, '" + naam + "' , '"+ wachtwoord + "' , '" + geboortdatum + "' , '" + sex + "' , '" + straat + "' , '" + huisnummer + 
               "' , '" + woonplaats + "' , '" + beroep + "' , '" + opleiding + "' , '" + email + "' , '" + skype + "' , '" + abbonement + "' , '" + modstatus+ ");";
            
            
            OracleCommand command = new OracleCommand(queryAccount, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;
            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void ToevoegenWerknemer(uint accountId, double salaris, DateTime aangenomenop, string functie)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string queryEmployee = "INSERT INTO EMPLOYEE VALUES ( " + accountId + " , " + salaris + " , '" + aangenomenop + "' , '" + functie + "');";
            OracleCommand command = new OracleCommand(queryEmployee, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;
            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

       //public void ToevoegenAccount(string naam, DateTime geboortdatum, string geslacht, string huisnummer, 
       //     string straat, string woonplaats, string beroep, string opleiding, string email, string skype, string abbonement, string modstatus)
       // {
       //     try
       //     {
       //         OpenAConnection();
       //     }
       //     catch
       //     {
       //         throw;
       //     }
            
       //     string query = "INSERT INTO ACCOUNT VALUES ( seq_Account.NEXTVAL ,'" + naam + "' , '" + geboortdatum + "' , '" + geslacht + "' , '" + straat + "' , '" + huisnummer + 
       //        "' , '" + woonplaats + "' , '" + beroep + "' , '" + opleiding + "' , '" + email + "' , '" + skype + "' , '" + abbonement + "' , '" + modstatus+ ")";
            
       //     OracleCommand command = new OracleCommand(query, connection);
       //     command.CommandType = CommandType.Text;
       //     OracleDataReader dataReader;
       //     try
       //     {
       //         dataReader = command.ExecuteReader();
       //     }
       //     catch (Exception e)
       //     {
       //         throw e;
       //     }
       //     finally
       //     {
       //         connection.Close();
       //     }
       // }

        public string OphalenAccountId(string email)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query = "SELECT ACCOUNTID FROM ACCOUNT WHERE EMAIL = '" + email + "';";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            string accountId;
            try
            {
                dataReader = command.ExecuteReader();
                dataReader.Read();
                
                accountId = (string)dataReader["ACCOUNTID"];
            }
            catch (Exception e)
            {
                throw e;
            }
            return accountId;
        }

        public void UpdateWachtwoord(string oudWW, string nieuwWW, uint accountid)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query = "UPDATE ACCOUNT SET PASSWORD = '" + nieuwWW + "' WHERE ACCOUNTID = " + accountid +
                           "AND PASSWORD = " + oudWW + ";";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
                throw e;
            }
            finally
            {
                connection.Close();
            }

        }

        public List<List<string>> OphalenProducten(string productnaam, string categorie)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query ="SELECT * FROM ELEKTRONIC WHERE CATEGORYID = (SELECT CATEGORYID FROM CATEGORY WHERE CATEGORYNAME = '" +
                categorie + "';) AND ELEKTRONAME = '" + productnaam + "';";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<List<string>> producten = new List<List<string>>();
            try
            {
                dataReader = command.ExecuteReader();
                dataReader.Read();
                List<string> product = new List<string>();
                product.Add((string) dataReader["ELEKTRONICID"]);
                product.Add((string) dataReader["CATEGORYID"]);
                product.Add((string) dataReader["ELEKTRONAME"]);
                product.Add((string) dataReader["BRAND"]);
                product.Add((string) dataReader["SERIE"]);
                product.Add((string) dataReader["VERSION"]);
                product.Add((string) dataReader["PRICE"]);
                producten.Add(product);
            }
            catch (Exception e)
            { 
                throw e;
            }
            return producten;
        }

        public void ToevoegenReview(uint productid, uint accountid, string titel, string content)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query = "INSERT INTO REVIEW VALUES ( seq_Review.NEXTVAL , " + accountid + " , " + productid + " , '" + titel + "' , '" + content +
               "' , " + 0 + " , '" + DateTime.Today + "' , " + 0 + ");";

            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;
            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<List<string>> OphalenCommentaren(uint reviewid)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string queryCommentaar = "SELECT * FROM COMMENT WHERE REVIEWID = " + reviewid + ";";
            //string queryAccount =
            //    "SELECT * FROM ACCOUNT WHERE ACCOUNTID IS(SELECT ACCOUNTID FROM COMMENT WHERE REVIEWID =" + reviewid +
            //    ";";
            OracleCommand commandCommentaar = new OracleCommand(queryCommentaar, connection);
            //OracleCommand commandAccount = new OracleCommand(queryAccount, connection);
            commandCommentaar.CommandType = CommandType.Text;
            //commandAccount.CommandType = CommandType.Text;
            OracleDataReader dataReaderCommentaar;
            //OracleDataReader dataReaderAccount;

            List<List<string>> commentaren = new List<List<string>>();
            try
            {
                dataReaderCommentaar = commandCommentaar.ExecuteReader();
                //dataReaderAccount = commandAccount.ExecuteReader();zoe
                dataReaderCommentaar.Read();
                //dataReaderAccount.Read();
                List<string> commentaar = new List<string>();

                commentaar.Add((string)dataReaderCommentaar["ACCOUNTID"]);
                commentaar.Add((string)dataReaderCommentaar["ELEKTRONICID"]);
                commentaar.Add((string)dataReaderCommentaar["CONTENT"]);

                //commentaar.Add((string)dataReaderAccount["AccountId"]);
                //commentaar.Add((string)dataReaderAccount["Name"]);
                //commentaar.Add((string)dataReaderAccount["DateOfBirth"].ToString());
                //commentaar.Add((string)dataReaderAccount["Sex"]);
                //commentaar.Add((string)dataReaderAccount["Street"]);
                //commentaar.Add((string)dataReaderAccount["AdressNumber"]);
                //commentaar.Add((string)dataReaderAccount["Homeplace"]);
                //commentaar.Add((string)dataReaderAccount["Proffession"]);
                //commentaar.Add((string)dataReaderAccount["Education"]);
                //commentaar.Add((string)dataReaderAccount["Email"]);
                //commentaar.Add((string)dataReaderAccount["Skype"]);
                //commentaar.Add((string)dataReaderAccount["Subscription"]);
                //commentaar.Add((string)dataReaderAccount["Modstatus"]);

                commentaren.Add(commentaar);
            }
            catch (Exception e)
            {
                throw e;
            }
            return commentaren;
        }
        public void ToevoegenCommentaar(uint reviewid, uint accountid, string inhoudComm, uint productid)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            // add auto number
            // let op de datetime
            string query = "INSERT INTO COMMENT VALUES ( seq_Comment.NEXTVAL , " + accountid + " , " + reviewid + " , " + productid + " , " + null +
               " , '" + inhoudComm + "');";

            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;
            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<List<string>> OphalenReviewsAccount(uint accountid)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query = "SELECT * FROM REVIEW WHERE ACCOUNTID = " + accountid + ";";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<List<string>> reviews = new List<List<string>>();
            try
            {
                dataReader = command.ExecuteReader();
                dataReader.Read();
                List<string> review = new List<string>();
                review.Add((string)dataReader["ReviewID"]);
                review.Add((string)dataReader["AccountID"]);
                review.Add((string)dataReader["ElektronicID"]);
                review.Add((string)dataReader["Titel"]);
                review.Add((string)dataReader["aContent"]);
                review.Add((string)dataReader["Rating"]);
                review.Add((string)dataReader["PublishDate"]);
                review.Add((string)dataReader["aViews"]);
                reviews.Add(review);
            }
            catch (Exception e)
            { 
                throw e;
            }
            return reviews;
        }

        public List<List<string>> OphalenReviews(uint productid)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            string query = "SELECT * FROM REVIEW WHERE ELEKTRONICID = " + productid + ";";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<List<string>> reviews = new List<List<string>>();
            try
            {
                dataReader = command.ExecuteReader();
                dataReader.Read();
                List<string> review = new List<string>();
                review.Add((string)dataReader["ReviewID"]);
                review.Add((string)dataReader["AccountID"]);
                review.Add((string)dataReader["ElektronicID"]);
                review.Add((string)dataReader["Titel"]);
                review.Add((string)dataReader["aContent"]);
                review.Add((string)dataReader["Rating"]);
                review.Add((string)dataReader["PublishDate"]);
                review.Add((string)dataReader["aViews"]);
                reviews.Add(review);
            }
            catch (Exception e)
            {
                throw e;
            }
            return reviews;
        }

        public List<string> AccountOphalenAccountId(int accountid)
        {
            List<string> pp = new List<string>();
            return pp;
        }

        public void VerwijderenReview(uint reviewid)
        {
            try
            {
                OpenAConnection();
            }
            catch
            {
                throw;
            }

            // reviewid is a uint right now... what does there need to be when you want to remove it?
            string query = "DELETE * FROM REVIEW WHERE REVIEWID = '" + reviewid + "';";

            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;
            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}