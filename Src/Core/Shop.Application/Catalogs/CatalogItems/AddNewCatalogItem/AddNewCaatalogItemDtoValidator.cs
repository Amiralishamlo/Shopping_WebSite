using FluentValidation;

namespace Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public class AddNewCaatalogItemDtoValidator : AbstractValidator<AddNewCaatalogItemDto>
	{
        public AddNewCaatalogItemDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("نام کاتالوگ اجباری است");
            RuleFor(x => x.Name).Length(2, 100);
            RuleFor(x => x.Description).NotNull().WithMessage("توضیحات نمی تواند خالی باشد");
            RuleFor(x => x.AvailableStock).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Price).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Price).NotNull();
        }
    }
} 
 