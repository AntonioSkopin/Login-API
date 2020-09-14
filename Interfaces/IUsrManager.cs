using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Interfaces
{
    public interface IUsrManager
    {
        bool NewUsr(User user);
        bool CheckLogin(User user);
    }
}
