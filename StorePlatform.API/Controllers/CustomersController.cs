using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Features.Commands.Customer.CreateCustomer;
using StorePlatform.Application.Features.Commands.Customer.DeleteCustomer;
using StorePlatform.Application.Features.Commands.Customer.UpdateCustomer;

using StorePlatform.Application.Features.Queries.Customer.GetAllCustomer;
using StorePlatform.Application.Features.Queries.Customer.GetByIdCustomer;
using StorePlatform.Application.Features.Queries.Employee.GetAllEmployee;
using StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee;
using StorePlatform.Application.Operations;

namespace StorePlatform.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class CustomersController(IMediator mediator) : ControllerBase
    {
		/// <summary>
		/// Admin Ana Ekran Müşteri Listesi Getirir.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirtilen sayfa ve boyuta göre tüm müşterilerin listesini getirir.
		/// </remarks>
		/// <param name="request">Tüm müşterileri getirme parametrelerini içeren istek.</param>
		/// <returns>Müşteri listesini döndürür.</returns>
		/// <response code="200">Müşteri listesini döndürür.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpGet("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Müşteri Listesi Getirir", Menu = "Müşteri")]
		public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersQueryRequest request)
		{
			var response = await mediator.Send(request);
			return Ok(response);
		}

		/// <summary>
		/// Belirtilen ID'ye göre müşteri bilgilerini getirir.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirli bir müşteri kimliğine göre müşteri bilgilerini getirir.
		/// </remarks>
		/// <param name="request">Müşteri kimliğini içeren istek.</param>
		/// <returns>Müşteri bilgilerini döndürür.</returns>
		/// <response code="200">Müşteri bilgilerini döndürür.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Müşteri bulunamazsa.</response>
		[HttpGet("[action]/{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "ID ye Göre Müşteri Bilgilerini Görüntüle", Menu = "Müşteri")]
		public async Task<IActionResult> GetByIdCustomer([FromRoute] GetByIdCustomerQueryRequest request)
		{
			var response = await mediator.Send(request);
			return Ok(response);
		}

		/// <summary>
		/// Yeni bir müşteri ekler.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, yeni bir müşteri ekler.
		/// </remarks>
		/// <param name="request">Yeni müşteri bilgilerini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="201">Müşteri başarıyla oluşturuldu.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpPost("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Müşteri Eklemek", Menu = "Müşteri")]
		public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode(response.StatusCode);
		}

		/// <summary>
		/// Mevcut bir müşteri kaydını günceller.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirtilen ID'ye sahip müşterinin bilgilerini günceller.
		/// </remarks>
		/// <param name="request">Güncellenecek müşteri bilgilerini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="200">Müşteri başarıyla güncellendi.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Güncellenecek müşteri bulunamazsa.</response>
		[HttpPut("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Müşteri Güncelemek", Menu = "Müşteri")]
		public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode(response.StatusCode);
		}

		/// <summary>
		/// Belirtilen ID'ye sahip müşteri kaydını siler.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirtilen ID'ye sahip müşteri kaydını siler.
		/// </remarks>
		/// <param name="request">Silinecek müşteri kimliğini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="200">Müşteri başarıyla silindi.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Silinecek müşteri bulunamazsa.</response>
		[HttpDelete("[action]/{Id}")]
		[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Müşteri Silme", Menu = "Müşteri")]
		public async Task<IActionResult> DeleteCustomer([FromRoute] DeleteCustomerCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode(response.StatusCode);
		}


	}
}
