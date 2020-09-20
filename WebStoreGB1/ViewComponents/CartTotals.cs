using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB1.Infrastructure.Interfaces;
using WebStoreGB1.ViewModels;

namespace WebStoreGB1.ViewComponents
{
    public class CartTotals : ViewComponent
    {
        private readonly IProductService _productService;

        public CartTotals(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sums = CalcSums();
            return View(sums);
        }

        private CartViewModel CalcSums()
        {
            return new CartViewModel();

        }

    }
}
