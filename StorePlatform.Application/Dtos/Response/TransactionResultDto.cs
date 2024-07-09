
namespace StorePlatform.Application.Dtos.Response
{

	public class TransactionResultDto<T>
	{
		public T? Result { get; set; }
		public object? RefId { get; set; }
		public decimal? Id { get; set; }
		public string? MesajBaslik { get; set; }
		public string? MesajIcerik { get; set; }
		public string? MesajDetay { get; set; }
	}
}
