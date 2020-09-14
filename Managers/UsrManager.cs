using Dapper;
using LoginAPI.Interfaces;
using LoginAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Managers
{
    public class UsrManager : BaseManager<User>, IUsrManager
    {
        public UsrManager(IConfiguration config) : base(config) { }

        bool IUsrManager.CheckLogin(User user)
        {
            using (db)
            {
                return db.ExecuteScalar<bool>(@"SELECT CASE WHEN EXISTS 
                (
                    SELECT *
                    FROM [usr]
                    WHERE username = @_username COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @_password COLLATE SQL_Latin1_General_CP1_CS_AS
                )
                THEN CAST(1 AS BIT)
                ELSE CAST(0 AS BIT) END",
                new { _username = user.username, _password = user.password });
            }
        }

        bool IUsrManager.NewUsr(User user)
        {
            return ExecCmd(@"INSERT INTO usr(gd, username, password) VALUES (@_gd,@_username,@_password)", new { _gd = Guid.NewGuid(), _username = user.username, _password = user.password });
        }
    }
}
