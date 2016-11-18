using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class CategoryViewModel : RenderModel
	{
		public string BannerImageUrl
		{
			get;
			set;
		}

		public int CatalogId
		{
			get;
			set;
		}

		public IList<CategoryViewModel> Categories
		{
			get;
			set;
		}

		public int CategoryId
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public IList<ProductViewModel> Products
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public CategoryViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
			this.Categories = new List<CategoryViewModel>();
			this.Products = new List<ProductViewModel>();
		}
	}
}