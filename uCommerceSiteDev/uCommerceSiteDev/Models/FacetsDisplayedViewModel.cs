using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
	public class FacetsDisplayedViewModel
	{
		public IList<FacetViewModel> Facets
		{
			get;
			set;
		}

		public FacetsDisplayedViewModel()
		{
			this.Facets = new List<FacetViewModel>();
		}
	}
}