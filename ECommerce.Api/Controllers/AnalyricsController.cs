using ECommerce.Api.DTOs;
using ECommerce.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly AnalyticsService _analyticsService;

    public AnalyticsController(AnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    [HttpGet("top-selling-product")]
    public async Task<ActionResult<TopProductDto>> GetTopSellingProduct()
    {
        var result = await _analyticsService.GetTopSellingProductAsync();

        if (result == null)
        {
            return NotFound("Data cannot be found.");
        }

        return Ok(result);
    }
}