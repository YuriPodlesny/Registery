using Registry.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Domain.Entities
{
    public class OMSStatus : BaseEntity
    {
        public string? Value { get; set; }

        public IList<Form> Forms { get; } = new List<Form>();
    }
}
