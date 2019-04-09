using Newtonsoft.Json;

namespace Core.Helpers
{
	public class ContactRequiredInfo
	{
		[JsonProperty("listSpecific")]
		public bool ListSpecific { get; set; }

		[JsonProperty("firstName")]
		public string FirstName { get; set; }

		[JsonProperty("middleName")]
		public string MiddleName { get; set; }

		[JsonProperty("lastName")]
		public string LastName { get; set; }

		[JsonProperty("companyName")]
		public string CompanyName { get; set; }

		[JsonProperty("jobTitle")]
		public string JobTitle { get; set; }

		[JsonProperty("showName")]
		public string ShowName { get; set; }

		[JsonProperty("topics")]
		public string Topics { get; set; }

		[JsonProperty("markets")]
		public string Markets { get; set; }

		[JsonProperty("mediaType")]
		public string MediaType { get; set; }

		[JsonProperty("companyWebsite")]
		public string CompanyWebsite { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("national")]
		public string National { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("mobile")]
		public string Mobile { get; set; }

		[JsonProperty("office")]
		public string Office { get; set; }

		[JsonProperty("addressType")]
		public string AddressType { get; set; }

		[JsonProperty("primary")]
		public bool Primary { get; set; }

		[JsonProperty("poBox")]
		public string POBox { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("state")]
		public string State { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("street")]
		public string Street { get; set; }

		[JsonProperty("appartment")]
		public string Appartment { get; set; }

		[JsonProperty("zip")]
		public string Zip { get; set; }

		[JsonProperty("reasonOfReturnedPackages")]
		public string ReasonOfReturnedPackages { get; set; }

		[JsonProperty("facebook")]
		public string Facebook { get; set; }

		[JsonProperty("instagram")]
		public string Instagram { get; set; }

		[JsonProperty("twitter")]
		public string Twitter { get; set; }

		[JsonProperty("linkedIn")]
		public string LinkedIn { get; set; }

		[JsonProperty("youTube")]
		public string YouTube { get; set; }
	}
}
