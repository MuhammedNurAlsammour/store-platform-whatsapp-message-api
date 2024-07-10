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
				OperationResult = new TransactionResult
				{
					MessageTitle = aMessageTitle ?? "İşlem Başarılı",
					MessageContent = aMessageContent,
					MessageDetail = aMessageDetail,
					Result = TransactionResultEnm.Success
				},
				RefId = aRefId
			};
		}

        #endregion CreateSuccessResult

        #region CreateErrorResult

        /// <summary>
        /// Hatalı bir işlem sonucu paketi oluşturur.
        /// </summary>
        /// <typeparam name="T">Sonuç paketi değer tipi</typeparam>
        /// <param name="aRefId">Referans ID</param>
        /// <param name="aId">ID</param>
        /// <param name="aMessageTitle">Mesaj başlık</param>
        /// <param name="aMessageContent">Mesaj içerik</param>
        /// <param name="aMessageDetail">Mesaj detay</param>
        /// <returns>Oluşturulan işlem sonucu paketi</returns>
        public static TransactionResultPack<T> CreateErrorResult<T>(object aRefId, int? aId, string? aMessageTitle, string aMessageContent, string aMessageDetail)
        {
            return new TransactionResultPack<T>
            {
                OperationResult = new TransactionResult
                {
                    MessageTitle = aMessageTitle ?? "Hata / İşlem Başarısız",
                    MessageContent = aMessageContent,
                    MessageDetail = aMessageDetail,
                    Result = TransactionResultEnm.Error
                },
                RefId = aRefId
            };
        }

        #endregion CreateErrorResult



        #region CreateWarningResult


        /// <summary>
        /// Uyarı içeren bir işlem sonucu paketi oluşturur.
        /// </summary>
        /// <typeparam name="T">Sonuç paketi değer tipi</typeparam>
        /// <param name="aRefId">Referans ID</param>
        /// <param name="aId">ID</param>
        /// <param name="aMessageTitle">Mesaj başlık</param>
        /// <param name="aMessageContent">Mesaj içerik</param>
        /// <param name="aMessageDetail">Mesaj detay</param>
        /// <returns>Oluşturulan işlem sonucu paketi</returns>
        public static TransactionResultPack<T> CreateWarningResult<T>(object aRefId, int? aId, string? aMessageTitle, string aMessageContent, string aMessageDetail)
        {
            return new TransactionResultPack<T>
            {
                OperationResult = new TransactionResult
                {
                    MessageTitle = aMessageTitle ?? "Uyarı!",
                    MessageContent = aMessageContent,
                    MessageDetail = aMessageDetail,
                    Result = TransactionResultEnm.Warning
                },
                RefId = aRefId
            };
        }



        #endregion CreateWarningResult

        #region CreateEmptyResult

        /// <summary>
        /// Boş bir işlem sonucu paketi oluşturur.
        /// </summary>
        /// <typeparam name="T">Sonuç paketi değer tipi</typeparam>
        /// <param name="aRefId">Referans ID</param>
        /// <param name="aId">ID</param>
        /// <param name="aMessageTitle">Mesaj başlık</param>
        /// <param name="aMessageContent">Mesaj içerik</param>
        /// <param name="aMessageDetail">Mesaj detay</param>
        /// <returns>Oluşturulan işlem sonucu paketi</returns>
        public static TransactionResultPack<T> CreateEmptyResult<T>(object aRefId, int? aId, string? aMessageTitle, string aMessageContent, string aMessageDetail)
        {
            return new TransactionResultPack<T>
            {
                OperationResult = new TransactionResult
                {
                    MessageTitle = aMessageTitle ?? "Uyarı / Boş Durum",
                    MessageContent = aMessageContent,
                    MessageDetail = aMessageDetail,
                    Result = TransactionResultEnm.Empty
                },
                RefId = aRefId
            };
        }

        #endregion CreateEmptyResult
    }
}
