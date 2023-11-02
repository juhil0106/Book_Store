using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.API.Dtos;
using User.API.Models;
using User.API.Repository;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserDetailsController(IUserDetailsRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserDetails()
        {
            var users = await _userRepository.GetAllUser();
            return Ok(_mapper.Map<List<UserDetailsDto>>(users));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserDetails(AddUserDto userDto)
        {
            var mapUser = _mapper.Map<UserDetails>(userDto);

            var allowedCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var randomPassword = "";

            for (var i = 0; i < 7; i++)
            {
                var temp = allowedCharacter[random.Next(0, allowedCharacter.Length)];
                randomPassword += temp;
            }

            mapUser.Password = randomPassword;
            mapUser.CreatedOn = DateTime.Now.Date;

            var user = await _userRepository.AddUserDetails(mapUser);

            return user > 0 ? Ok($"User added successfully. your password is \"{randomPassword}\" and if you want you can change it.") : BadRequest("Unable to add user.");
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> LoginUser(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);

            if (user.Password.ToLower() != loginDto.Password.ToLower())
                return BadRequest("Password is wrong");

            return user is not null ? Ok(user) : BadRequest("You've to register first for logged In.");
        }

        [HttpPut, Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(string email, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user is null)
                return BadRequest("No User with this email.");

            if (user.Password != oldPassword)
                return BadRequest("Your current password is not true.");

            user.Password = newPassword;
            var updateUser = await _userRepository.UpdateUserDetails(user);
            return updateUser > 0 ? Ok("Password updated successfully.") : BadRequest("Unable to update password");
        }
    }
}