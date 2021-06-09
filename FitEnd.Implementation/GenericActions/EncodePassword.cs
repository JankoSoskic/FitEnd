using FitEnd.Application.GenericActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Implementation.GenericActions
{
    public class EncodePassword : IEncodePassword
    {
        public string EnkodujPassword(string pass)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(pass);
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
