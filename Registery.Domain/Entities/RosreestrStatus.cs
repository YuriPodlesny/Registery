using Registry.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Domain.Entities
{
    public class RosreestrStatus : BaseEntity
    {
        public string? Value { get; set; }

        public IList<Form> Forms { get; set; } = new List<Form>();
    }
}
