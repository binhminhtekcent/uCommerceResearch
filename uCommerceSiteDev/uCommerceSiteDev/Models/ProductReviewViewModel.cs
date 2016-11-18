using System;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
	public class ProductReviewViewModel
	{
		public string Comments
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public int? Rating
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public ProductReviewViewModel()
		{
		}
	}
}