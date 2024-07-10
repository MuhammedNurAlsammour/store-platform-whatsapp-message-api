using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Features.Commands.Example.CreateExample;
using StorePlatform.Application.Features.Commands.Example.DeleteExample;
using StorePlatform.Application.Features.Commands.Example.UpdateExample;
using StorePlatform.Application.Features.Queries.Example.GetAllExamples;
using StorePlatform.Application.Features.Queries.Example.GetByIdExample;

namespace StorePlatform.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class ExamplesController(IMediator mediator) : ControllerBase
    {
		/// <summary>
		/// Tüm örnekleri getirir.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, tüm örneklerin listesini getirir.
		/// </remarks>
		/// <param name="request">Tüm örnekleri getirme parametrelerini içeren istek.</param>
		/// <returns>Örnekler listesini döndürür.</returns>
		/// <response code="200">Örnekler listesini döndürür.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpGet("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "GetAllExamples", Menu = "Examples")]
		public async Task<IActionResult> GetAllExamples([FromQuery] GetAllExamplesQueryRequest request)
		{
			var response = await mediator.Send(request);
			return Ok(response);
		}

		/// <summary>
		/// Belirtilen ID'ye sahip örneği getirir.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirli bir örneğin bilgilerini getirir.
		/// </remarks>
		/// <param name="request">Örnek kimliğini içeren istek.</param>
		/// <returns>Örnek bilgilerini döndürür.</returns>
		/// <response code="200">Örnek bilgilerini döndürür.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Örnek bulunamazsa.</response>
		[HttpGet("[action]/{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "GetByIdExample", Menu = "Examples")]
		public async Task<IActionResult> GetByIdExample([FromRoute] GetByIdExampleQueryRequest request)
		{
			var response = await mediator.Send(request);
			return Ok(response);
		}

		/// <summary>
		/// Yeni bir örnek oluşturur.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, yeni bir örnek ekler.
		/// </remarks>
		/// <param name="request">Yeni örnek bilgilerini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="201">Örnek başarıyla oluşturuldu.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpPost("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "CreateExample", Menu = "Examples")]
		public async Task<IActionResult> CreateExample([FromBody] CreateExampleCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode(response.StatusCode);
		}

		/// <summary>
		/// Mevcut bir örnek kaydını günceller.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirtilen ID'ye sahip örneğin bilgilerini günceller.
		/// </remarks>
		/// <param name="request">Güncellenecek örnek bilgilerini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="200">Örnek başarıyla güncellendi.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Güncellenecek örnek bulunamazsa.</response>
		[HttpPut("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "UpdateExample", Menu = "Examples")]
		public async Task<IActionResult> UpdateExample([FromBody] UpdateExampleCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode(response.StatusCode);
		}

		/// <summary>
		/// Belirtilen ID'ye sahip örneği siler.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirtilen ID'ye sahip örnek kaydını siler.
		/// </remarks>
		/// <param name="request">Silinecek örneğin kimliğini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="200">Örnek başarıyla silindi.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Silinecek örnek bulunamazsa.</response>
		[HttpDelete("[action]/{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "DeleteExample", Menu = "Examples")]
		public async Task<IActionResult> DeleteExample([FromRoute] DeleteExampleCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode(response.StatusCode);
		}

	}
}
