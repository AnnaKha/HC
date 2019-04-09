namespace Core.Models
{
	public class ContactWithRequiredInfo
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		public string Email { get; set; }
		public string AddressType { get; set; }
		public bool Primary { get; set; }
		public string State { get; set; }
	}
}
