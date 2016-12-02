using System;
using System.Runtime.CompilerServices;

namespace uCommerceSiteDev.Models
{
    public class AddToBasketViewModel
    {
        public string Sku
        {
            get;
            set;
        }

        public string VariantSku
        {
            get;
            set;
        }

        public int Quality
        {
            get;
            set;
        }

        public AddToBasketViewModel()
        {
            Quality = 1;
        }
    }
}