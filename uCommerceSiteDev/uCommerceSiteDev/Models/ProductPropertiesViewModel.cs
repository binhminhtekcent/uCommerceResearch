using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
	public class ProductPropertiesViewModel
	{
		public string PropertyName
		{
			get;
			set;
		}

		public IList<string> Values
		{
			get;
			set;
		}

		public ProductPropertiesViewModel()
		{
			this.Values = new List<string>();
		}
	}
}