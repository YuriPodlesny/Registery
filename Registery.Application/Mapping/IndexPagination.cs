using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.Mapping
{
    public class IndexPagination<T> 
        where T : class
    {
        public IEnumerable<T> Model { get; set; }
        public PageModel PageViewModel { get; set; }
    }
}
