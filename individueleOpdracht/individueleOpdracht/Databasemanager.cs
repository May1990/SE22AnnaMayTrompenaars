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

            // what if person is a employee? 
            List<string> accountInfo = new List<string>();
            try
            {
                
                dataReader = command.ExecuteReader();
                dataReader.Read();
                accountInfo.Add((string) dataReader["AccountId"]);
                accountInfo.Add((string) dataReader["Name"]);
                accountInfo.Add((string) dataReader["DateOfBirth"].ToString());
                accountInfo.Add((string) dataReader["Sex"]);
                accountInfo.Add((string) dataReader["Street"]);
                accountInfo.Add((string) dataReader["AdressNumber"]);
                accountInfo.Add((string) dataReader["Homeplace"]);
                accountInfo.Add((string) dataReader["Proffession"]);
                accountInfo.Add((string) dataReader["Education"]);
                accountInfo.Add((string) dataReader["Email"]);
                accountInfo.Add((string) dataReader["Skype"]);
                accountInfo.Add((string) dataReader["Subscription"]);
                accountInfo.Add((string) dataReader["Modstatus"]);
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

        public void ToevoegenAccount(string naam, DateTime geboortdatum, string geslacht, string huisnummer, 
            string straat, string woonplaats, string beroep, string opleiding, string email, string skype, double salaris, string functie, DateTime aangenomenOp, string abbonement, string modstatus)
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
            string queryAccount = "INSERT INTO ACCOUNT VALUES ( '" + naam + "' , '" + geboortdatum + "' , '" + geslacht + "' , '" + straat + "' , '" + huisnummer + 
               "' , '" + woonplaats + "' , '" + beroep + "' , '" + opleiding + "' , '" + email + "' , '" + skype + "' , '" + abbonement + "' , '" + modstatus+ ");";
            // add auto number
            // do there need to ben ; ad every end?
            string queryEmployee = "INSERT INTO EMPLOYEE VALUES ( '" + salaris + "' , '" + aangenomenOp + "' , '" + functie + ");";
            
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

       public void ToevoegenAccount(string naam, DateTime geboortdatum, string geslacht, string huisnummer, 
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

            // add auto number
            string query = "INSERT INTO ACCOUNT VALUES ( '" + naam + "' , '" + geboortdatum + "' , '" + geslacht + "' , '" + straat + "' , '" + huisnummer + 
               "' , '" + woonplaats + "' , '" + beroep + "' , '" + opleiding + "' , '" + email + "' , '" + skype + "' , '" + abbonement + "' , '" + modstatus+ ")";
            
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;
            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateWachtwoord(string oudWW, string nieuwWW, int accountid)
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

            string query =
                "SELECT * FROM ELEKTRONIC WHERE CATEGORYID = (SELECT CATEGORYID FROM CATEGORY WHERE CATEGORYNAME = '" +
                categorie + "';) AND ELEKTRONAME = '" + productnaam + "';";
            OracleCommand command = new OracleCommand(query, connection);
            command.CommandType = CommandType.Text;
            OracleDataReader dataReader;

            List<List<string>> producten = new List<List<string>>();
            try
            {
                List<string> product = new List<string>();
                product.Add((string)dataReader["ELEKTRONICID"]);
                product.Add((string)dataReader["CATEGORYID"]);
                product.Add((string)dataReader["ELEKTRONAME"]);
                product.Add((string)dataReader["BRAND"]);
                product.Add((string)dataReader["SERIE"]);
                product.Add((string)dataReader["VERSION"]);
                product.Add((string)dataReader["PRICE"]);
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

            // add auto number
            // let op de datetime
            string query = "INSERT INTO REVIEW VALUES ( '" + auto + "' , '" + accountid + "' , '" + productid + "' , '" + titel + "' , '" + content +
               "' , '" + 0 + "' , '" + DateTime.Today + "' , '" + 0 + ")";

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

        public void ToevoegenCommentaar(uint reviewid, uint accountid, string inhoudComm, string productid)
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
            string query = "INSERT INTO COMMENT VALUES ( '" + auto + "' , '" + accountid + "' , '" + reviewid + "' , '" + productid + "' , '" + null +
               "' , '" + inhoudComm + ")";

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