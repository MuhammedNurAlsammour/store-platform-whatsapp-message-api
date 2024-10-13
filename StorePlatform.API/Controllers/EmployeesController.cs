using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Features.Commands.Employee.CreateEmployee;
using StorePlatform.Application.Features.Commands.Employee.UpdateEmployee;
using StorePlatform.Application.Features.Commands.Employee.DeleteEmployee;
using StorePlatform.Application.Features.Queries.Employee.GetAllEmployee;
using StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee;
using StorePlatform.Application.Operations;
using System.Net;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Commands.Customer.UpdateCustomer;
using StorePlatform.Application.Dtos.ResponseDtos.Customer;
using StorePlatform.Application.Dtos.ResponseDtos.Employee;
using StorePlatform.Application.Features.Queries.Employee.GetEmployeeByUserId;


namespace StorePlatform.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class EmployeesController(IMediator mediator) : ControllerBase
    {
		/// <summary>
		/// Admin Ana Ekran Personel Listesi Getirir.
		/// </summary>
		/// <remarks>
		/// Bu page ve size, tüm personelin listesini getirir.
		/// </remarks>
		/// <param name="request">Tüm personeli getirme parametrelerini içeren istek.</param>
		/// <returns>Personel listesini döndürür.</returns>
		/// <response code="200">Personel listesini döndürür.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		[HttpGet("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "GetAllEmployees", Menu = "Employees")]
		public async Task<ActionResult<TransactionResultPack<List<EmployeeDTO>>>> GetAllEmployees([FromQuery] GetAllEmployeesQueryRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

		/// <summary>
		/// Belirtilen ID'ye sahip personeli getirir.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirli bir personelin bilgilerini getirir.
		/// </remarks>
		/// <param name="request">Personel kimliğini içeren istek.</param>
		/// <returns>Personel bilgilerini döndürür.</returns>
		/// <response code="200">Personel bilgilerini döndürür.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Personel bulunamazsa.</response>
		[HttpGet("[action]/{Id}")]      
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "GetByIdEmployee", Menu = "Employees")]
		public async Task<ActionResult<TransactionResultPack<List<EmployeeDTO>>>> GetByIdEmployee([FromRoute] GetByIdEmployeeQueryRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

        /// <summary>
        /// Belirtilen ID'ye sahip personeli getirir.
        /// </summary>
        /// <remarks>
        /// Bu uç nokta, belirli bir personelin bilgilerini getirir.
        /// </remarks>
        /// <param name="request">Personel kimliğini içeren istek.</param>
        /// <returns>Personel bilgilerini döndürür.</returns>
        /// <response code="200">Personel bilgilerini döndürür.</response>
        /// <response code="400">İstek geçersizse.</response>
        /// <response code="401">Kullanıcı yetkili değilse.</response>
        /// <response code="404">Personel bulunamazsa.</response>
        [HttpGet("[action]/{AuthUserId}")]
        public async Task<ActionResult<TransactionResultPack<List<EmployeeDTO>>>> GetEmployeeByUserId([FromRoute] GetEmployeeByUserIdQueryRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created, response);
        }


        /// <summary>
        /// Yeni bir personel oluşturur.
        /// </summary>
        /// <remarks>
        /// Bu uç nokta, yeni bir personel ekler.
        /// </remarks>
        /// <param name="request">Yeni personel bilgilerini içeren istek.</param>
        /// <returns>İşlem sonucunu döndürür.</returns>
        /// <response code="201">Personel başarıyla oluşturuldu.</response>
        /// <response code="400">İstek geçersizse.</response>
        /// <response code="401">Kullanıcı yetkili değilse.</response>
        [HttpPost("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Tüm Cartları Getir", Menu = "Kart")]
		public async Task<ActionResult<TransactionResultPack<List<EmployeeDTO>>>> CreateEmployee([FromBody] CreateEmployeeCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

		/// <summary>
		/// Mevcut bir personel kaydını günceller.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirtilen ID'ye sahip personelin bilgilerini günceller.
		/// </remarks>
		/// <param name="request">Güncellenecek personel bilgilerini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="200">Personel başarıyla güncellendi.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Güncellenecek personel bulunamazsa.</response>
		[HttpPut("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Cart Bilgisi Getir", Menu = "Kart")]
		public async Task<ActionResult<TransactionResultPack<UpdateEmployeeCommandResponse>>> UpdateEmployee([FromBody] UpdateEmployeeCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}

		/// <summary>
		/// Belirtilen ID'ye sahip personeli siler.
		/// </summary>
		/// <remarks>
		/// Bu uç nokta, belirtilen ID'ye sahip personel kaydını siler.
		/// </remarks>
		/// <param name="request">Silinecek personelin kimliğini içeren istek.</param>
		/// <returns>İşlem sonucunu döndürür.</returns>
		/// <response code="200">Personel başarıyla silindi.</response>
		/// <response code="400">İstek geçersizse.</response>
		/// <response code="401">Kullanıcı yetkili değilse.</response>
		/// <response code="404">Silinecek personel bulunamazsa.</response>
		[HttpDelete("[action]")]
		[AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "DeleteEmployee", Menu = "Employee")]
		public async Task<ActionResult<TransactionResultPack<UpdateEmployeeCommandResponse>>> DeleteEmployee([FromQuery] DeleteEmployeeCommandRequest request)
		{
			var response = await mediator.Send(request);
			return StatusCode((int)HttpStatusCode.Created, response);
		}
	}
}
