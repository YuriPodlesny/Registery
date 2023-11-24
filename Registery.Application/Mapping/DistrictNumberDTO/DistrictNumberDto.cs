using System.Xml.Linq;
using System;

namespace Registery.Application.Mapping.DistrictNumberDTO
{
    public class DistrictNumberDto : IComparable
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
        public bool Delete { get; set; }

        public int CompareTo(object? obj)
        {
            if ((obj == null) || (!(obj is DistrictNumberDto)))
                return 0;
            else
                return string.Compare(Value, ((DistrictNumberDto)obj).Value);
        }
    }
}
