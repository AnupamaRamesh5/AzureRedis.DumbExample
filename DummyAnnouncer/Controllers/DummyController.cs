using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace DummyAnnouncer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public DummyController(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
        }

        public async Task<IActionResult> Index()
        {
            var database = _redisConnection.GetDatabase();
            var instanceOneData = await database.StringGetAsync("I1");
            var instanceTwoData = await database.StringGetAsync("I2");

            return new JsonResult(new[] { (string)instanceOneData, (string)instanceTwoData });
        }
    }
}
