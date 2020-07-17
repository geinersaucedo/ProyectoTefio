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
    public class CategoriaData
    {
        private DbConecction db;
        public CategoriaData()
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
        public object ListarCategoriasByIdBodega(String IdBodega)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("IdBodega", IdBodega);

                var x = db.Connection.Query<Categoria>("usp_ListarCategoriasByIdBodega", p, commandType: CommandType.StoredProcedure).ToList();

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
