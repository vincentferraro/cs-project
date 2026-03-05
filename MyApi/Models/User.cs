using System.ComponentModel.DataAnnotations;

namespace MyApi.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public User() { }

    public User(int id, string name, int age, string nickname)
    {
        Id = id;
        Name = name;
        Age = age;
        Nickname = nickname;
    }
}