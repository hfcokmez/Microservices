using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models.ViewModels.Baskets;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SaveOrUpdate(BasketViewModel basketViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<BasketViewModel>("baskets", basketViewModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<BasketViewModel> Get()
        {
            var response = await _httpClient.GetAsync("baskets");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }                
            var basketViewModel = await response.Content.ReadFromJsonAsync<Response<BasketViewModel>>();
            return basketViewModel.Data;
        }

        public async Task<bool> Delete()
        {
            var response = await _httpClient.DeleteAsync("baskets");
            return response.IsSuccessStatusCode;
        }

        public Task AddBasketItem(BasketItemViewModel basketItemViewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> RemoveBasketItem(string courseId)
        {
            var basket = await Get();
            if (basket == null)
            {
                return false;
            }

            var deleteBasketItem = basket.BasketItems.FirstOrDefault(x => x.CourseId == courseId);
            if (deleteBasketItem == null)
            {
                return false;
            }
            var deleteResult = basket.BasketItems.Remove(deleteBasketItem);
            if (!deleteResult)
            {
                return false;
            }

            if (basket.BasketItems.Any())
            {
                basket.DiscountCode = null;
            }
            return  await SaveOrUpdate(basket);
        }

        public Task<bool> ApplyDiscount(string discountCode)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CancelAppliedDiscount()
        {
            throw new System.NotImplementedException();
        }
    }
}