using Microsoft.AspNetCore.Mvc;

namespace LowResourceServers.Controllers;

[ApiController]
[Route("[controller]")]
public class WallPostController : ControllerBase
{
    private readonly ILogger<WallPostController> _logger;

    public WallPostController(ILogger<WallPostController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetMyPosts")]
    public IEnumerable<WallPost> GetMyPosts()
    {
        //Make slow
        var oneSecondInMillis = 3000;
        Thread.Sleep(oneSecondInMillis);
        return Enumerable.Range(1, 5).Select(index => new WallPost
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            PostText = "I am posting",
            UserId = "user1"
        })
        .ToArray();
    }

    [HttpPost("PostNewWallPost")]
    public void PostNewWallPost(WallPost wallPost)
    {
        //Make slow
        var oneSecondInMillis = 3000;
        Thread.Sleep(oneSecondInMillis);

    }
}
