using Karmed.External.Auth.Library.CustomAttributes;
using Karmed.External.Auth.Library.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Dtos.Response;
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
        /// Yeni bir Whatsapp mesajı gönderir.
        /// </summary>
        /// <remarks>
        /// Bu Web API uç noktası, kullanıcıdan gelen yeni bir Whatsapp mesaj isteğini işler ve mesajı Whatsapp'a gönderir.
        /// </remarks>
        /// <param name="request">Gönderilecek Whatsapp mesajının bilgilerini içeren istek.</param>
        /// <returns>Mesaj gönderme işleminin sonucunu döndürür.</returns>
        /// <response code="201">Mesaj başarıyla gönderildi.</response>
        /// <response code="400">Mesaj gönderme isteği geçersizse.</response>
        /// <response code="401">Kullanıcı Whatsapp mesajı göndermek için yetkili değilse.</response>
        [HttpPost("[action]")]
        public async Task<ActionResult<string>> Send([FromBody] SendWpMessageCommandRequest request)
        {
            return Ok( await mediator.Send(request));
        }
    }
}
