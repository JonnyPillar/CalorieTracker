using System;
using System.Security.Cryptography;
using System.Text;

namespace CalorieTracker.Utilities
{
    public class PasswordHasher
    {
        private const int saltLength = 40;
        private string passwordHash;
        private string passwordSalt;

        /// <summary>
        /// Generate Hash For Password
        /// </summary>
        /// <param name="password"></param>
        public PasswordHasher(string password)
        {
            passwordSalt = Convert.ToBase64String(generateSalt());
            passwordHash = Convert.ToBase64String(generateHash(password, passwordSalt));
        }

        /// <summary>
        /// Generate A Hash
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="salt">Password Salt</param>
        /// <returns>Resulting Hash</returns>
        private static byte[] generateHash(string password, string salt)
        {
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            byte[] bytValue = Encoding.UTF8.GetBytes(password + salt);
            return hashAlg.ComputeHash(bytValue);
        }

        /// <summary>
        /// Generate A New Salt
        /// </summary>
        /// <returns>Resulting Salt</returns>
        private byte[] generateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltLength];
            rng.GetBytes(salt);
            return salt;
        }

        /// <summary>
        /// Is Login Password Valid
        /// </summary>
        /// <param name="passwordHash">Password Hash From DB</param>
        /// <param name="passwordSalt">Password Salt From DB</param>
        /// <param name="userAttempt">Password Entered By User</param>
        /// <returns></returns>
        public static bool IsPasswordValid(string passwordHash, string passwordSalt, string userAttempt)
        {
            //byte[] userCurrentHash = Encoding.UTF8.GetBytes(passwordHash);
            //byte[] userAttemptHash = generateHash(userAttempt, passwordSalt);
            string userAttemptHash = Convert.ToBase64String(generateHash(userAttempt, passwordSalt)); //TODO implement this so it compares it on a byte level
            return passwordHash.Equals(userAttemptHash); //TODO Test!!
        }

        /// <summary>
        /// Returns the Password Hash
        /// </summary>
        public string PasswordHash
        {
            get { return passwordHash; }
        }

        /// <summary>
        /// Returns the Password Salt
        /// </summary>
        public string PasswordSalt
        {
            get { return passwordSalt; }
        }
    }
}