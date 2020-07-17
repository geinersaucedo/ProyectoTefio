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
    public class ProductoData
    {
        private DbConecction db;
        public ProductoData()
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
        public object ListarProductosByIdCategoria(Producto producto)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("IdBodega", producto.IdBodega);
                p.Add("IdCategoria", producto.IdCategoria);

                var x = db.Connection.Query<Producto>("usp_ListarProductosByIdCategoria", p, commandType: CommandType.StoredProcedure).ToList();

                return x;
            }
            catch (Exception ex)
            {
                return ex.Message;
                //throw;
            }
        }
        public object BuscarProductosByIdCategoriayDescripcion(Producto producto)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("IdBodega", producto.IdBodega);
                p.Add("IdCategoria", producto.IdCategoria);
                p.Add("Descripcion", producto.NombreProducto);//buscará en el campo nombre y descripcion del producto

                var x = db.Connection.Query<Producto>("usp_BuscarProductosByIdCategoriayDescripcion", p, commandType: CommandType.StoredProcedure).ToList();

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
