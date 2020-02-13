using System;
using System.Collections.Generic;
using System.Text;

namespace Razor.Controls.Models
{
    public interface IItemControlContext<T>
    {
        T Item { get; }
        int? AlternationCount { get; }
    }
}
