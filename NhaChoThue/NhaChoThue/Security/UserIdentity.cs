using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using NhaChoThue.Models.DBContext;

namespace NhaChoThue.Security
{
    public class UserIdentity : IIdentity
    {
        private string _UserName = "";
        private string _FullName= "";
        private bool _IsAuthenticated = false ;
        private string _Role = null;


        public UserIdentity() { }
        public UserIdentity(string username, string password) 
        {
            BDSDBContext db = new BDSDBContext();
            BDSUser user = (from s in db.Users
                           where username.Equals(s.Username, StringComparison.CurrentCultureIgnoreCase)
                           && password == s.Password
                           select s).SingleOrDefault();
            if (user != null)
            {
                _UserName = user.Username;
                _FullName = user.FullName;
                _IsAuthenticated = true;
                _Role = user.Role.RoleName;
            }
        }

        public UserIdentity(string username)
        {
            BDSDBContext db = new BDSDBContext();
            BDSUser user = (from s in db.Users
                            where username.Equals(s.Username, StringComparison.CurrentCultureIgnoreCase)
                            select s).SingleOrDefault();
            if (user != null)
            {
                _UserName = user.Username;
                _FullName = user.FullName;
                _IsAuthenticated = true;
                _Role = user.Role.RoleName;
            }
        }


        public string AuthenticationType
        {
            get { return "custom authentication"; }
        }

        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
        }

        public string Name
        {
            get { return _UserName; }
        }

        public string DisplayName
        {
            get { return _FullName; }
        }

        public string Role
        {
            get { return _Role; }
        }

    }
}