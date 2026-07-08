using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingBot.Application.Common.Interfaces;

namespace TradingBot.Application.Users.Register
{
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task HandleAsync(RegisterUserRequest request)
        {

        }
    }
}
