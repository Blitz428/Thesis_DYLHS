using System;

namespace Thesis.Pages
{
    public class main_menuFlyoutMenuItem
    {
        public main_menuFlyoutMenuItem()
        {
            TargetType = typeof(main_menuFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}