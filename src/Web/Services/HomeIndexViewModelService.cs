using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class HomeIndexViewModelService : IHomeIndexViewModelService
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Brand> _brandRepository;
        private readonly IAsyncRepository<Product> _productRepository;

        public HomeIndexViewModelService(IAsyncRepository<Category> categoryRepository, IAsyncRepository<Brand> brandRepository, IAsyncRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _productRepository = productRepository;
        }

        public async Task<List<SelectListItem>> GetBrands()
        {
            var brands = await _brandRepository.ListAllAsync();

            var items = brands.Select(x => new SelectListItem() { Text = x.BrandName, Value = x.Id.ToString() })
                .OrderBy(x=>x.Text)
                .ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            items.Insert(0,allItem);

            return items;
        }

        public async Task<List<SelectListItem>> GetCategories()
        {
            var categories = await _categoryRepository.ListAllAsync();

            var items = categories.Select(x => new SelectListItem() { Text = x.CategoryName, Value = x.Id.ToString() })
                .OrderBy(x => x.Text)
                .ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All" ,Selected=true};
            items.Insert(0,allItem);

            return items;
        }

        public async Task<HomeIndexViewModel> GetHomeIndexViewModel(int? categoryId, int? brandId)
        {
            var vm = new HomeIndexViewModel
            {
                Categories = await GetCategories(),
                Brands = await GetBrands(),
                Products = await _productRepository.ListAsync(x =>
                    (!categoryId.HasValue || x.CategoryId == categoryId) && (!brandId.HasValue || x.BrandId == brandId)),
                CategoryId = categoryId,
                BrandId = brandId
            };

            return vm;
        }
    }
}
