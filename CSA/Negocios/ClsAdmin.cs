using CSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.Negocios
{
    public class ClsAdmin
    {
        public bool Autenticacion(User user)
        {
            if (user.user.Equals("") && user.password.Equals(""))
            {
                return true;
            }
            return false;
        }
    }
}
