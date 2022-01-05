using System;
using System.ComponentModel.DataAnnotations;
using ChargePointer.Infrastructure.Domain.Entities;

namespace ChargePointer.Core.RequestModels
{
    public class LocationRequestModel
    {
        [Required]
        [StringLength(39, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string LocationId { get; set; }
        
        [Required]
        [RegularExpression("Parking|Airport|OnStreet|Unknown")]
        public string Type { get; set; }
        
        [StringLength(255, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(45, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Address { get; set; }
        
        [Required]
        [StringLength(45, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string City { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string PostalCode { get; set; }
        
        [Required]
        [StringLength(45, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Country { get; set; }
        
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}