using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.API.Dtos;
using User.API.IRepository;
using User.API.Models;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChoiceController : ControllerBase
    {
        private readonly IUserChoiceRepository _userChoiceRepository;
        private readonly IMapper _mapper;

        public UserChoiceController(IUserChoiceRepository userChoiceRepository, IMapper mapper)
        {
            _userChoiceRepository = userChoiceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserChoices(int userId)
        {
            var userChoice = await _userChoiceRepository.GetUserChoiceByUserId(userId);
            return Ok(_mapper.Map<List<UserChoiceDto>>(userChoice));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserChoice(List<AddUserChoiceDto> addUserChoices)
        {
            var mapUserChoice = _mapper.Map<List<UserChoice>>(addUserChoices);

            var userChoice = await _userChoiceRepository.AddUserChoice(mapUserChoice);
            return userChoice > 0 ? Ok("User choices added successfully.") : BadRequest("Enable to add user choices.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserChoices(List<UpdateUserChoicesDto> updateUserChoices)
        {
            var mapUserChoices = _mapper.Map<List<UserChoice>>(updateUserChoices);

            var updatedUserChoices = await _userChoiceRepository.UpdateUserChoice(mapUserChoices);
            return updatedUserChoices > 0 ? Ok("User choices updted successfully.") : BadRequest("Unable to update user choices");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserChoices(int id)
        {
            var deletedUserChoice = await _userChoiceRepository.DeleteUserChoice(id);
            return deletedUserChoice > 0 ? Ok("User choice deleted successfully.") : BadRequest("Unable to delete user choice.");
        }
    }
}
