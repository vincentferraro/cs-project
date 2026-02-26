using MyApi.DTOs;
using MyApi.Models;

namespace MyApi.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);

    }

    public User CreateUser(CreateUserDto user)
    {
        var newUser = new User(_nextId++, user.Name, user.Age, user.Nickname);
        _users.Add(newUser);
        return newUser;
    }

    public User? UpdateUser(int id, UpdateUserDto user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.Name = user.Name;
        existingUser.Age = user.Age;
        existingUser.Nickname = user.Nickname;

        return existingUser;
    }

    public bool DeleteUser(int id)
    {
        var userToRemove = _users.FirstOrDefault(u => u.Id ==id);
        if (userToRemove == null)
        {
            return false;
        }
        _users.Remove(userToRemove);
        return true;


    }
    
}