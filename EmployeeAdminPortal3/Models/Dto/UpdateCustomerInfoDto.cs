namespace EmployeeAdminPortal3.Models.Dto
{
	public class UpdateCustomerInfoDto
	{
		public required string customerFirstName { get; set; }
		public required string customerLastName { get; set; }
		public required string customerEmail { get; set; }
		public required string customerAddress { get; set; }
		public string? customerPhone { get; set; }
	}
}
