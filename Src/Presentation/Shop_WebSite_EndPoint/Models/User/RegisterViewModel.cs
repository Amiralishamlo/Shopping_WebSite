using System.ComponentModel.DataAnnotations;

namespace Shop_WebSite_EndPoint.Models.User
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "نام و نام خانوادگی را وارد نمایید")]
		[Display(Name = "نام و نام خانوادگی")]
		[MaxLength(100, ErrorMessage = "نام و نام خانوادگی نباید بیش از 100 کاراکتر باشد")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "ایمیل را وارد نمایید")]
		[EmailAddress]
		[Display(Name = "ایمیل")]
		public string Email { get; set; }


		[Required(ErrorMessage = "پسورد را وارد نمایید")]
		[DataType(DataType.Password)]
		[Display(Name = "پسورد")]
		public string Password { get; set; }

		[Required(ErrorMessage = "تکرار پسورد را وارد نمایید")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "پسورد و تکرار آن باید برابر باشد")]
		[Display(Name = "تکرار پسورد")]
		public string RePassword { get; set; }
        [Display(Name = "شماره تلفن")]

        public string PhoneNumber { get; set; }
	}
}
