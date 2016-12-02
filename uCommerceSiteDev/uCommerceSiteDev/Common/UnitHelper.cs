using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCommerce.Api;
using UCommerce.Content;
using UCommerce.EntitiesV2;
using UCommerce.Infrastructure;
using UCommerce.Runtime;
using Umbraco.Core;
using Constants = UCommerce.Constants;

namespace uCommerceSiteDev.Common
{
    public class UnitHelper
    {
        public static string PrimaryImageMediaIdToUrl(string primaryImageMediaId)
        {
            if (string.IsNullOrEmpty(primaryImageMediaId)) return string.Empty;

            return ObjectFactory.Instance.Resolve<IImageService>().GetImage(primaryImageMediaId).Url;
        }

        public static PriceCalculation GetPrice(Product product)
        {
            if (product == null) return null;

            return UCommerce.Api.CatalogLibrary.CalculatePrice(product);
        }
    }
}