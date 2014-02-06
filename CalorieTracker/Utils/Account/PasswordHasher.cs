using System;
using System.Security.Cryptography;
using System.Text;

namespace CTDataGenerator.Utils
{
    public class PasswordHasher
    {
        private const int saltLength = 32;
        private string passwordHash;
        private string passwordSalt;

        /// <summary>
        /// Generate Hash and Salt For Password
        /// </summary>
        /// <param name="password">Password String</param>
        public PasswordHasher(string password)
        {
            passwordSalt = ByteArrayToHexString(generateSalt());
            passwordHash = ByteArrayToHexString(generateHash(password, passwordSalt));
        }

        /// <summary>
        /// Generate Hash with Pre generated salt for password
        /// </summary>
        /// <param name="password">Password String</param>
        /// <param name="inputPasswordSalt">Password Salt</param>
        public PasswordHasher(string password, string inputPasswordSalt)
        {
            passwordSalt = inputPasswordSalt;
            passwordHash = ByteArrayToHexString(generateHash(password, passwordSalt));
        }

        /// <summary>
        /// Generate A Hash
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="salt">Password Salt</param>
        /// <returns>Resulting Hash</returns>
        private static byte[] generateHash(string password, string salt)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256Hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256Hasher.ComputeHash(encoder.GetBytes(password + salt));
            return hashedDataBytes;
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
        /// Converty Byte Array to Hex String
        /// </summary>
        /// <param name="ba">Byte Array</param>
        /// <returns>Hexadecimal String</returns>
        private string ByteArrayToHexString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
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
