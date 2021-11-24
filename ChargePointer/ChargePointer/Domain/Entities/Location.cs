using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChargePointer.Domain.Entities
{
    public class Location
    {
        [Required]
        [StringLength(39, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]  
        public string LocationId { get; set; }

        public Type Type { get; set; }

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
        
        public List<ChargePoint> ChargePoints { get; set; }
        
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}