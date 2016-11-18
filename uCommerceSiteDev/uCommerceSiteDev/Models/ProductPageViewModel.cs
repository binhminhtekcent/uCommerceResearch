using System;
using System.Runtime.CompilerServices;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class ProductPageViewModel : RenderModel
	{
		public bool AddedToBasket
		{
			get;
			set;
		}

		public bool ItemAlreadyExists
		{
			get;
			set;
		}

		public ProductViewModel ProductViewModel
		{
			get;
			set;
		}

		public ProductPageViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
		}
	}
}