using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class AddressDetailsViewModel : RenderModel
	{
		public IList<SelectListItem> AvailableCountries
		{
			get;
			set;
		}

		public AddressViewModel BillingAddress
		{
			get;
			set;
		}

		public bool IsShippingAddressDifferent
		{
			get;
			set;
		}

		public AddressViewModel ShippingAddress
		{
			get;
			set;
		}

		public AddressDetailsViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
			this.ShippingAddress = new AddressViewModel();
			this.BillingAddress = new AddressViewModel();
			this.AvailableCountries = new List<SelectListItem>();
			this.IsShippingAddressDifferent = false;
		}
	}
}