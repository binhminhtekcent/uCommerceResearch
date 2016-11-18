using System;
using System.Runtime.CompilerServices;
using UCommerce;

namespace uCommerceSiteDev.Models
{
	public class MiniBasketViewModel
	{
		public bool IsEmpty
		{
			get;
			set;
		}

		public int NumberOfItems
		{
			get;
			set;
		}

		public Money Total
		{
			get;
			set;
		}

		public MiniBasketViewModel()
		{
		}
	}
}