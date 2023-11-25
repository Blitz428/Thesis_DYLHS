using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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