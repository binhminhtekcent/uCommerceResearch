using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class PaymentViewModel : RenderModel
	{
		public IList<SelectListItem> AvailablePaymentMethods
		{
			get;
			set;
		}

		public int SelectedPaymentMethodId
		{
			get;
			set;
		}

		public string ShippingCountry
		{
			get;
			set;
		}

		public PaymentViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
		}
	}
}