using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCommerce.Content;
using UCommerce.Infrastructure;
using UCommerce.Runtime;
using Umbraco.Core;

namespace uCommerceSiteDev.Common
{
    public class Helper
    {
        public static string PrimaryImageMediaIdToUrl(string primaryImageMediaId)
        {
            if (string.IsNullOrEmpty(primaryImageMediaId)) return string.Empty;

            return ObjectFactory.Instance.Resolve<IImageService>().GetImage(primaryImageMediaId).Url;
        }

    }
}