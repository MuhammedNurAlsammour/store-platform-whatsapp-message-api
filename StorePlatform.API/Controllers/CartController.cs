using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Dtos.ResponseDtos.Categorie;
using StorePlatform.Application.Dtos.ResponseDtos.Employee;
using StorePlatform.Application.Features.Commands.Cart.CreateCart;
using StorePlatform.Application.Features.Commands.Cart.DeleteCart;
using StorePlatform.Application.Features.Commands.Employee.CreateEmployee;
using StorePlatform.Application.Features.Commands.Employee.DeleteEmployee;
using StorePlatform.Application.Features.Commands.Employee.UpdateEmployee;
using StorePlatform.Application.Features.Queries.Cart.GetAllCart;
using StorePlatform.Application.Features.Queries.Cart.GetByIdCart;
using StorePlatform.Application.Features.Queries.Categorie.GetAllCategories;
using StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee;
using System.Net;

namespace StorePlatform.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class CartController(IMediator mediator) : ControllerBase
	{
		/// <summary>
		/// Tüm Cartları getirir.
		/// </summary>
		/// <remarks>
		/// Bu endpoint, sayfa ve boyut parametrelerine göre tüm Cartları getirir.
		/// </remarks>
		/// <param name="request">Sayfa ve boyut parametrelerini içeren istek nesnesi.</param>
		/// <returns>Cartların listesi ve işlem sonucu.</returns>
		/// <response code="200">Başarılı istek.</response>
		/// <response code="400">Geçersiz istek.</response>
		/// <response code="401">Yetkisiz erişim.</response>
		[HttpGet("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Tüm Cartleri Getir", Menu = "Kart")]
		public async Task<ActionResult<TransactionResultPack<GetAllCartQueryResponse>>> GetAllCart([FromQuery] GetAllCartQueryRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

		/// <summary>
		/// Belirtilen Id'ye göre Cart bilgisini getirir.
		/// </summary>
		/// <remarks>
		/// Bu endpoint, Id'ye göre Cart bilgisini getirir.
		/// </remarks>
		/// <param name="request">Id parametresini içeren istek nesnesi.</param>
		/// <returns>Id'ye göre Cart bilgisi ve işlem sonucu.</returns>
		/// <response code="200">Başarılı istek.</response>
		/// <response code="400">Geçersiz istek.</response>
		/// <response code="401">Yetkisiz erişim.</response>
		[HttpGet("[action]/{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Tüm Cartleri Getir", Menu = "Kart")]
		public async Task<ActionResult<TransactionResultPack<GetByIdCartQueryResponse>>> GetByIdCart([FromRoute] GetByIdCartQueryRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

		[HttpPost("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Tüm Cartları Getir", Menu = "Kart")]
		public async Task<ActionResult<TransactionResultPack<CreateCartCommandResponse>>> CreateCart([FromBody] CreateCartCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}


		[HttpDelete("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "DeleteCart", Menu = "Cart")]
		public async Task<ActionResult<TransactionResultPack<DeleteCartCommandResponse>>> DeleteCart([FromQuery] DeleteCartCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

	}
}
