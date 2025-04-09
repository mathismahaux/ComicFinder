using Microsoft.AspNetCore.Mvc;

namespace BdApi.Controllers;

public abstract class BaseController : ControllerBase
{
    protected abstract IActionResult HandleError(Exception ex);
}