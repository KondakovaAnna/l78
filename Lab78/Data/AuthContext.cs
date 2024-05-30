using System.Web.Mvc;
using Lab78.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab78.Data;

public class AuthContext : DbContext
{
    // тестовые данные вместо использования базы данных
    public List<User> users = new List<User>
    {
        new User {Login="admin", Password="12345", Role = "admin" },
        new User {Login="user1", Password="55555", Role = "user" }
    };
    
    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }
}