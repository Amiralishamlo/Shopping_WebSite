using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Models.ViewModels.Menu
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public   List<MenuViewModel>  SubMenu { get; set; }
    }
}
