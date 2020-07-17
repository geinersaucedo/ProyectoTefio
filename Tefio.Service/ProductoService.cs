using System;
using System.Collections.Generic;
using System.Text;

using Tefio.Data;
using Tefio.Entity.Entity;
using Tefio.Entity.Model;
using Tefio.Core.Utilitario;

namespace Tefio.Service
{
    public class ProductoService
    {
        public Result ListarProductosByIdCategoria(Producto producto)
        {
            ProductoData productoData = new ProductoData();
            var result = new Result();
            try
            {
                List<Producto> productos = new List<Producto>();
                productos = (List<Producto>)productoData.ListarProductosByIdCategoria(producto);
                if (productos.Count == 0)
                {
                    result.setError(ResultTable.RESULT_ERR_PRODUCTOS_SIN_PRODUCTOS_CODE);
                    result.Data = String.Empty;
                }
                result.Data = productos;
            }
            catch (Exception ex)
            {
                result.setError(ResultTable.RESULT_ERR_GENERIC_CODE,
                ResultTable.RESULT_ERR_GENERIC_MSG,
                ex.Message);
            }
            return result;
        }
        public Result BuscarProductosByIdCategoriayDescripcion(Producto producto)
        {
            ProductoData productoData = new ProductoData();
            var result = new Result();
            try
            {
                List<Producto> productos = new List<Producto>();
                productos = (List<Producto>)productoData.BuscarProductosByIdCategoriayDescripcion(producto);
                if (productos.Count == 0)
                {
                    result.setError(ResultTable.RESULT_ERR_PRODUCTOS_NO_ENCONTRADOS_CODE);
                    result.Data = String.Empty;
                }
                result.Data = productos;
            }
            catch (Exception ex)
            {
                result.setError(ResultTable.RESULT_ERR_GENERIC_CODE,
                ResultTable.RESULT_ERR_GENERIC_MSG,
                ex.Message);
            }
            return result;
        }
    }
}
