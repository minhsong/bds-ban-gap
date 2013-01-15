using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using BDSBanGap.Controllers;

namespace BDSBanGap.Security
{
    public class UserPrincipal: IPrincipal
    {
        private UserIdentity _Identity;

        public System.Security.Principal.IIdentity Identity
        {
            get { return _Identity; }
        }


        public UserPrincipal(string username, string password)
        {
            _Identity = new UserIdentity(username, password);
        }

        public UserPrincipal(string username)
        {
            _Identity = new UserIdentity(username);
        }


 
        public bool IsInRole(string role)
        {
            if (_Identity.Role != null)
            {
                if (_Identity.Role.Equals(role, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

    }
}