using Microsoft.AspNetCore.Mvc;
using BookStore.Application.Services;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/promotion")]
public class PromotionController : ControllerBase
{
    private readonly PromotionAppService _service;

    public PromotionController(PromotionAppService service)
    {
        _service = service;
    }

    [HttpPost("check")]
    public IActionResult Check()
    {
        var result = _service.CheckPromotion();
        return Ok(result);
    }
}