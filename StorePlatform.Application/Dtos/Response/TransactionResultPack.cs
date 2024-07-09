using StorePlatform.Application.Dtos.Enums;

namespace StorePlatform.Application.Dtos.Response
{


	public class TransactionResultPack<T>
	{
		public T? Result { get; set; }
		public TransactionResult IslemSonuc { get; set; }
		public object? RefId { get; set; }
		//public decimal Id { get; set; }

		public bool IslemDurum => IslemSonuc.Sonuc == TransactionResultEnm.Basarili;

		public TransactionResultPack()
		{
			Result = default;
			IslemSonuc = new TransactionResult();
		}
	}
}
