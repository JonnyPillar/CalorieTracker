using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CalorieTracker.Utils.Account
{
    public class SecurityUtil
    {
        /// <summary>
        /// Is User Authenticated
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>True or False</returns>
        public static bool AuthenticUser(IPrincipal user)
        {
            if (user.Identity.IsAuthenticated) return true;
            return false;
        }
    }
}