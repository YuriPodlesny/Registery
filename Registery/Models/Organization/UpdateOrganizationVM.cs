﻿using System.ComponentModel.DataAnnotations;

namespace Registery.Models.Organization
{
    public class UpdateOrganizationVM
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Название организации")]
        public required string Name { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public required string INN { get; set; }
        [Required]
        [Display(Name = "Номер района")]
        public Guid DistrictNumberId { get; set; }
    }
}
