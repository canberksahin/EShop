﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                .OrderBy(x => x.Text)
                .ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            items.Insert(0, allItem);

            return items;
        }

        public async Task<List<SelectListItem>> GetCategories()
        {
            var categories = await _categoryRepository.ListAllAsync();

            var items = categories.Select(x => new SelectListItem() { Text = x.CategoryName, Value = x.Id.ToString() })
                .OrderBy(x => x.Text)
                .ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            items.Insert(0, allItem);

            return items;
        }

        public async Task<HomeIndexViewModel> GetHomeIndexViewModel(int pageIndex, int itemsPerPage,int? categoryId, int? brandId)
        {
            int totalItems = await _productRepository.CountAsync(new ProductsFilterSpecification(categoryId, brandId));
            var products = await _productRepository.ListAsync(
                new ProductsFilterPaginatedSpecification(
                    (pageIndex - 1) * itemsPerPage,
                    itemsPerPage,
                    categoryId,
                    brandId)
                );


            var vm = new HomeIndexViewModel
            {
                Categories = await GetCategories(),
                Brands = await GetBrands(),
                Products = products
                    .Select(x => new ProductViewModel()
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        Description = x.Description,
                        UnitPrice = x.UnitPrice,
                        Photo = string.IsNullOrEmpty(x.Photo) ? "no-product-image.png" : x.Photo
                    }).ToList(),
                CategoryId = categoryId,
                BrandId = brandId,
                PaginationInfo = new PaginationInfoViewModel
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling((decimal)totalItems/itemsPerPage),
                    CurrentPage = totalItems == 0 ? 0 : pageIndex,
                    ItemsOnPage = products.Count
                }
            };
            vm.PaginationInfo.Previous = vm.PaginationInfo.CurrentPage <= 1 ? "disabled" : "";
            vm.PaginationInfo.Next = vm.PaginationInfo.CurrentPage >= vm.PaginationInfo.TotalPages ? "disabled" : "";
            return vm;
        }
    }
}
