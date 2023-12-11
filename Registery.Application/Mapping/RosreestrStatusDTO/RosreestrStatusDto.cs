using Registery.Application.Mapping.DistrictNumberDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.Mapping.RosreestrStatusDTO
{
    public class RosreestrStatusDto : IComparable
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
        public bool Delete { get; set; } = false;
        public int CompareTo(object? obj)
        {
            if ((obj == null) || (!(obj is RosreestrStatusDto)))
                return 0;
            else
                return string.Compare(Value, ((RosreestrStatusDto)obj).Value);
        }
    }
}
