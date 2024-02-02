using Application.Catalogs.CatalogItems.UnComposer;
using Application.Interfaces.Contexts;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.BasketsService
{
    public interface IBasketsService
    {
        BasketsDto GetOrCreateBasketForUser(string BuyerId);
    }
    public class BasketsService : IBasketsService
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IUriComposerService _uriComposerService;
        public BasketsService(IDataBaseContext dataBaseContext, IUriComposerService uriComposerService)
        {
            _dataBaseContext = dataBaseContext;
            _uriComposerService = uriComposerService;
        }

        public BasketsDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket=_dataBaseContext.Baskets
                .Include(x=>x.Items)
                .ThenInclude(x=>x.CatalogItem)
                .ThenInclude(x=>x.CatalogItemImages)
                .Where(x=>x.BuyerId == BuyerId).SingleOrDefault();
            if(basket == null)
            {
                return CreateBasketForUser(BuyerId);
            }
            return new BasketsDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                basketItems = basket.Items.Select(item => new BasketItemsDto
                {
                    CatalogItemId = item.CatalogItemId,
                    CatalogName = item.CatalogItem.Name,
                    Id = item.Id,
                    ImageUrl = _uriComposerService.ComposeImageUri(item?.CatalogItem?.CatalogItemImages?.FirstOrDefault()?.Src??""),
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                }).ToList()
            };
        }
        private BasketsDto CreateBasketForUser(string BuyerId)
        {
            var basket = new Basket(BuyerId);
            _dataBaseContext.Baskets.Add(basket);
            _dataBaseContext.SaveChanges();
            return new BasketsDto
            {
                BuyerId= basket.BuyerId,
                Id = basket.Id,
            };
        }
    }

    public class BasketsDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemsDto> basketItems { get; set; }

    }
    public class BasketItemsDto
    {
        public int Id { get; set; }
        public int CatalogItemId { get; set;}
        public string CatalogName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
