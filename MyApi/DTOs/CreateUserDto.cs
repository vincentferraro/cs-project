using System.ComponentModel.DataAnnotations;

namespace MyApi.DTOs;

public class CreateUserDto{
    
    [Required]
    public string Name;
    [Required]
    public int Age;    
    [Required]
    public string Nickname;
    };