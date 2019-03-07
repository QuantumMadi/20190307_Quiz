using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AuthentificationProgram
{

    public class UserAutorizAuthen
    {
        private List<User>existUsers;

        public UserAutorizAuthen()
        {
            existUsers = new List<User>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));
            if (File.Exists("./data.json"))
            {
                using (FileStream fs = new FileStream("data.json", FileMode.Open))
                {
                    existUsers = (List<User>)jsonFormatter.ReadObject(fs);
                }

            }
        }
        public bool UserAuthorization(string email, string password)
        {
            foreach(User us in existUsers)
            {
                if (us.Email == email && us.Password == password) { return true; }
            }
            return false;
        }

        public bool UserAuthentification(User user)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));
            if(existUsers.Capacity!=0)
            foreach (User us in existUsers)
            {
                if (us.Email == user.Email) return false;
            }

            existUsers.Add(user);
            using (FileStream fstream = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fstream, existUsers);
            }
            return true;
        }
    }

}
