using Dapper;
using LoginAPI.Interfaces;
using LoginAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Managers
{
    public class BaseManager<T> : IBaseManager<T>
    {
        private readonly IConfiguration _config;
        protected SqlConnection db 
        { 
            get
            {
                IConfigurationSection cs = _config.GetSection("ConnectionStrings");
                string s = cs["LoginAPI"];
                return new SqlConnection(s);
            }
        }

        public BaseManager(IConfiguration config)
        {
            _config = config;
        }

        public bool ExecCmd(string sql, object param = null)
        {
            using(db)
            {
                try
                {
                    return db.Execute(sql, param) > 0;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return false;
        }

        public List<T> GetList(string sql, object param = null)
        {
            using (db)
            {
                return db.Query<T>(sql, param).ToList();
            }
        }
    }
}
