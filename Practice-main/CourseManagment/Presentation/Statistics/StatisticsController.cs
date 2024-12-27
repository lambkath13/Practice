using Microsoft.AspNetCore.Mvc;
using Service;

namespace Presentation.Statistics;

[Route("api/statistics")]
[ApiController]
public class StatisticsController(IServiceManager service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetStatistics()
    {
        var statistics = service.StatisticsService.GetStatistics(trackChanges: false);
        return Ok(statistics);
    }
}
