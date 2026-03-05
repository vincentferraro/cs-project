using MyApi.DTOs;
using MyApi.Models;
using MyApi.Data;
namespace MyApi.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users;
    }

    public User? GetUserById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);

    }

    public User CreateUser(CreateUserDto user)
    {
        var newUser = new User { Name = user.Name, Age = user.Age, Nickname = user.Nickname };

        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser;
    }

    public User? UpdateUser(int id, UpdateUserDto user)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.Name = user.Name;
        existingUser.Age = user.Age;
        existingUser.Nickname = user.Nickname;

        _context.SaveChanges();
        return existingUser;
    }

    public bool DeleteUser(int id)
    {
        var userToRemove = _context.Users.FirstOrDefault(u => u.Id ==id);
        if (userToRemove == null)
        {
            return false;
        }
        _context.Users.Remove(userToRemove);
        _context.SaveChanges();
        return true;


    }
    
}