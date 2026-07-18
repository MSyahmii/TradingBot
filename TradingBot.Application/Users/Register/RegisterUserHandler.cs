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

        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            var user = new User(request.Username, request.Email);

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
