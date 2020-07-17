using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tefio.Entity.Entity;
using Tefio.Entity.Model;
using Tefio.Service;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Tefio.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [Route("api/v1/[controller]/lista")]
        [HttpPost]
        public object ListarProductosByIdCategoria(Producto producto)
        {
            ProductoService productoService = new ProductoService();
            return JsonConvert.SerializeObject(productoService.ListarProductosByIdCategoria(producto));
        }
        [Route("api/v1/[controller]/busca")]
        [HttpPost]
        public object BuscarProductosByIdCategoriayDescripcion(Producto producto)
        {
            ProductoService productoService = new ProductoService();
            return JsonConvert.SerializeObject(productoService.BuscarProductosByIdCategoriayDescripcion(producto));
        }
        
    }
}