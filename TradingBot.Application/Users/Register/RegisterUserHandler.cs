using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingBot.Application.Common.Interfaces;
using TradingBot.Domain.Entities;

namespace TradingBot.Application.Users.Register
{
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<RegisterUserResponse> HandleAsync(RegisterUserRequest request)
        {
            var existingUsername = await _userRepository.GetByUsernameAsync(request.Username);
            var existingEmail = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUsername != null)
            {
                throw new Exception("Username already exists.");
            }
            if (existingEmail != null)
            {
                throw new Exception("Email already exists.");
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                throw new Exception("Password is required.");
            }

            var hashedPassword = _passwordHasher.Hash(request.Password);

            var user = new User(request.Username, request.Email, hashedPassword);

            await _userRepository.AddAsync(user);

            return new RegisterUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}
