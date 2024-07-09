using StorePlatform.Application.Dtos.Enums;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Operations
{
	public static class ResultFactory
	{
		#region CreateSuccessResult

		/// <summary>
		/// Başarılı bir işlem Resultu paketi oluşturur.
		/// </summary>
		/// <typeparam name="T">Sonuç paketi değer tipi</typeparam>
		/// <param name="aEntity">İşlem Resultu içindeki ana değer</param>
		/// <param name="aRefId">Referans ID</param>
		/// <param name="aId">ID</param>
		/// <param name="aMessageTitle">Mesaj başlık</param>
		/// <param name="aMessageContent">Mesaj içerik</param>
		/// <param name="aMessageDetail">Mesaj detay</param>
		/// <returns>Oluşturulan işlem Resultu paketi</returns>

		public static TransactionResultPack<T> CreateSuccessResult<T>(T aEntity, object aRefId, int? aId, string? aMessageTitle, string aMessageContent, string aMessageDetail)
		{
			return new TransactionResultPack<T>
			{
				Result = aEntity,
				IslemSonuc = new TransactionResult
				{
					MesajBaslik = aMessageTitle ?? "İşlem Başarılı",
					MesajIcerik = aMessageContent,
					MesajDetay = aMessageDetail,
					Sonuc = TransactionResultEnm.Basarili
				},
				RefId = aRefId
			};
		}

		#endregion CreateSuccessResult

		#region CreateErrorResult

		/// <summary>
		/// Hatalı bir işlem Resultu paketi oluşturur.
		/// </summary>
		/// <typeparam name="T">Sonuç paketi değer tipi</typeparam>
		/// <param name="aRefId">Referans ID</param>
		/// <param name="aId">ID</param>
		/// <param name="aMessageTitle">Mesaj başlık</param>
		/// <param name="aMessageContent">Mesaj içerik</param>
		/// <param name="aMessageDetail">Mesaj detay</param>
		/// <returns>Oluşturulan işlem Resultu paketi</returns>
		public static TransactionResultPack<T> CreateErrorResult<T>(object aRefId, int? aId, string? aMessageTitle, string aMessageContent, string aMessageDetail)
		{
			return new TransactionResultPack<T>
			{
				IslemSonuc = new TransactionResult
				{
					MesajBaslik = aMessageTitle ?? "Error / Operation Failed",
					MesajIcerik = aMessageContent,
					MesajDetay = aMessageDetail,
					Sonuc = TransactionResultEnm.Hata
				},
				RefId = aRefId
			};
		}

		#endregion CreateErrorResult

		#region CreateWarningResult

		/// <summary>
		/// Uyarı bir işlem Resultu paketi oluşturur.
		/// </summary>
		/// <typeparam name="T">Sonuç paketi değer tipi</typeparam>
		/// <param name="aRefId">Referans ID</param>
		/// <param name="aId">ID</param>
		/// <param name="aMessageTitle">Mesaj başlık</param>
		/// <param name="aMessageContent">Mesaj içerik</param>
		/// <param name="aMessageDetail">Mesaj detay</param>
		/// <returns>Oluşturulan işlem Resultu paketi</returns>
		public static TransactionResultPack<T> CreateWarningResult<T>(object aRefId, int? aId, string? aMessageTitle, string aMessageContent, string aMessageDetail)
		{
			return new TransactionResultPack<T>
			{
				IslemSonuc = new TransactionResult
				{
					MesajBaslik = aMessageTitle ?? "Uyarı!",
					MesajIcerik = aMessageContent,
					MesajDetay = aMessageDetail,
					Sonuc = TransactionResultEnm.Uyari
				},
				RefId = aRefId
			};
		}

		#endregion CreateWarningResult

		#region CreateEmptyResult

		/// <summary>
		/// Boş bir işlem Resultu paketi oluşturur.
		/// </summary>
		/// <typeparam name="T">Sonuç paketi değer tipi</typeparam>
		/// <param name="aRefId">Referans ID</param>
		/// <param name="aId">ID</param>
		/// <param name="aMessageTitle">Mesaj başlık</param>
		/// <param name="aMessageContent">Mesaj içerik</param>
		/// <param name="aMessageDetail">Mesaj detay</param>
		/// <returns>Oluşturulan işlem Resultu paketi</returns>
		public static TransactionResultPack<T> CreateEmptyResult<T>(object aRefId, int? aId, string? aMessageTitle, string aMessageContent, string aMessageDetail)
		{
			return new TransactionResultPack<T>
			{
				IslemSonuc = new TransactionResult
				{
					MesajBaslik = aMessageTitle ?? "Uyarı / Boş Olma Durumu",
					MesajIcerik = aMessageContent,
					MesajDetay = aMessageDetail,
					Sonuc = TransactionResultEnm.Bos
				},
				RefId = aRefId
			};
		}

		#endregion CreateEmptyResult
	}
}
