namespace StorePlatform.Domain.Entities.Common
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime RowCreatedDate { get; set; }
		virtual public DateTime RowUpdatedDate { get; set; }
		public bool RowIsActive { get; set; }
		public bool RowIsDeleted { get; set; }

		public bool RowActiveAndNotDeleted => RowIsActive && !RowIsDeleted;
		public bool RowIsNotDeleted => !RowIsDeleted;
	}
}
