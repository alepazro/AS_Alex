using AS_CAPAS.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_CAPAS.Repositorio
{
    public class UserRepository
    {
        private Dictionary<string, User> userDatabase = new Dictionary<string, User>();


        public User getUserById(String id)
        {
            return userDatabase[id];
        }

        public void saveUser(User user)
        {
            userDatabase[user.id] = user;
        }

    }
}
