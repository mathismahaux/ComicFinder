using Microsoft.AspNetCore.Mvc;

namespace BdApi.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleError(Exception ex)
    {
        return StatusCode(500, new { message = ex.Message });
    }
}