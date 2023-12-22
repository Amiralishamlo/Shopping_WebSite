using AutoMapper;
using Common;
using Shop.Application.Dtos;
using Shop.Application.Interfaces.Contexts;
using Shop.Domain.Catalogs;

namespace Shop.Application.Catalogs.CatalogTypes.CrudService
{
    public class CatalogService : ICatalogService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public CatalogService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var model = _mapper.Map<CatalogType>(catalogType);
            _context.CatalogTypes.Add(model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(_mapper.Map<CatalogTypeDto>(model), new List<string> { $"تایپ {model.Type}  با موفقیت در سیستم ثبت شد" }, true);
        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var model = _context.CatalogTypes.SingleOrDefault(x => x.Id == catalogType.Id);
            _mapper.Map(catalogType, model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(_mapper.Map<CatalogTypeDto>(model), new List<string> { $"تایپ {model.Type} با موفقیت ویرایش شد" }, true);
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            var data = _context.CatalogTypes.Find(Id);
            var result = _mapper.Map<CatalogTypeDto>(data);
            return new BaseDto<CatalogTypeDto>(result, null, true);
        }

        public PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
        {
            int totalCount = 0;
            var model = _context.CatalogTypes
                .Where(p => p.ParentCatalogTypeId == parentId)
                .PagedResult(page, pageSize, out totalCount);
            var result = _mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PaginatedItemsDto<CatalogTypeListDto>(page, pageSize, totalCount, result);
        }

        public BaseDto Remove(int Id)
        {
            var model = _context.CatalogTypes.Find(Id);
            _context.CatalogTypes.Remove(model);
            _context.SaveChanges();
            return new BaseDto(new List<string> { $"ایتم با موفقیت حذف شد" }, true);
        }
    }
}
