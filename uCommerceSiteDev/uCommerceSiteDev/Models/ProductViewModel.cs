using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UCommerce.Api;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class ProductViewModel : RenderModel
	{
		public bool IsOrderingAllowed
		{
			get;
			set;
		}

		public bool IsVariant
		{
			get;
			set;
		}

		public string LongDescription
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public UCommerce.Api.PriceCalculation PriceCalculation
		{
			get;
			set;
		}

		public IList<ProductPropertiesViewModel> Properties
		{
			get;
			set;
		}

		public IList<ProductReviewViewModel> Reviews
		{
			get;
			set;
		}

		public string Sku
		{
			get;
			set;
		}

		public string TaxCalculation
		{
			get;
			set;
		}

		public string ThumbnailImageUrl
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public IList<ProductViewModel> Variants
		{
			get;
			set;
		}

		public string VariantSku
		{
			get;
			set;
		}

		public ProductViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
			this.Variants = new List<ProductViewModel>();
			this.Properties = new List<ProductPropertiesViewModel>();
			this.Reviews = new List<ProductReviewViewModel>();
		}
	}
}