using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Shared.ApplicationDTOs;
using Business.Engines;

namespace Business.Managers
{
    public class LoginManager
    {
        public LoginUserDTO AuthenticateUser(LoginUserDTO user)
        {
            LoginRepository loginRepository = new LoginRepository();
            LoginUserDTO authenticatedUser = new LoginUserDTO();
            HashEngine createHash = new HashEngine();
            user.Password = createHash.GeneratePasswordHash(user.Password); 
            authenticatedUser = loginRepository.AuthenticateUser(user);
            return authenticatedUser;
        }
    }
}
