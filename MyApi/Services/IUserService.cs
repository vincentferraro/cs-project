using MyApi.DTOs;
using MyApi.Models;

namespace MyApi.Services;
public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(int id);
    User CreateUser(CreateUserDto createUserDto);
    User? UpdateUser(int id, UpdateUserDto updateUserDto);
    bool DeleteUser(int id);
}

