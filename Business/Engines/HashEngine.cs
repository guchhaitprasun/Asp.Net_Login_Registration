using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engines
{
    public class HashEngine
    {
        public string GeneratePasswordHash(string password)
        {

            if (password != null)
            {

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
