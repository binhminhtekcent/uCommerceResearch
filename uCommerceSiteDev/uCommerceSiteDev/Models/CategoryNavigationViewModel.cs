using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
	public class CategoryNavigationViewModel
	{
		public IList<CategoryViewModel> Categories
		{
			get;
			set;
		}

		public CategoryNavigationViewModel()
		{
			this.Categories = new List<CategoryViewModel>();
		}
	}
}