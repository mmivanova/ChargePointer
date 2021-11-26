using System;
using System.ComponentModel.DataAnnotations;

namespace ChargePointer.Domain.Entities
{
    public class ChargePoint
    {
        [Required]
        [StringLength(39, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string ChargePointId { get; set; }

        [Required]
        public Status Status { get; set; }
        
        [StringLength(4, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FloorLevel { get; set; }
        
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}