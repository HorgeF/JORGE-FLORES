using Datos;
using Entidad;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class LoginNegocio
    {

        public static ResponseLogin Login(RequestLogin request) 
        {
        

            ResponseLogin result = new ResponseLogin();

            try {

                result = LoginDAO.Login(request); 
                result.Token = GenerarToken(result.cod_trabajador);

            }
            catch (Exception e)
            {
            
            }

            return result;

        }

        private static string GenerarToken(string username)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi ClaveSuperSecreta XYZ XDDDDDDDDDDDDD"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "XYZ",
                audience: "USERS",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        static string GenerarClaveAleatoria(int longitud)
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[longitud];
                rng.GetBytes(bytes);

                StringBuilder stringBuilder = new StringBuilder(longitud);
                foreach (byte b in bytes)
                {
                    stringBuilder.Append(caracteresPermitidos[b % caracteresPermitidos.Length]);
                }

                return stringBuilder.ToString();
            }
        }
    }



}

