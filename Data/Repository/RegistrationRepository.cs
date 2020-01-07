using Data.DatabaseEntity;
using Shared.ApplicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RegistrationRepository
    {
        public bool RegisterUser(AppUserDTO appUser)
        {
            LoginRegisterMVCDbEntities _dbContext = new LoginRegisterMVCDbEntities();
            if (appUser != null && appUser.EmailAddress != null && appUser.Password != null)
            {


                try
                {
                    ApplicationUser tempUser = new ApplicationUser();

                    // Converting AppUserDTO object to ApplicationUser object 
                    tempUser.FirstName = appUser.FirstName;
                    tempUser.LastName = appUser.LastName;
                    tempUser.EmailAddress = appUser.EmailAddress;
                    tempUser.ProfilePicture = appUser.ProfilePicture;
                    tempUser.PasswordHash = appUser.Password;
                    tempUser.IsActive = true;
                    tempUser.UserName = appUser.UserName;

                    // inser new entry to the database
                    _dbContext.ApplicationUsers.Add(tempUser);
                    _dbContext.SaveChanges();

                    return true;
                }
                catch (Exception E)
                {
                    throw;
                }

            }
            return false;
        }
    }
}
