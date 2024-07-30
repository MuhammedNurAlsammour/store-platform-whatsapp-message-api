using StorePlatform.Domain.Entities.Common;


namespace StorePlatform.Domain.Entities
{
	public class Cart  : BaseEntity
	{
		/// <summary>
		/// Ürün kimliği, ürünler tablosunda olmalıdır
		/// </summary>
		public Guid ProductId { get; set; }

		/// <summary>
		/// İstenen ürün miktarı, sıfırdan büyük olmalıdır
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// Ürün fiyatı, sıfır veya daha fazla olmalıdır
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Müşteri kimliği, müşteriler tablosunda olmalıdır
		/// </summary>
		public Guid CustomerId { get; set; }
	}
}
