﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SettlementAPI.Entities;
using SettlementAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public class AuthManager : IAuthManager
    {

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;
        

        public AuthManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager=userManager;
            _configuration=configuration;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
            
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            var userId = await _userManager.GetUserIdAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = jwtSettings.GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature);
        }

        public async Task<bool> ValidateUser(LoginUserDTO userDTO)
        {
            _user = await _userManager.FindByNameAsync(userDTO.Email);
            
            var validPassword = await _userManager.CheckPasswordAsync(_user, userDTO.Password);
            return(_user != null && validPassword);
        }
    }
}
