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
	public class AuthorizationEndpointsController(IAuthorizationEndpointService authorizationEndpointService) : ControllerBase
	{
		[HttpPost("[action]")]
		[Authorize(AuthenticationSchemes = "Admin")]
		[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Assign Role Endpoint", Menu = "AuthorizationEndpoints")]
		public async Task<IActionResult> AssignRoleEndpoint(AssignEndpointsToRoleDTO request)
		{
			return Ok(await authorizationEndpointService.AssignEndpointsToRoleAsync(request, typeof(Program)));
		}
	}
}
