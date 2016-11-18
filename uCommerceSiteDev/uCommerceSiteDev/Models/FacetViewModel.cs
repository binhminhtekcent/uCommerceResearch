using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
	public class FacetViewModel
	{
		public string DisplayName
		{
			get;
			set;
		}

		public IList<FacetValueViewModel> FacetValues
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public FacetViewModel()
		{
			this.FacetValues = new List<FacetValueViewModel>();
		}
	}
}