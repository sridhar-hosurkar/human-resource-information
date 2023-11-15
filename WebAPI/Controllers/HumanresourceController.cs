using Microsoft.AspNetCore.Mvc;
using ServiceModels;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/HR/v1")]
public class HumanresourceController : ControllerBase
{
    private Services.ServiceProvider _serviceProvider;

    public HumanresourceController(Services.ServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpGet]
    [Route("Users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _serviceProvider.GetUsers();
    }

    [HttpGet]
    [Route("User/{id}")]
    public async Task<ActionResult<UserInfo>> GetUser(int id)
    {
        return await _serviceProvider.GetUser(id);
    }

    [HttpDelete]
    [Route("User/{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        return await _serviceProvider.DeleteUser(id);
    }

    [HttpPost]
    [Route("User")]
    public async Task<ActionResult<bool>> Save(UserInfo userInfo)
    {
        return await _serviceProvider.CreateUser(userInfo);
    }
}
