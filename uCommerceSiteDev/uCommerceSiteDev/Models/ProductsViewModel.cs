using System;
using System.Collections.Generic;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class ProductsViewModel : RenderModel
	{
		public IList<ProductViewModel> Products;

		public ProductsViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
			this.Products = new List<ProductViewModel>();
		}
	}
}