using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class ShippingViewModel : RenderModel
	{
		public IList<SelectListItem> AvailableShippingMethods
		{
			get;
			set;
		}

		public int SelectedShippingMethodId
		{
			get;
			set;
		}

		public string ShippingCountry
		{
			get;
			set;
		}

		public ShippingViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
		}
	}
}