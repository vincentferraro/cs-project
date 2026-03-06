using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.DTOs;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Tests;

public class UserServiceTests          // classe de tests
{

    private AppDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public void GetAllUsers_ReturnsAllUsers()
    {
        // Arrange
        var context = CreateInMemoryContext();
        context.Users.AddRange(
            new User { Name = "Alice", Age = 30, Nickname = "ali" },
            new User { Name = "Bob", Age = 25, Nickname = "bob" }
        );
        context.SaveChanges();

        var service = new UserService(context);

        // Act
        var result = service.GetAllUsers();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetUserById_ReturnsNull_WhenNotFound()
    {
        // Arrange
        var context = CreateInMemoryContext();
        var service = new UserService(context);

        // Act
        var result = service.GetUserById(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CreateUser_AddsUserToDatabase()
    {
        // Arrange
        var context = CreateInMemoryContext();
        var service = new UserService(context);
        var newUserDto = new CreateUserDto { Name = "Charlie", Age = 28, Nickname = "char" };
        
        // Act
        var result = service.CreateUser(newUserDto);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Charlie", result.Name);
        Assert.Equal(28, result.Age);
        
        }

}
