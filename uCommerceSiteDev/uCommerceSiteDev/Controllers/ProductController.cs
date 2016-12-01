using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uCommerceSiteDev.Common;
using uCommerceSiteDev.Models;
using umbraco.presentation.umbraco;
using umbraco.providers.members;
using UCommerce.Api;
using UCommerce.Content;
using UCommerce.EntitiesV2;
using UCommerce.Extensions;
using UCommerce.Infrastructure;
using UCommerce.Runtime;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace uCommerceSiteDev.Controllers
{
    public class ProductController : RenderMvcController
    {
        // GET: Product
        public ActionResult Index(RenderModel model)
        {
            var productViewModel = RenderView();
            return View("/Views/Product.cshtml", productViewModel);
        }

        private ProductViewModel RenderView()
        {
            Product currentProduct = SiteContext.Current.CatalogContext.CurrentProduct;

            ProductViewModel productsViewModel = new ProductViewModel()
            {
                Sku = currentProduct.Sku,
                PriceCalculation = CatalogLibrary.CalculatePrice(currentProduct, null),
                Name = ProductExtensions.DisplayName(currentProduct),
                LongDescription = ProductExtensions.LongDescription(currentProduct),
                IsVariant = false,
                IsOrderingAllowed = currentProduct.AllowOrdering,
                TaxCalculation = CatalogLibrary.CalculatePrice(currentProduct, null).YourTax.ToString()
            };

            var images = currentProduct.GetPropertyValue<string>("Images");
            if (!string.IsNullOrEmpty(images))
            {
                foreach (var image in currentProduct.GetPropertyValue<string>("Images").Split(','))
                {
                    productsViewModel.Images.Add(UnitHelper.PrimaryImageMediaIdToUrl(image));
                }
            }

            productsViewModel.ThumbnailImageUrl =
               UnitHelper.PrimaryImageMediaIdToUrl(currentProduct.PrimaryImageMediaId);

            return productsViewModel;
        }

        private IList<ProductPropertiesViewModel> MapProductProperties(Product product)
        {
            List<ProductPropertiesViewModel> productPropertiesViewModels = new List<ProductPropertiesViewModel>();
            foreach (
                IGrouping<ProductDefinitionField, ProductProperty> productDefinitionFields in
                    product.Variants.SelectMany<Product, ProductProperty>((Product p) => p.ProductProperties)
                        .Where<ProductProperty>(
                            (ProductProperty v) => v.ProductDefinitionField.DisplayOnSite)
                        .GroupBy<ProductProperty, ProductDefinitionField>(
                            (ProductProperty v) => v.ProductDefinitionField)
                        .Select
                        <IGrouping<ProductDefinitionField, ProductProperty>,
                            IGrouping<ProductDefinitionField, ProductProperty>>(
                                (IGrouping<ProductDefinitionField, ProductProperty> g) => g))
            {
                ProductPropertiesViewModel productPropertiesViewModel = new ProductPropertiesViewModel()
                {
                    PropertyName = productDefinitionFields.Key.Name
                };
                foreach (string str in (
                    from p in productDefinitionFields
                    select p.Value).Distinct<string>())
                {
                    productPropertiesViewModel.Values.Add(str);
                }
                productPropertiesViewModels.Add(productPropertiesViewModel);
            }
            return productPropertiesViewModels;
        }

        private IList<ProductViewModel> MapVariants(ICollection<Product> variants)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product variant in variants)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    Sku = variant.Sku,
                    VariantSku = variant.VariantSku,
                    Name = ProductExtensions.DisplayName(variant),
                    LongDescription = ProductExtensions.LongDescription(variant),
                    IsVariant = true
                };
                productViewModels.Add(productViewModel);
            }
            return productViewModels;
        }
    }
}