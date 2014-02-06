using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using CalorieTracker.Models;
using CTDataGenerator.Utils;

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

        /// <summary>
        /// Check Login Password Is Valid Against Expected Users Hash
        /// </summary>
        /// <param name="expectedUser">User In Question</param>
        /// <param name="enteredPassword">Inputted Password</param>
        /// <returns>Validity</returns>
        public static bool IsPasswordValid(User expectedUser, string enteredPassword)
        {
            PasswordHasher passwordHasher = new PasswordHasher(enteredPassword, expectedUser.PasswordSalt);
            if (expectedUser.PasswordHash.Equals(passwordHasher.PasswordHash)) return true;
            return false;
        }
    }
}