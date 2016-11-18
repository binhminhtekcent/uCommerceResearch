using System;
using System.Collections.Generic;
using System.Web.Mvc;
using uCommerceSiteDev.Models;
using UCommerce.Api;
using UCommerce.EntitiesV2;
using UCommerce.Extensions;
using Umbraco.Web.Mvc;
namespace uCommerceSiteDev.Controllers
{
    public class NavigationController : Controller
    {
        public ActionResult Index()
        {
            CategoryNavigationViewModel categoryNavigationViewModel = new CategoryNavigationViewModel();
            //int? nullable = null;
            //categoryNavigationViewModel.Categories = this.MapCategories(CatalogLibrary.GetRootCategories(nullable));
            categoryNavigationViewModel.Categories = this.MapCategories(CatalogLibrary.GetRootCategories());
            return View("/views/Navigation.cshtml", categoryNavigationViewModel);
        }

        private IList<CategoryViewModel> MapCategories(ICollection<Category> categoriesToMap)
        {
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            foreach (Category category in categoriesToMap)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel()
                {
                    Name = CategoryExtensions.DisplayName(category),
                    Url = CatalogLibrary.GetNiceUrlForCategory(category, null),
                    Categories = this.MapCategories(CatalogLibrary.GetCategories(category))
                };
                categoryViewModels.Add(categoryViewModel);
            }
            return categoryViewModels;
        }
    }
}