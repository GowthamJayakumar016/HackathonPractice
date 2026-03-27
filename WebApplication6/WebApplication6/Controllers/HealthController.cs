using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HealthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var healthStatus = new
            {
                Application = "My API",
                Status = "Healthy",
                Database = await CheckDatabaseAsync(),
                Timestamp = DateTime.UtcNow
            };

            if (healthStatus.Database == "Unhealthy")
                return StatusCode(503, healthStatus); // ServiceUnavailable

            return Ok(healthStatus);
        }

        private async Task<string> CheckDatabaseAsync()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return "Healthy";
            }
            catch
            {
                return "Unhealthy";
            }
        }
    }
}

