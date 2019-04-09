using AutoMapper;
using Core.Models;
using System;

namespace Core.Helpers
{
	public static class ContactMapper
	{
		public static void Initialize()
		{
			try
			{
				Mapper.AssertConfigurationIsValid();
			}
			catch (InvalidOperationException)
			{
				Mapper.Initialize(cfg =>
				{
					cfg.CreateMap<Contact, ContactWithSearchInfo>();
					cfg.CreateMap<Contact, ContactWithRequiredInfo>();
					cfg.CreateMap<Contact, AdditionalAddress>();
				});
			}
		}

		public static ContactWithSearchInfo MapToContactWithSearchContactInfoOnly(Contact contact)
		{
			Initialize();
			return Mapper.Map<Contact, ContactWithSearchInfo>(contact);
		}

		public static ContactWithRequiredInfo MapToContactWithRequiredInfoOnly(Contact contact)
		{
			Initialize();
			return Mapper.Map<Contact, ContactWithRequiredInfo>(contact);
		}

		public static AdditionalAddress MapToContactAddressInfoOnly(Contact contact)
		{
			Initialize();
			return Mapper.Map<Contact, AdditionalAddress>(contact);
		}
	}
}
