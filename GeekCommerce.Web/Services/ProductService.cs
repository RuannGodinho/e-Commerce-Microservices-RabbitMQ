﻿using GeekCommerce.Web.Models;
using GeekCommerce.Web.Services.IServices;
using GeekCommerce.Web.Utils;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekCommerce.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client /*?? throw new ArgumentNullException(nameof )*/;
        }

        public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindProductsById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<ProductViewModel>();
        }
        public async Task<ProductViewModel> CreateProduct(ProductViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong when calling API");
        }


    }
}
