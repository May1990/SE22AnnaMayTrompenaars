using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Xml.Serialization;


namespace individueleOpdracht
{
    public class Databasemanager
    {
        private static OracleConnection conn = new OracleConnection();
        static string pcn = "dbi296086";
        static string wachtwoord = "L79567vuYu";

        static private string dataSource = "";

        public string DataSource
        {

        }

        public Databasemanager()
        {
            conn = new Oracle
        }
    }
}