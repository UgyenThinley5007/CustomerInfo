namespace EmployeeAdminPortal3.Models.Entities
{
	public class CustomerInfo
	{
        public Guid Id { get; set; }
        public required string firstName  { get; set; }
        public required string lastName  { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public string? Phone { get; set; }
    }
}
