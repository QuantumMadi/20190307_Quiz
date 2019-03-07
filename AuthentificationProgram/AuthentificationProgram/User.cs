using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace AuthentificationProgram
{
    [DataContract]
    public class User
    {
        //public int UserId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Phone { get; set; }
        public bool SuccessAuth = false;

        public User(string email, string password, string age, string city,string phone)
        {
            bool successAuth = true;
            if (!CheckEmail(email)) successAuth = false;
            else Email = email;
            if (!CheckPassword(password)) successAuth = false;
            else Password = password;
            if (!int.TryParse(age, out int resultAge)) successAuth = false;
            else Age = resultAge;
            if (!CheckPhone(phone)) successAuth = false;
            else Phone = phone;
            City = city;
            SuccessAuth = successAuth;
        }

        private bool CheckEmail(string email)
        {
            //Добавить проверку почты из файла
            if (!email.Contains(".") && !email.Contains("@")) return false;
            else return true;
        }

        private bool CheckPhone(string phone) {

            foreach (char c in phone)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;

        }
        
        private bool CheckPassword(string password)
        {
            if (password.Contains(" ")) return false;
            else return true;
        }
    }
}
