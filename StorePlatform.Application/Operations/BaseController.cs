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
		public virtual ActionResult ApiStatus<T>(TransactionResultPack<T> islemSonucPack)
		{
			var resultDto = new TransactionResultDto<T>
			{
				Result = islemSonucPack.Result,
				RefId = islemSonucPack.RefId,
				//Id = islemSonucPack.Id,
				MesajBaslik = islemSonucPack.IslemSonuc.MesajBaslik,
				MesajIcerik = islemSonucPack.IslemSonuc.MesajIcerik,
				MesajDetay = islemSonucPack.IslemSonuc.MesajDetay
			};

			if (!islemSonucPack.IslemDurum)
				return StatusCode(500, resultDto);

			if (islemSonucPack.IslemSonuc.Sonuc == TransactionResultEnm.Bos)
				return StatusCode(204, resultDto);

			if (islemSonucPack.IslemSonuc.Sonuc == TransactionResultEnm.Uyari)
				return StatusCode(400, resultDto);

			return StatusCode(200, resultDto);
		}
	}
}
