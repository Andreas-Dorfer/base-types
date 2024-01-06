using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Data.Infrastructure;
using TestApp.UserAggregate;

namespace TestApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<User>> Get() => await dbContext.Users.ToListAsync();

    [HttpPost]
    public async Task Create(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }
}
