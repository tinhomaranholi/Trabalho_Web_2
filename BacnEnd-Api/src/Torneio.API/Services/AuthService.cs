using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torneio.API.Exceptions;
using Torneio.API.Interfaces;
using Torneio.API.Interfaces.Services;
using Torneio.API.Models.Dtos;
using Torneio.API.Models.Entities;

namespace Torneio.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            if (await UserExists(loginRequest.Email))
            {
                var user = await usuarioRepository.FindByEmail(loginRequest.Email);
                user.SenhasIguais(loginRequest.Senha);
                return GerarToken(user);
            }

            throw new UsuarioInvalidoException();
        }

        public LoginResponse GerarToken(Usuario usuario, int length = 32)
        {
            var random = new Random();

            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var token = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                token.Append(characters[random.Next(characters.Length)]);
            }
            var result = new LoginResponse { Token = token.ToString() };

            return result;
        }

        public async Task<bool> UserExists(string email) => await usuarioRepository.UserExists(email);

    }
}
