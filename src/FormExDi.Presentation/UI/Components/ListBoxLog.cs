using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Collections.ObjectModel;

namespace FormExDi.Presentation.UI.Components
{
    public delegate IEnumerable<string> GetDataDelegate();
    public class ListBoxLog : ListBox
    {
        public const int MAX_TIMER_TICK_REFRESH = 500;
        public const int MAX_ROW_VIEW = int.MaxValue;
        public const int MAX_CHARACTERS_PER_ROW = 2000;
        public const int DEFAULT_MAX_VIEW = 1000;
        private GetDataDelegate _getData { get; }

        public ListBoxLog() 
            : this(() => Enumerable.Empty<string>()) { }

        public ListBoxLog(GetDataDelegate getData)
            : base()
        {
            _getData = getData;
        }

        public void Refresh(int skip = 0, int take = DEFAULT_MAX_VIEW)
        {
            if (skip < 0)
                skip = 0;
            if (take > MAX_ROW_VIEW)
                take = MAX_ROW_VIEW;
            Items.Clear();

            var enumerable = _getData().Reverse().Skip(skip).Take(take);
            foreach (var item in enumerable)
            {
                var itemAdd = item;
                if (item.Length > MAX_CHARACTERS_PER_ROW)
                    itemAdd = string.Concat(item.Take(MAX_CHARACTERS_PER_ROW));
                Items.Add(itemAdd);
            }
        }

        public void Add(int max = DEFAULT_MAX_VIEW)
        {
            if (max > MAX_ROW_VIEW)
                max = MAX_ROW_VIEW;

            while (Items.Count > max)
                Items.RemoveAt(0);

            Items.Add(_getData().Last());
        }
    }
}
