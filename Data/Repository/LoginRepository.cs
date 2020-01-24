using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Data.DatabaseEntity;
using Shared.ApplicationDTOs;

namespace Data.Repository
{
    public class LoginRepository
    {
        LoginRegisterMVCDbEntities _dbEntity = new LoginRegisterMVCDbEntities();
        public LoginUserDTO AuthenticateUser(LoginUserDTO user)
        {
            ApplicationUser responce = new ApplicationUser();
            LoginUserDTO returnResponce = new LoginUserDTO();
            if(user.UserName != null && user.Password != null)
            {
                try
                {
                    responce = _dbEntity.ApplicationUsers.Where(o => o.EmailAddress == user.UserName && o.PasswordHash == user.Password).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            returnResponce.userId = responce.Id;
            returnResponce.UserName = responce.EmailAddress;
            //returnResponce.Password = responce.PasswordHash;

            return returnResponce;
        }


    }
}
