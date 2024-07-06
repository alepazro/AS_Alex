using AS_CAPAS.Modelo;
using AS_CAPAS.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_CAPAS.Controller
{
    public class UserController
    {
        private UserService userService;

        public UserController()
        {
            this.userService = new UserService();
        }

        public User getUserById(String id)
        {
            return userService.getUserById(id);
        }

        public void saveUser(User user)
        {
            userService.saveUser(user);
        }

    }
}
