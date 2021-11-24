using System;
using System.ComponentModel.DataAnnotations;

namespace ChargePointer.Domain.Entities
{
    public class ChargePoint
    {
        [Required]
        public string ChargePointId { get; set; }

        public Status Status { get; set; }
        
        public string FloorLevel { get; set; }
        
        public DateTime LastUpdated { get; set; }
    }
}