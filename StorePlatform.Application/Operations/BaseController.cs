using Microsoft.AspNetCore.Mvc;
using StorePlatform.Application.Dtos.Enums;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Operations
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		//TODO: ID alanını geri ekle

		/// <summary>
		/// API işlem sonuç paketini değerlendirerek uygun HTTP durum kodunu döndürür.
		/// </summary>
		/// <typeparam name="TResult">IslemSonucPack tipindeki sonuç paketinin değer tipi</typeparam>
		/// <param name="islemSonucPack">Değerlendirilecek işlem sonuç paketi</param>
		/// <returns>Uygun HTTP durum koduna sahip ActionResult</returns>
		[NonAction]
        public virtual ActionResult ApiStatus<T>(TransactionResultPack<T> transactionResultPack)
        {
            var resultDto = new TransactionResultDto<T>
            {
                Result = transactionResultPack.Result,
                RefId = transactionResultPack.RefId,
                //Id = transactionResultPack.Id,
                MesajBaslik = transactionResultPack.OperationResult.MessageTitle,
                MesajIcerik = transactionResultPack.OperationResult.MessageContent,
                MesajDetay = transactionResultPack.OperationResult.MessageDetail
            };

            if (!transactionResultPack.OperationStatus)
                return StatusCode(500, resultDto);

            if (transactionResultPack.OperationResult.Result == TransactionResultEnm.Empty)
                return StatusCode(204, resultDto);

            if (transactionResultPack.OperationResult.Result == TransactionResultEnm.Error)
                return StatusCode(400, resultDto);

            return StatusCode(200, resultDto);
        }

    }
}
