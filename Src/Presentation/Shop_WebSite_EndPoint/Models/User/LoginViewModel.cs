using System.ComponentModel.DataAnnotations;

namespace Shop_WebSite_EndPoint.Models.User
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "لطفا ایمیل خود را وارد نمایید")]
		[Display(Name = "ایمیل")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "لطفا پسورد خود را وارد نمایید")]
		[Display(Name = "پسورد")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = " من را به خاطر بسپار")]
		public bool IsPersistent { get; set; } = false;

		public string ReturnUrl { get; set; }
	}
}
