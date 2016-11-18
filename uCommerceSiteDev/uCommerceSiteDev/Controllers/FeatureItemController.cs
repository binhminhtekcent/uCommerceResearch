using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uCommerceSiteDev.Models;
using UCommerce.Api;
using UCommerce.Content;
using UCommerce.EntitiesV2;
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
            IEnumerable<Product> products = SiteContext.Current.CatalogContext.CurrentCatalog.Categories.SelectMany<Category, Product>((Category c) =>
                from p in c.Products
                where p.ProductProperties.Any<ProductProperty>((ProductProperty pp) =>
                {
                    if (pp.ProductDefinitionField.Name != "ShowOnHomepage")
                    {
                        return false;
                    }
                    return Convert.ToBoolean(pp.Value);
                })
                select p);
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
                    ThumbnailImageUrl = ObjectFactory.Instance.Resolve<IImageService>().GetImage(product.ThumbnailImageMediaId).Url
                });
            }
            return View("/Views/FeatureItem.cshtml", productsViewModel);
        }
    }
}