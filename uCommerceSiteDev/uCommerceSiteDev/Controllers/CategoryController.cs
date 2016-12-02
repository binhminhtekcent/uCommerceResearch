using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using uCommerceSiteDev.Common;
using uCommerceSiteDev.Models;
using UCommerce.Api;
using UCommerce.Content;
using UCommerce.EntitiesV2;
using Umbraco.Web.Mvc;
using UCommerce.Extensions;
using UCommerce.Infrastructure;
using UCommerce.Runtime;
using UCommerce.Search.Facets;
using Umbraco.Web.Models;


namespace uCommerceSiteDev.Controllers
{
    public class CategoryController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var currentCategory = SiteContext.Current.CatalogContext.CurrentCategory;

            var categoryViewModel = new CategoryViewModel
            {
                Name = currentCategory.DisplayName(),
                Description = currentCategory.Description(),
                CatalogId = currentCategory.ProductCatalog.Id,
                CategoryId = currentCategory.Id,
                Products = MapProductsInCategories(currentCategory)
            };


            if (!HasBannerImage(currentCategory))
            {
                var media = UnitHelper.PrimaryImageMediaIdToUrl(currentCategory.ImageMediaId);
                categoryViewModel.BannerImageUrl = media;
            }

            return View("/Views/Catalog.cshtml", categoryViewModel);
        }

        private bool HasBannerImage(Category category)
        {
            return string.IsNullOrEmpty(category.ImageMediaId);
        }

        private IList<ProductViewModel> MapProducts(ICollection<UCommerce.Documents.Product> productsInCategory)
        {
            IList<ProductViewModel> productViews = new List<ProductViewModel>();
            var listSku = productsInCategory.Select(x => x.Sku).ToList();
            var productList = Product.All().Where(x => listSku.Contains(x.Sku));
            foreach (var product in productList)
            {
                var productViewModel = new ProductViewModel
                {
                    Sku = product.Sku,
                    Url = CatalogLibrary.GetNiceUrlForProduct(product),
                    Name = product.Name,
                    PriceCalculation = UnitHelper.GetPrice(product),
                    ThumbnailImageUrl = UnitHelper.PrimaryImageMediaIdToUrl(product.PrimaryImageMediaId)
                };

                productViews.Add(productViewModel);
            }

            return productViews;
        }

        private IList<ProductViewModel> MapProductsInCategories(Category category)
        {
            IList<Facet> facetsForQuerying = System.Web.HttpContext.Current.Request.QueryString.ToFacets();
            var productsInCategory = new List<ProductViewModel>();

            foreach (var subcategory in category.Categories)
            {
                productsInCategory.AddRange(MapProductsInCategories(subcategory));
            }

            productsInCategory.AddRange(MapProducts(SearchLibrary.GetProductsFor(category, facetsForQuerying)));

            return productsInCategory;
        }
    }

}