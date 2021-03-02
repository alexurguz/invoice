using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Core.DTOs;
using Invoice.Core.Entities;
using Invoce.Api.Responses;
using Invoice.Core.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase _userUseCase;
        private readonly IMapper _mapper;

        public UserController(IUserUseCase userRepository, IMapper mapper)
        {
            _userUseCase = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userUseCase.GetUsers();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            var response = new ApiResponse<IEnumerable<UserDto>>(usersDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var users = await _userUseCase.GetUserById(id);
            var userDto = _mapper.Map<UserDto>(users);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userUseCase.InsertUser(user);
            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userUseCase.UpdateUser(user);
            var response = new ApiResponse<User>(user);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userUseCase.DeleteUser(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
