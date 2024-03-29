﻿using Registry.Domain.Entities.Base;

namespace Registry.Domain.Entities
{
    public class DistrictNumber : BaseEntity
    {
        public string? Value { get; set; }
        public bool Delete { get; set; } = false;

        public IList<Organization>? Organizations { get; } = new List<Organization>();
        public IList<Form>? Forms { get; } = new List<Form>();
    }
}
