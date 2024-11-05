using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Dtos.ResponseDtos.Employee;
using StorePlatform.Application.Features.Commands.Employee.CreateEmployee;
using StorePlatform.Application.Features.Commands.Send.SendWpMessage;
using System.Net;

namespace StorePlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendWpMessageController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


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
        public async Task<ActionResult<string>> Send([FromBody] SendWpMessageCommandRequest request)
        {
            return Ok( await mediator.Send(request));
        }
    }
}
