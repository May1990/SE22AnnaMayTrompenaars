using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individueleOpdracht
{
    public class CommentaarClass
    {
        private string inhoudComm;
        private AccountClass account;

        public CommentaarClass(string inhoudComm, AccountClass account)
        {
            this.InhoudComm = inhoudComm;
            this.Account = account;
        }

        public AccountClass Account
        {
            get { return account; }
            set { account = value; }
        }
        

        public string InhoudComm
        {
            get { return inhoudComm; }
            set { inhoudComm = value; }
        }
        
    }
}