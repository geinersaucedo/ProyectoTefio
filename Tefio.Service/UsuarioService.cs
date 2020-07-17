using System;
using System.Collections.Generic;
using System.Text;

using Tefio.Data;
using Tefio.Entity.Entity;
using Tefio.Entity.Model;
using Tefio.Core.Utilitario;
using Tefio.Core.Constant;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Tefio.Service
{
    public class UsuarioService
    {
        private readonly IConfiguration _config;
        public UsuarioService(IConfiguration config)
        {
            _config = config;
        }
        public Result ValidarLogin(Entity.Entity.Usuario usuario)
        {
            Result result = new Result();

            try
            {
                UsuarioData usuarioData = new UsuarioData();
                Entity.Model.Usuario usuarioModel = new Entity.Model.Usuario();
                usuarioModel = (Entity.Model.Usuario)usuarioData.GetUsuarioSistemaByID(usuario);
                if (usuarioModel != null)
                {
                    if (!usuarioModel.Estado)
                    {
                        result.setError(ResultTable.RESULT_ERR_LOGIN_INCORRECT_USER_CODE);
                        result.Data = String.Empty;
                    }
                    else
                    {
                        var tokenStr = GenerateJSONWebToken(usuarioModel);
                        usuarioModel.Token = tokenStr;
                        result.Data = usuarioModel;
                    }
                }
                else
                {
                    result.setError(ResultTable.RESULT_ERR_IDNOTFOUND_CODE);
                    result.Data = String.Empty;
                }
            }
            catch (Exception ex)
            {
                result.setError(ResultTable.RESULT_ERR_GENERIC_CODE,
                                ResultTable.RESULT_ERR_GENERIC_MSG,
                                ex.Message);
                result.Data = String.Empty;
            }
            return result;
        }

        private string GenerateJSONWebToken(Entity.Model.Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.UtcNow.AddMinutes(ConstantesNegocio.Login.TiempoDeLogueo)).ToUnixTimeSeconds().ToString()),
                new Claim("IdUsuario", usuario.IdUsuario),
                new Claim("IdPersona", usuario.IdPersona),
                new Claim("Nombre", usuario.Nombre),
                new Claim("Apellidos", usuario.Apellidos),
                new Claim("Telefono", usuario.Telefono),
                new Claim("Estado", usuario.Estado.ToString()),
                new Claim("TipoUsuario", usuario.TipoUsuario),
            };
            var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
