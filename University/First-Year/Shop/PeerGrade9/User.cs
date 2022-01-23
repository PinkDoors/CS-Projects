using System;
using System.Security.Cryptography;
using System.Text;

namespace PeerGrade9
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Code { get; set; }

        public User(string login,string password,int code)
        {
            Login = login;
            Password = password;
            Code = code;
        }

        /// <summary>
        /// Creates and encodes the password.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        public static Tuple<string,int> CreatePassword(string oldPassword)
        {
            Random rnd = new Random();
            int code = rnd.Next();
            string password = oldPassword + code.ToString();
            // I am using SHA256 to encode the password.
            var bytes = Encoding.ASCII.GetBytes(password);
            var sha = new SHA256Managed();
            var newpasswordInBytes = sha.ComputeHash(bytes);
            string newPassword = BitConverter.ToString(newpasswordInBytes);
            return new Tuple<string, int>(newPassword,code);
        }

        /// <summary>
        /// Encodes the input data.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetPassword(string input)
        {
            string password = input + Code.ToString();
            var bytes = Encoding.ASCII.GetBytes(password);
            var sha = new SHA256Managed();
            var newpasswordInBytes = sha.ComputeHash(bytes);
            string newPassword = BitConverter.ToString(newpasswordInBytes);
            return newPassword;
        }
    }
}
