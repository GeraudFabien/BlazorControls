using System;
using System.Collections.Generic;
using System.Text;

namespace Razor.Controls.Models
{
    internal class ItemControlContext<T> : IItemControlContext<T>
    {
        public ItemControlContext(T item, int alternationCount)
        {
            this.Item = item;
            this.AlternationCount = alternationCount;
        }

        public T Item { get; }
        public int? AlternationCount { get; }
    }
}
