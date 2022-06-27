using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Helpers.UIModels
{
    public class MenuItemModel
    {
        public string Modulo { get; set; }
        public string Page { get; set; }
        public string Icon { get; set; }
        public bool HasChildrens { get; set; } = false;
        public MenuItemModel Childrens { get; set; }
    }
}
