using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class AdresClass
    {
        private string straat;
        private string huisnummer;
        private string plaats;

        public AdresClass(string straat, string huisnummer, string plaats)
        {
            this.Straat = straat;
            this.Huisnummer = huisnummer;
            this.Plaats = plaats;
        }
        public string Plaats
        {
            get { return plaats; }
            set { plaats = value; }
        }
        

        public string Huisnummer
        {
            get { return huisnummer; }
            set { huisnummer = value; }
        }
        

        public string Straat
        {
            get { return straat; }
            set { straat = value; }
        }
        
    }
}