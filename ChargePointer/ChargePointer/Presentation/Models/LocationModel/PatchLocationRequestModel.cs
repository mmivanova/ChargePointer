using System;
using System.ComponentModel.DataAnnotations;

namespace ChargePointer.Presentation.Models.LocationModel
{
    public class PatchLocationRequestModel 
    {
        [Required]
        [StringLength(39, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string LocationId { get; set; }
        
        [StringLength(45, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Type { get; set; }
        
        [StringLength(255, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }
        
        [StringLength(45, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Address { get; set; }
        
        [StringLength(45, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string City { get; set; }
        
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string PostalCode { get; set; }
        
        [StringLength(45, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Country { get; set; }
        
        public DateTime LastUpdated { get; set; } 
    }
}