using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model
{
    public interface KalenderListItem
    {
        Boolean IsHeader();
    }

    public class KalenderHeaderItem : KalenderListItem
    {
        public bool IsHeader()
        {
            return true;
        }

        public DateTime Date { get; set; }
    }
}
