using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
    public class CategoryTabController : SurfaceController
    {
        // GET: CategoryTab
        public ActionResult Index()
        {
            CategoryNavigationViewModel categoryNavigationViewModel = new CategoryNavigationViewModel();
            categoryNavigationViewModel.Categories = this.MapCategories(CatalogLibrary.GetRootCategories());
            return View("/views/CategoryTab.cshtml", categoryNavigationViewModel);
        }

        private IList<CategoryViewModel> MapCategories(ICollection<Category> categoriesToMap)
        {
            IList<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            foreach (Category category in categoriesToMap)
            {
                List<ProductViewModel> productList = new List<ProductViewModel>();

                IEnumerable<Product> products = SiteContext.Current.CatalogContext.CurrentCatalog.Categories.SelectMany<Category, Product>((Category c) =>
                    from p in c.Products
                    where p.GetCategories().Contains(category)
                    select p).Distinct();
                foreach (var product in products)
                {
                    productList.Add(new ProductViewModel
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

                CategoryViewModel categoryViewModel = new CategoryViewModel()
                {
                    Name = CategoryExtensions.DisplayName(category),
                    Url = CatalogLibrary.GetNiceUrlForCategory(category, null),
                    Categories = null,
                    Products = productList
                };
                categoryViewModels.Add(categoryViewModel);
            }
            return categoryViewModels;
        }
    }
}