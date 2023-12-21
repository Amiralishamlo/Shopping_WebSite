using System.ComponentModel.DataAnnotations;

namespace Shop_Admin_EndPoint.ViewModels.Catalogs
{
    public class CatalogTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام دسته بندی")]
        [Required]
        [MaxLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد")]
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
    }
}
