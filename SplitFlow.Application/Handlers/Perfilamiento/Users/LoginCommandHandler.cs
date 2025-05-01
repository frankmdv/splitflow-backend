using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SplitFlow.Application.Commands.Perfilamiento.UsersCommands;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Perfilamiento.Users
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IMongoCollection<UserReadModel> _userCollection;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IMongoDatabase database, IConfiguration configuration)
        {
            // Obtiene la colección "Users" de MongoDB
            _userCollection = database.GetCollection<UserReadModel>("Users");
            _configuration = configuration;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Consulta todos los usuarios desde MongoDB
            var allUsers = await _userCollection.Find(_ => true).ToListAsync(cancellationToken);

            // Filtra con LINQ para encontrar el usuario por email
            var user = allUsers.FirstOrDefault(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new Exception("Credenciales inválidas");
            }

            // Crear claims para el token JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Role", user.Role.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Leer la configuración de JWT
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = _configuration["JwtSettings:Secret"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            int expiryMinutes = 0;
            int.TryParse(_configuration["JwtSettings:ExpiryMinutes"], out expiryMinutes);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Generar el token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiryMinutes),
                signingCredentials: creds
            );

            return new LoginResult
            {
                IdUser = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
