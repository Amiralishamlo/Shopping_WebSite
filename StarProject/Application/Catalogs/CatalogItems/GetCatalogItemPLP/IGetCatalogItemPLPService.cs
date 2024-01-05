using Application.Catalogs.CatalogItems.UnComposer;
using Application.Dtos;
using Application.Interfaces.Contexts;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Catalogs.CatalogItems.GetCatalogItemPLP
{
    public interface IGetCatalogItemPLPService
    {
        PaginatedItemsDto<CatalogPLPDto> Execute(int page,int pageSize);
    }
    public class GetCatalogItemPLPService: IGetCatalogItemPLPService
    {
        private readonly IDataBaseContext _context;
        private readonly IUriComposerService _uriComposer;

        public GetCatalogItemPLPService(IDataBaseContext context, IUriComposerService uriComposer)
        {
            _context = context;
            _uriComposer = uriComposer;
        }

        public PaginatedItemsDto<CatalogPLPDto> Execute(int page, int pageSize)
        {
            int rowCount = 0;
            var data = _context.CatalogItems.Include(x => x.CatalogItemImages)
                .OrderByDescending(x => x.Id)
                .PagedResult(page, pageSize, out rowCount)
                .Select(x => new CatalogPLPDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Rate = 4,
                    Image = _uriComposer.ComposeImageUri(x.CatalogItemImages.FirstOrDefault().Src)
                }).ToList();
            return new PaginatedItemsDto<CatalogPLPDto>(page,pageSize,rowCount,data);
        }
    }
    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
    }
}
