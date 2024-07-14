using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Dtos.ResponseDtos.Employee
{
	public class EmployeeDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? TcNo { get; set; }
		public string? Gsm { get; set; }
		public string? Email { get; set; }
		public string? Address { get; set; }
		public int Sex { get; set; }
		public Guid? AuthUserId { get; set; }
		public DateTime RowCreatedDate { get; set; } 
		public DateTime RowUpdatedDate { get; set; } 
		public bool RowIsActive { get; set; } 
		public bool RowIsDeleted { get; set; }
	}
}
