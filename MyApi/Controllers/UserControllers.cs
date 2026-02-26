using Microsoft.AspNetCore.Mvc;
using MyApi.DTOs;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(CreateUserDto createUserDto)
    {
        var user = _userService.CreateUser(createUserDto);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = _userService.UpdateUser(id, updateUserDto);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var deleted = _userService.DeleteUser(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
