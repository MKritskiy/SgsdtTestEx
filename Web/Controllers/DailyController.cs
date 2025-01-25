using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DailyController : ControllerBase
{
    private readonly IDailyService _dailyService;

    public DailyController(IDailyService dailyService)
    {
        _dailyService = dailyService;
    }

    [HttpGet("currencies")]
    public async Task<IActionResult> GetValutes([FromQuery] int page, [FromQuery] int countInPage = 5)
    {
        try
        {
            var valuteDto = await _dailyService.GetValutesAsync(page, countInPage);
            return Ok(valuteDto.Valute);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ошибка при получении данных о всех валютах: "+ ex.Message);
        }
    }
    [HttpGet("currency/{valuteDataId}")]
    public async Task<IActionResult> GetValuteData(string valuteDataId)
    {
        try
        {
            var valuteData = await _dailyService.GetValuteDataAsync(valuteDataId);
            return Ok(valuteData);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ошибка при получении данных о валюте: " + ex.Message);
        }
    }
}
