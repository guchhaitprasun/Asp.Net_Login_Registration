using Data.Repository;
using Shared.ApplicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Business
{
    public class RegistrationManager
    {
        public bool RegisterUser(AppUserDTO appUser, byte[] profileImage)
        {
            RegistrationRepository registrationRepository = new RegistrationRepository();

            //Convert the profile image byte array to base 64 string 
            string profileInBase64String = Convert.ToBase64String(profileImage, 0, profileImage.Length);

            //Insert base 64 image string to appUser DTO
            appUser.ProfilePicture = profileInBase64String;

            //Generate user name for the user
            appUser.UserName = GenerateUserName(appUser.EmailAddress);

            //convert the password to password hash
            appUser.Password = GeneratePasswordHash(appUser.Password);

            return registrationRepository.RegisterUser(appUser);
        }

        private string GenerateUserName(string emailId) {

            string userName = null;

            // Split the email address from @ and use first part as user name
            if (emailId != null)
            {
                userName = emailId.Split('@')[0];
            }
            return userName;
        }

        private string GeneratePasswordHash(string password)
        {

            if (password != null) {

                // Create a SHA256
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array 
                    byte[] passwordBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    // Convert byte array to string
                    StringBuilder passwordHashBuilder = new StringBuilder();
                    for (int index = 0; index < passwordBytes.Length; index++)
                    {
                        passwordHashBuilder.Append(passwordBytes[index].ToString("x2"));
                    }
                    return passwordHashBuilder.ToString();
                }
            }

            return null;
        }
    }
}
