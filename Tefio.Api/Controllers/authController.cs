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
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
            //this.usuarioSistemaService = new UsuarioSistemaService(_config);
        }
        [Route("api/v1/[controller]/login")]
        [HttpPost]
        public object GetLogin(Entity.Entity.Usuario usuario)
        {
            UsuarioService usuarioService = new UsuarioService(_config);
            return JsonConvert.SerializeObject(usuarioService.ValidarLogin(usuario));
        }
    }
}