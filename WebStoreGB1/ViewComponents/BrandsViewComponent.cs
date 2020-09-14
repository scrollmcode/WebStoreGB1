using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB1.Infrastructure.Interfaces;
using WebStoreGB1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebStoreGB1.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Brands = GetBrands();
            return View(Brands);
        }

        private List<BrandViewModel> GetBrands()
        {
            var brands = _productService.GetBrands();

            var componentBrands = new List<BrandViewModel>();
            foreach (var parentCategory in brands)
            {
                componentBrands.Add(new BrandViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order
                });
            }

            componentBrands = componentBrands.OrderBy(c => c.Order).ToList();
            return componentBrands;
        }

    }
}
