using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Dtos.ResponseDtos.Prodduct;
using StorePlatform.Application.Features.Commands.Example.UpdateExample;
using StorePlatform.Application.Features.Commands.Product.CreateProduct;
using StorePlatform.Application.Features.Commands.Product.UpdateProduct;
using StorePlatform.Application.Features.Queries.Product.GetAllProducts;
using StorePlatform.Application.Features.Queries.Product.GetByIdProduct;
using StorePlatform.Application.Operations;

namespace StorePlatform.API.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class ProductController(IMediator mediator) : BaseController
	{


		/// <summary>
		/// Tüm ürünleri getiren işlev.
		/// </summary>
		/// <remarks>
		/// Bu HTTP GET uç noktası, tüm ürünlerin listesini getirir.
		/// </remarks>
		/// <param name="request">Ürünleri filtrelemek için kullanılan sorgu parametreleri.</param>
		/// <returns>HTTP 200 OK ile ürünlerin listesini döner.</returns>
		/// <response code="200">Başarılı durumda, ürünlerin listesini döner.</response>
		/// <response code="400">Geçersiz istek durumunda.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpGet("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Ürün Listesi Getirme", Menu = "Ürün")]
		public async Task<ActionResult<TransactionResultPack<List<ProductDTO>>>> GetAllProducts([FromQuery] GetAllProductsQueryRequest request)
		{
			var response = await mediator.Send(request);
			return Ok(response);
		}


		/// <summary>
		/// Belirtilen ID'ye sahip ürünü getirir.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirli bir ürünün bilgilerini getirir.
		/// </remarks>
		/// <param name="request">Ürün kimliğini içeren istek.</param>
		/// <returns>Ürün bilgilerini döndürür.</returns>
		/// <response code="200">Ürün bilgilerini döndürür.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Ürün bulunamazsa.</response>
		[HttpGet("[action]/{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Belirli Ürünü Getirme", Menu = "Ürün")]
		public async Task<ActionResult<TransactionResultPack<List<ProductDTO>>>> GetByIdProduct([FromRoute] GetByIdProductQueryRequest request)
		{
			var response = await mediator.Send(request);
			return Ok(response);
		}


		/// <summary>
		/// Yeni bir ürün oluşturan işlev.
		/// </summary>
		/// <remarks>
		/// Bu HTTP POST uç noktası, gelen istek verisiyle yeni bir ürün ekler.
		/// </remarks>
		/// <param name="request">Yeni ürün bilgilerini içeren istek verisi.</param>
		/// <returns>HTTP durum koduna göre işlem sonucunu döner.</returns>
		/// <response code="201">Başarılı durumda, yeni ürün başarıyla oluşturuldu.</response>
		/// <response code="400">Geçersiz istek durumunda.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpPost("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Yeni Ürün Oluşturma", Menu = "Ürün")]
		public async Task<ActionResult<TransactionResultPack<List<ProductDTO>>>> CreateProduct([FromBody] CreateProductCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode(response.StatusCode);
		}

	}
}
