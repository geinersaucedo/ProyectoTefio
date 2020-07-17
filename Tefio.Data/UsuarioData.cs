using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Extensions.Configuration;
using System.IO;
using Dapper;
using System.Data;
using System.Linq;

using Tefio.Entity.Model;
using Tefio.Entity.Entity;
using Tefio.Core.Connection;

namespace Tefio.Data
{
    public class UsuarioData
    {
        private DbConecction db;
        public UsuarioData()
        {
            var _config = GetConfiguration();
            var connectionString = _config.GetSection("ConnectionStrings").GetSection("Bdtefio").Value;
            this.db = new DbConecction(connectionString);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public object GetUsuarioSistemaByID(Entity.Entity.Usuario usuario)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("Usuario", usuario.IdUsuario);
                p.Add("Clave", usuario.Clave);

                var x = this.db.Connection.Query<Entity.Model.Usuario>("usp_ValidarUsuario", p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return x;
            }
            catch (Exception ex)
            {
                return ex.Message;
                //throw;
            }
        }
    }
}