using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.DTOs;
using Karmed.External.Auth.Library.Enums;
using Karmed.External.Auth.Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StorePlatform.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationServicesController(IApplicationService applicationService) : ControllerBase
	{

		[HttpGet("[action]")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[ProducesResponseType<List<Menu>>(StatusCodes.Status200OK)]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Authorize Definition Endpoints", Menu = "Application Services")]
		public IActionResult GetAuthorizeDefinitionEndpoints()
		{
			return Ok(applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program)));
		}
	}
}

