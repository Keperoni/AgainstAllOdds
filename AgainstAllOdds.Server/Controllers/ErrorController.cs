using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AgaintsAllOdds.Server.Controllers
{
	[ApiController]
	public class ErrorController : ControllerBase
	{
		[Route("/error")]
		public IActionResult HandleError()
		{
			var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

			return StatusCode(500, new
			{
				message = "An unexpected error occurred",
				detail = exception?.Message
			});
		}
	}
}