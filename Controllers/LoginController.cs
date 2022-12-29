using Lib_API_Projeto_Integrador.Modelo;
using Lib_API_Projeto_Integrador.Repositorio;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_Projeto_Integrador.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        // POST: api/Login
        public IHttpActionResult Post([FromBody]Login login)
        {
            bool loginValido = false;

            // Verifica se o login veio preenchido é valido
            if (login != null)
            {
                ClienteRepo clienteRepo = new ClienteRepo();

                Cliente cliente = clienteRepo.ConsultarPorEmail(login.Usuario);

                if (clienteRepo != null)
                {
                    if (cliente.Senha == login.Senha)
                    {
                        loginValido = true;
                    }

                }
            }

            if (loginValido == true)
            {
                // Se o login for valido gera e retorna o token
                TokenGerado token = createToken(login.Usuario);

                return Ok(token);
            }
            else
            {
                // If usuario e senha invalidos, retorna n~~ao autorizado
                return Unauthorized();
            }
        }
        private TokenGerado createToken(string username)
        {
            //Data do Token
            DateTime issuedAt = DateTime.UtcNow;

            //Tempo de expiraçao em dias
            DateTime expires = DateTime.UtcNow.AddDays(1);

            var tokenHandler = new JwtSecurityTokenHandler();

            //cria a identidade do usuário que será concedido acesso
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username.ToUpper())
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            //cria o token propriamente dito
            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);

            TokenGerado tokenGerado = new TokenGerado
            {
                Username = username.ToUpper(),
                Expires = token.ValidTo,
                Token = tokenHandler.WriteToken(token)
            };

            return tokenGerado;
        }
    }
}
