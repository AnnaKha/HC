using System.Linq;
using Core.Models;
using Core.WebElements;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Publicity.TestData;
using System;

namespace Publicity.Pages
{
	public class CreateEditContact
	{
		private readonly static string inputXpath = "/following-sibling::input";

		public ClickElement Public = new ClickElement(By.XPath("//app-radio-group//li[1]"));
		public ClickElement ListSpecific = new ClickElement(By.XPath("//app-radio-group//li[2]"));

		//Contact info section
		public Input FirstName = new Input(By.XPath($"//label[text()='First Name']{inputXpath}"));
		public Input MiddleName = new Input(By.XPath($"//label[text()='Middle Name']{inputXpath}"));
		public Input LastName = new Input(By.XPath($"//label[text()='Last Name']{inputXpath}"));
		public Input CompanyName = new Input(By.XPath($"//label[text()='Company Name']{inputXpath}"));
		public Input JobTitle = new Input(By.XPath($"//label[text()='Job Title']{inputXpath}"));
		public Input ShowName = new Input(By.XPath($"//label[text()='Show Name']{inputXpath}"));
		public MultiSelect Topics = new MultiSelect(By.XPath($"//label[text()='Topics']{inputXpath}"));
		public MultiSelect Markets = new MultiSelect(By.XPath($"//label[text()='Markets']{inputXpath}"));
		public MultiSelect MediaType = new MultiSelect(By.XPath($"//label[text()='Media Type']{inputXpath}"));
		public Input CompanyWebsite = new Input(By.XPath($"//label[text()='Company Website']{inputXpath}"));
		public MultiSelect Language = new MultiSelect(By.XPath($"//label[text()='Language']{inputXpath}"));
		public ClickElement National = new ClickElement(By.XPath("//app-checkbox[@label='National']"));

		//Contact details section
		public Input Email = new Input(By.XPath($"//label[text()='Email']{inputXpath}"));
		public Input Mobile = new Input(By.XPath($"//label[text()='Mobile']{inputXpath}"));
		public Input Office = new Input(By.XPath($"//label[text()='Office']{inputXpath}"));

		//Contact address section
		public Select AddressType = new Select(By.XPath(".//label[text()='Address Type']"));
		public ClickElement Primary = new ClickElement(By.XPath(".//app-checkbox[@label='Primary']"));
		public Input POBox = new Input(By.XPath($".//label[text()='PO Box']{inputXpath}"));
		public Select Country = new Select(By.XPath(".//label[text()='Country']"));
		public Select State = new Select(By.XPath(".//label[text()='State']"));
		public Input City = new Input(By.XPath($".//label[text()='City']{inputXpath}"));
		public Input Street = new Input(By.XPath($".//label[text()='Street']{inputXpath}"));
		public Input Appartment = new Input(By.XPath($".//label[contains(text(),'Apt')]{inputXpath}"));
		public Input Zip = new Input(By.XPath($".//label[text()='Zip']{inputXpath}"));
		public Select ReasonOfReturnedPackages = new Select(By.XPath(".//label[text()='Reason of Returned Package(Make select)']"));
		public ClickElement Validate = new ClickElement(By.XPath(".//input[@value='Validate']"));
		public ClickElement Remove = new ClickElement(By.XPath(".//input[@value='Remove']"));

		//Social media section
		public Input Facebook = new Input(By.XPath($"//label[text()='Facebook']{inputXpath}"));
		public Input Instagram = new Input(By.XPath($"//label[text()='Instagram']{inputXpath}"));
		public Input Twitter = new Input(By.XPath($"//label[text()='Twitter']{inputXpath}"));
		public Input LinkedIn = new Input(By.XPath($"//label[text()='LinkedIn']{inputXpath}"));
		public Input YouTube = new Input(By.XPath($"//label[text()='YouTube']{inputXpath}"));

		//Pitching profile and Comment section
		public Input PitchingProfile = new Input(By.XPath("(//textarea)[1]"));
		public Input Comment = new Input(By.XPath("(//textarea)[2]"));

		public ClickElement Save = new ClickElement(By.XPath("//input[@type='submit']"));
		public ClickElement Reset = new ClickElement(By.XPath("//input[@type='reset']"));
		public ClickElement AddAdditionalAddresses = new ClickElement(By.XPath("//input[@value='+ Add Additional Addresses']"));
		public ClickElement AddComment = new ClickElement(By.XPath("//input[@value='Add Comment']"));
		public Element ContactSavedMessage = new Element(By.XPath("//div[contains(text(),'Contact saved')]"));

		public Contact GetContactInfo()
		{
			ContactSavedMessage.WaitForNotDisplayed();
			Contact contactDetails = new Contact();
			Public.WaitForDisplayed();

			if (Public.IsSelected == true)
			{ contactDetails.ListSpecific = "Public"; }
			else if (ListSpecific.IsSelected == true)
			{ contactDetails.ListSpecific = "List Specific"; }
			else { contactDetails.ListSpecific = string.Empty; }
			contactDetails.FirstName = FirstName.GetValue();
			contactDetails.MiddleName = MiddleName.GetValue();
			contactDetails.LastName = LastName.GetValue();
			contactDetails.CompanyName = CompanyName.GetValue();
			contactDetails.JobTitle = JobTitle.GetValue();
			contactDetails.ShowName = ShowName.GetValue();
			contactDetails.Topics = Topics.SelectedValues();
			contactDetails.Markets = Markets.SelectedValues();
			contactDetails.MediaType = MediaType.SelectedValues();
			contactDetails.CompanyWebsite = CompanyWebsite.GetValue();
			contactDetails.Language = Language.SelectedValues();
			contactDetails.National = National.IsSelected;
			contactDetails.Email = Email.GetValue();
			contactDetails.Mobile = Mobile.GetValue();
			contactDetails.Office = Office.GetValue();

			if (AddressType.IsDisplayed())
			{
				contactDetails.AddressType = AddressType.SelectedOption();
				contactDetails.Primary = Primary.IsSelected;
				contactDetails.POBox = POBox.GetValue();
				contactDetails.Country = Country.SelectedOption();
				contactDetails.State = State.SelectedOption();
				contactDetails.City = City.GetValue();
				contactDetails.Street = Street.GetValue();
				contactDetails.Appartment = Appartment.GetValue();
				contactDetails.Zip = Zip.GetValue();
				contactDetails.ReasonOfReturnedPackages = ReasonOfReturnedPackages.SelectedOption();
			}
			else
			{
				contactDetails.AddressType = string.Empty;
				contactDetails.Primary = false;
				contactDetails.POBox = string.Empty;
				contactDetails.Country = string.Empty;
				contactDetails.State = string.Empty;
				contactDetails.City = string.Empty;
				contactDetails.Street = string.Empty;
				contactDetails.Appartment = string.Empty;
				contactDetails.Zip = string.Empty;
				contactDetails.ReasonOfReturnedPackages = string.Empty;
			}
			contactDetails.Facebook = Facebook.GetValue();
			contactDetails.Instagram = Instagram.GetValue();
			contactDetails.Twitter = Twitter.GetValue();
			contactDetails.LinkedIn = LinkedIn.GetValue();
			contactDetails.YouTube = YouTube.GetValue();

			contactDetails.PitchingProfile = PitchingProfile.GetValue();
			if (Comment.IsDisplayed())
			{ contactDetails.Comment = Comment.GetValue(); }

				return contactDetails;
		}

		public ContactWithRequiredInfo EnterOnlyRequiredDataForContact()
		{
			var rawTestData = JObject.Parse(TestDataLocationReader.ContactTestData);
			ContactWithRequiredInfo contactWithRequiredInfo = rawTestData["NewContact"][0].ToObject<ContactWithRequiredInfo>();
			string uniqueName = contactWithRequiredInfo.FirstName + Guid.NewGuid();

			FirstName.WaitForDisplayed();
			FirstName.SetText(uniqueName);
			LastName.SetText(contactWithRequiredInfo.LastName);
			CompanyName.SetText(contactWithRequiredInfo.CompanyName);
			Email.SetText(contactWithRequiredInfo.Email);
			AddressType.SelectByText(contactWithRequiredInfo.AddressType);
			State.SelectByText(contactWithRequiredInfo.State);
			Primary.Click();

			contactWithRequiredInfo.FirstName = uniqueName;
			return contactWithRequiredInfo;
		}

		public Contact EnterAllDataForContact()
		{
			var rawTestData = JObject.Parse(TestDataLocationReader.ContactTestData);
			Contact contactWithAllInfo = rawTestData["NewContact"][0].ToObject<Contact>();
			switch (contactWithAllInfo.ListSpecific)
			{
				case "Public":
					Public.Click();
					break;
				case "List Specific":
					ListSpecific.Click();
					break;
			};
			string uniqueName = contactWithAllInfo.FirstName + Guid.NewGuid();

			AddComment.WaitForDisplayed();
			ReasonOfReturnedPackages.SelectByText(contactWithAllInfo.ReasonOfReturnedPackages);

			FirstName.SetText(uniqueName);
			MiddleName.SetText(contactWithAllInfo.MiddleName);
			LastName.SetText(contactWithAllInfo.LastName);
			CompanyName.SetText(contactWithAllInfo.CompanyName);
			JobTitle.SetText(contactWithAllInfo.JobTitle);
			ShowName.SetText(contactWithAllInfo.ShowName);
			foreach (string option in contactWithAllInfo.Topics.Split(',').ToList())
			{ Topics.SetValue(option); }
			foreach (string option in contactWithAllInfo.MediaType.Split(',').ToList())
			{ MediaType.SetValue(option); }
			foreach (string option in contactWithAllInfo.Markets.Split(',').ToList())
			{ Markets.SetValue(option); }
			CompanyWebsite.SetText(contactWithAllInfo.CompanyWebsite);
			if (Language.SelectedValues() != "English" && contactWithAllInfo.Language != "English")
			{ Language.SetValue(contactWithAllInfo.Language); }
			if (contactWithAllInfo.National == true)
			{ National.Click(); };

			Email.SetText(contactWithAllInfo.Email);
			Mobile.SetText(contactWithAllInfo.Mobile);
			Office.SetText(contactWithAllInfo.Office);

			AddressType.SelectByText(contactWithAllInfo.AddressType);
			if (contactWithAllInfo.Primary == true)
			{ Primary.Click(); };
			POBox.SetText(contactWithAllInfo.POBox);
			Country.SelectByText(contactWithAllInfo.Country);
			State.SelectByText(contactWithAllInfo.State);
			City.SetText(contactWithAllInfo.City);
			Street.SetText(contactWithAllInfo.Street);
			Appartment.SetText(contactWithAllInfo.Appartment);
			Zip.SetText(contactWithAllInfo.Zip);

			Facebook.SetText(contactWithAllInfo.Facebook);
			Instagram.SetText(contactWithAllInfo.Instagram);
			Twitter.SetText(contactWithAllInfo.Twitter);
			LinkedIn.SetText(contactWithAllInfo.LinkedIn);
			YouTube.SetText(contactWithAllInfo.YouTube);

			PitchingProfile.SetText(contactWithAllInfo.PitchingProfile);
			AddComment.Click();
			Comment.SetText(contactWithAllInfo.Comment);
			contactWithAllInfo.FirstName = uniqueName;
			return contactWithAllInfo;
		}

		public AdditionalAddress AddAddressForContact(int index = 1)
		{
			var rawTestData = JObject.Parse(TestDataLocationReader.ContactTestData);
			AdditionalAddress contactAddress = rawTestData["AdditionalAddress"][0].ToObject<AdditionalAddress>();
			AddAdditionalAddresses.Click();

			Element addressSection = new Element(By.XPath($"(//app-edit-address)[{index}]"));
			addressSection.Child<Select>(AddressType.GetSelector()).SelectByText(contactAddress.AddressType);
			if (contactAddress.Primary == true)
			{ addressSection.Child(Primary.GetSelector()).Click(); }
			addressSection.Child<Input>(POBox.GetSelector()).SetText(contactAddress.POBox);
			addressSection.Child<Select>(Country.GetSelector()).SelectByText(contactAddress.Country);
			addressSection.Child<Select>(State.GetSelector()).SelectByText(contactAddress.State);
			addressSection.Child<Input>(City.GetSelector()).SetText(contactAddress.City);
			addressSection.Child<Input>(Street.GetSelector()).SetText(contactAddress.Street);
			addressSection.Child<Input>(Appartment.GetSelector()).SetText(contactAddress.Appartment);
			addressSection.Child<Input>(Zip.GetSelector()).SetText(contactAddress.Zip);
			addressSection.Child<Select>(ReasonOfReturnedPackages.GetSelector()).SelectByText(contactAddress.ReasonOfReturnedPackages);
			return contactAddress;
		}

		public AdditionalAddress GetContactAdditionalAddress(int index = 1)
		{
			AdditionalAddress address = new AdditionalAddress();
			Element addressSection = new Element(By.XPath($"(//app-edit-address)[{index}]"));
			address.AddressType = addressSection.Child<Select>(AddressType.GetSelector()).SelectedOption();
			address.Primary = addressSection.Child(Primary.GetSelector()).Selected;
			address.POBox = addressSection.Child<Input>(POBox.GetSelector()).GetValue();
			address.Country = addressSection.Child<Select>(Country.GetSelector()).SelectedOption();
			address.State = addressSection.Child<Select>(State.GetSelector()).SelectedOption();
			address.City = addressSection.Child<Input>(City.GetSelector()).GetValue();
			address.Street = addressSection.Child<Input>(Street.GetSelector()).GetValue();
			address.Appartment = addressSection.Child<Input>(Appartment.GetSelector()).GetValue();
			address.Zip = addressSection.Child<Input>(Zip.GetSelector()).GetValue();
			address.ReasonOfReturnedPackages = addressSection.Child<Select>(ReasonOfReturnedPackages.GetSelector()).SelectedOption();

			return address;
		}

		public void SaveUpdatedContactInfo()
		{
			Save.Click();
			ContactSavedMessage.WaitForDisplayed();
		}
	}
}
