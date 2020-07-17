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
    public class categoriaController : ControllerBase
    {
        [Route("api/v1/[controller]/{IdBodega}/lista")]
        [HttpGet]
        public object ListarCategoriasByIdBodega(String IdBodega)
        {
            CategoriaService categoriaService = new CategoriaService();
            return JsonConvert.SerializeObject(categoriaService.ListarCategoriasByIdBodega(IdBodega));
        }
    }
}