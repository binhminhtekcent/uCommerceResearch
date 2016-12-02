using System;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
	public class OrderlineViewModel
	{
		public decimal? Discount
		{
			get;
			set;
		}

		public int OrderLineId
		{
			get;
			set;
		}

		public string Price
		{
			get;
			set;
		}

		public string PriceWithDiscount
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string ProductUrl
		{
			get;
			set;
		}

		public int Quantity
		{
			get;
			set;
		}

		public string Sku
		{
			get;
			set;
		}

		public string Tax
		{
			get;
			set;
		}

		public string Total
		{
			get;
			set;
		}

		public string VariantSku
		{
			get;
			set;
		}

        public string Image
        {
            get;
            set;
        }

        public OrderlineViewModel()
		{
		}
	}
}