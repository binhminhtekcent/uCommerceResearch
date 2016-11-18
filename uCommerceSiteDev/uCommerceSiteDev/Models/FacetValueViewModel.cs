using System;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
	public class FacetValueViewModel
	{
		public int FacetValueHits
		{
			get;
			set;
		}

		public string FacetValueName
		{
			get;
			set;
		}

		public FacetValueViewModel(string name, int hits)
		{
			this.FacetValueName = name;
			this.FacetValueHits = hits;
		}
	}
}