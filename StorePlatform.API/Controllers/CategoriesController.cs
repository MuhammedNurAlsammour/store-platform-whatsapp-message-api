using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Dtos.ResponseDtos.Categorie;
using StorePlatform.Application.Features.Commands.Categorie.CreateCategorie;
using StorePlatform.Application.Features.Queries.Categorie.GetAllCategories;
using StorePlatform.Application.Features.Queries.Categorie.GetByIdCategories;
using System.Net;
namespace StorePlatform.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class CategoriesController(IMediator mediator) : ControllerBase
	{
		/// <summary>
		/// Tüm kategorileri getirir.
		/// </summary>
		/// <remarks>
		/// Bu endpoint, sayfa ve boyut parametrelerine göre tüm kategorileri getirir.
		/// </remarks>
		/// <param name="request">Sayfa ve boyut parametrelerini içeren istek nesnesi.</param>
		/// <returns>Kategorilerin listesi ve işlem sonucu.</returns>
		/// <response code="200">Başarılı istek.</response>
		/// <response code="400">Geçersiz istek.</response>
		/// <response code="401">Yetkisiz erişim.</response>
		[HttpGet("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Tüm Kategorileri Getir", Menu = "Kategoriler")]
		public async Task<ActionResult<TransactionResultPack<List<CategoriesDTO>>>> GetAllCategories([FromQuery] GetAllCategoriesQueryRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

		/// <summary>
		/// ID'sine göre bir kategori getirir.
		/// </summary>
		/// <remarks>
		/// Bu endpoint, belirtilen kategori ID'sine göre kategori bilgilerini döner.
		/// </remarks>
		/// <param name="id">Getirilmek istenen kategori ID'si.</param>
		/// <returns>Kategori bilgileri ve işlem sonucu.</returns>
		/// <response code="200">Başarılı istek.</response>
		/// <response code="404">Kategori bulunamadı.</response>
		/// <response code="401">Yetkisiz erişim.</response>
		[HttpGet("[action]/{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "ID ile Kategori Getir", Menu = "Kategoriler")]
		public async Task<ActionResult<TransactionResultPack<CategoriesDTO>>> GetByIdCategories([FromRoute] GetByIdCategoriesQueryRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}


		/// <summary>
		/// Yeni bir Kategori ekler.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, yeni bir Kategori ekler.
		/// </remarks>
		/// <param name="request">Yeni Kategori bilgilerini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="201">Kategori başarıyla oluşturuldu.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpPost("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Kategori Eklemek", Menu = "Kategoriler")]
		public async Task<ActionResult<TransactionResultPack<List<CategoriesDTO>>>> CreateCustomer([FromBody] CreateCategorieCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}


	}
}
