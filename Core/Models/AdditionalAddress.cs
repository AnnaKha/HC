namespace Core.Models
{
	public class AdditionalAddress
	{
		public string AddressType { get; set; }
		public bool Primary { get; set; }
		public string POBox { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string Appartment { get; set; }
		public string Zip { get; set; }
		public string ReasonOfReturnedPackages { get; set; }
	}
}
