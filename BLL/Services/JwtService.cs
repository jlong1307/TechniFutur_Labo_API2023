using BLL.Interfaces;
using DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JwtService : IJwtService
    {
        private readonly string SecretKey;
        private readonly string ExpiresDays;

        /// <summary>
        /// Initializes a new instance of the JwtService class.
        /// </summary>
        /// <param name="secretKey">The secret key used for JWT token generation.</param>
        /// <param name="expiresDays">The number of days for which the JWT token will be valid.</param>
        public JwtService(string secretKey, string expiresDays)
        {
            SecretKey = secretKey;
            ExpiresDays = expiresDays;
        }

        /// <summary>
        /// Creates a JWT token for the given user.
        /// </summary>
        /// <param name="user">The user for whom the token is created.</param>
        /// <returns>A string representing the generated JWT token.</returns>
        public string CreateToken(User user)
        {
            // Create a symmetric security key based on the provided secret key.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            // Create signing credentials using the security key and HMACSHA256 algorithm.
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create a list of claims for the JWT token, including the user's identifier.
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));

            // Create a new JWT token with the specified claims, expiration date, and signing credentials.
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(Convert.ToUInt32(ExpiresDays)), signingCredentials: credentials);

            // Write the JWT token as a string and return it.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
