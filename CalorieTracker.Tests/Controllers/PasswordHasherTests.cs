using CalorieTracker.Utils.Account;
using CTDataGenerator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieTracker.Tests.Controllers
{
    [TestClass]
    public class PasswordHasherTests
    {
        [TestMethod]
        public void IsPasswordValid_UserPassword_Valid()
        {
            //Arrange
            string passwordString = "somePassw0rd@!";
            string userSalt = "HelloWOrld";
            string userHash = "CE73925550FE29A9DE2CE2648FCF94E79985EB73FE8D956CEAB41F4A91CF3382";
            //Assert
            bool validPassword = SecurityUtil.IsPasswordValid(passwordString, userSalt, userHash);
            //Act
            Assert.IsTrue(validPassword);
        }

        [TestMethod]
        public void IsPasswordValid_UserPassword_IsNotValid()
        {
            //Arrange
            string passwordString = "someDodgyPassword@!";
            string userSalt = "HelloWOrld";
            string userHash = "CE73925550FE29A9DE2CE2648FCF94E79985EB73FE8D956CEAB41F4A91CF3382";
            //Act
            bool validPassword = SecurityUtil.IsPasswordValid(passwordString, userSalt, userHash);
            //Assert
            Assert.IsFalse(validPassword);
        }

        [TestMethod]
        public void PasswordHasher_PasswordString_Valid()
        {
            //Arrange
            string passwordString = "password123";
            string passwordSalt = "cubexeve";
            string expectedHash = "7CE5925F5B10AF0E641C078E98731450F960B4FAE0D72A8A71A859CF26494052";
            //Act
            var passwordHasher = new PasswordHasher(passwordString, passwordSalt);
            //Assert
            Assert.AreEqual(passwordHasher.PasswordHash, expectedHash);
        }
    }
}