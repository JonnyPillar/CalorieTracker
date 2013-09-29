using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalorieTracker.Utilities
{
    public class Security
    {
        /// <summary>
        /// Is User Authenticated
        /// </summary>
        /// <param name="User">User</param>
        /// <returns>True or False</returns>
        public static bool Authentic(System.Security.Principal.IPrincipal User)
        {
            if (User.Identity.IsAuthenticated) return true;
            else return false;
        }
    }
}