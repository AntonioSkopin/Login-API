using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LoginAPI.Interfaces
{
    public interface IBaseManager<T>
    {
        List<T> GetList(string sql, object param = null);
        bool ExecCmd(string sql, object param = null);
    }
}
