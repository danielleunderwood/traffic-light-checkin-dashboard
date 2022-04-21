using Core;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Api.Controllers;

[ApiController]
[Route("")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(
        UserRepository checkinRepository)
    {
        _userRepository = checkinRepository;
    }

    [HttpGet(Name = "GetUsers")]
    [Route("/user")]
    public async Task<User?> GetUser([FromQuery] string id)
    {
        return await _userRepository.GetUser(id);
    }

    [HttpGet(Name = "GetUsers")]
    [Route("/users")]
    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetUsers();
    }
}
