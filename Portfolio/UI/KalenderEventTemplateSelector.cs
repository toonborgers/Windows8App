using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Portfolio.Model;

namespace Portfolio.UI
{
    class KalenderEventTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeaderTemplate { get; set; }
        public DataTemplate ItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var kalenderListItem = (KalenderListItem)item;
            return kalenderListItem.IsHeader() ? HeaderTemplate : ItemTemplate;
        }
    }
}
