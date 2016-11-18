using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UCommerce.EntitiesV2;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Routing;

namespace uCommerceSiteDev.Models
{
	public class PurchaseOrderViewModel : RenderModel
	{
		public OrderAddress BillingAddress
		{
			get;
			set;
		}

		public decimal DiscountAmount
		{
			get;
			set;
		}

		public string DiscountTotal
		{
			get;
			set;
		}

		public IList<OrderlineViewModel> OrderLines
		{
			get;
			set;
		}

		public string OrderTotal
		{
			get;
			set;
		}

		public decimal PaymentAmount
		{
			get;
			set;
		}

		public string PaymentName
		{
			get;
			set;
		}

		public string PaymentTotal
		{
			get;
			set;
		}

		public int RemoveOrderlineId
		{
			get;
			set;
		}

		public OrderAddress ShipmentAddress
		{
			get;
			set;
		}

		public decimal ShipmentAmount
		{
			get;
			set;
		}

		public string ShipmentName
		{
			get;
			set;
		}

		public string ShippingTotal
		{
			get;
			set;
		}

		public string SubTotal
		{
			get;
			set;
		}

		public string TaxTotal
		{
			get;
			set;
		}

		public PurchaseOrderViewModel() : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
			this.OrderLines = new List<OrderlineViewModel>();
		}
	}
}