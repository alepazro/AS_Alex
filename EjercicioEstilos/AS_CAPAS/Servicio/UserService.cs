using AS_CAPAS.Modelo;
using AS_CAPAS.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_CAPAS.Servicio
{
    public class UserService
    {
        private UserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        public User getUserById(string id)
        {
            return userRepository.getUserById(id);
        }

        public void saveUser(User user)
        {
            userRepository.saveUser(user);
        }

    }
}
