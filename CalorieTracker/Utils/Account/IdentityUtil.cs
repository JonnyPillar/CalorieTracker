using System;
using System.Security.Principal;

namespace CalorieTracker.Utils.Account
{
    public class IdentityUtil
    {
        /// <summary>
        ///     Get userID from Auth Cookie
        /// </summary>
        /// <param name="user">Context User</param>
        /// <returns>User ID or -1 if error</returns>
        public static int GetUserIDFromCookie(IPrincipal user)
        {
            if (!user.Identity.Name.Equals(string.Empty))
            {
                try
                {
                    return Convert.ToInt32(user.Identity.Name);
                }
                catch (Exception)
                {
                }
            }
            return -1;
        }
    }
}