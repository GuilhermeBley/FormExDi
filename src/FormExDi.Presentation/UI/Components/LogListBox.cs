using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormExDi.Presentation.UI.Components
{
    public partial class LogListBox : ListBox
    {
        public const int MAX_TIMER_TICK_REFRESH = 500;
        public const int MAX_ROW_VIEW = int.MaxValue;
        public const int MAX_CHARACTERS_PER_ROW = 2000;
        public const int DEFAULT_MAX_VIEW = 500;
        private Func<IEnumerable<string>>? _getData { get; set; }

        private int _maxView { get; set; } = DEFAULT_MAX_VIEW;
        private bool _lockOnLast { get; set; } = true;

        public bool LockOnLast { get => _lockOnLast; set {

                if (value == _lockOnLast)
                    return;
                
                if (value == true)
                {
                    ScrollAlwaysVisible = false;
                    _lockOnLast = value;
                    return;
                }

                ScrollAlwaysVisible = true;
                _lockOnLast = value;
            } }

        public LogListBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void SetGetData(Func<IEnumerable<string>> getData)
        {
            if (getData is not null)
                _getData = getData;
        }

        private void TimerLog_Tick(object sender, EventArgs eventArgs)
        {
            if (_getData is null)
                return;
            if (_maxView > MAX_ROW_VIEW || _maxView < 1)
                _maxView = MAX_ROW_VIEW;

            var itemsToAdd = _getData().Reverse().TakeWhile(t => !IsLastItem(t)).ToList();
            foreach (var item in itemsToAdd)
            {
                while (Items.Count >= _maxView)
                    Items.RemoveAt(0);

                Items.Add(item);

                if (!_lockOnLast)
                    continue;

                TopIndex = Items.Count - 1;
            }
        }

        private bool IsLastItem(object obj)
        {
            if (Items.Count < 1)
                return false;

            var item = Items[Items.Count - 1];

            return item.Equals(obj);
        }
    }
}
