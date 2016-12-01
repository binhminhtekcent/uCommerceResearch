using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uCommerceSiteDev.Common;
using uCommerceSiteDev.Models;
using UCommerce.Api;
using UCommerce.Content;
using UCommerce.EntitiesV2;
using UCommerce.Extensions;
using UCommerce.Infrastructure;
using UCommerce.Runtime;
using Umbraco.Web.Mvc;

namespace uCommerceSiteDev.Controllers
{
    public class FeatureItemController : SurfaceController
    {
        // GET: FeatureItem
        public ActionResult Index()
        {
            //IEnumerable<Product> products = SiteContext.Current.CatalogContext.CurrentCatalog.Categories.SelectMany<Category, Product>((Category c) =>
            //    from p in c.Products
            //    where p.ProductProperties.Any<ProductProperty>((ProductProperty pp) =>
            //    {
            //        if (pp.ProductDefinitionField.Name != "ShowOnHomepage")
            //        {
            //            return false;
            //        }
            //        return Convert.ToBoolean(pp.Value);
            //    })
            //    select p);

            IEnumerable<Product> products =
                SiteContext.Current.CatalogContext.CurrentCatalog.Categories.SelectMany<Category, Product>(
                    (Category c) =>
                        from p in c.Products select p).Distinct();
            ProductsViewModel productsViewModel = new ProductsViewModel();
            foreach (Product product in products)
            {
                productsViewModel.Products.Add(new ProductViewModel()
                {
                    Name = product.Name,
                    PriceCalculation = CatalogLibrary.CalculatePrice(product, null),
                    Url = CatalogLibrary.GetNiceUrlForProduct(product, null, null),
                    Sku = product.Sku,
                    IsVariant = product.IsVariant,
                    VariantSku = product.VariantSku,
                    ThumbnailImageUrl = UnitHelper.PrimaryImageMediaIdToUrl(product.ThumbnailImageMediaId)
                });

                //var images = product.GetPropertyValue<string>("Images");
                //if (!string.IsNullOrEmpty(images))
                //{
                //    foreach (var image in product.GetPropertyValue<string>("Images").Split(';'))
                //    {
                //        var test = image;
                //    }
                //}
            }
            return View("/Views/FeatureItem.cshtml", productsViewModel);
        }
    }
}