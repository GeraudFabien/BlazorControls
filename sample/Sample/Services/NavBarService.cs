using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Sample.Services
{
    public class NavBarService
    {
        public bool IsVisible { get; set; }

        public ICollection<NavBarItem> Items { get; } = new ObservableCollection<NavBarItem>();
    }
}
