

using StorePlatform.Application.Dtos.Enums;

namespace StorePlatform.Application.Dtos.Response
{


	public class TransactionResult
	{
		public decimal ReferansId { get; set; }
		public string? MesajBaslik { get; set; }
		public string? MesajIcerik { get; set; }
		public string? MesajDetay { get; set; }
		public TransactionResultEnm Sonuc { get; set; }
	}
}
