using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ChargePointer.Infrastructure.Domain.Entities
{
    public class ChargePoint
    {
        [Required]
        [StringLength(39, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string ChargePointId { get; set; }

        [Required]
        [RegularExpression("Available|Blocked|Charging|Removed|Reserved|Unknown")]
        public string Status { get; set; }
        
        [StringLength(4, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FloorLevel { get; set; }
        
        [Required]
        public DateTime LastUpdated { get; set; }

        [JsonIgnore]
        public string LocationId { get; set; }

        // public override bool Equals(object obj)
        // {
        //     var chargePoint = obj as ChargePoint;
        //     return this.ChargePointId ==  chargePoint.ChargePointId;
        // }

        protected bool Equals(ChargePoint other)
        {
            return ChargePointId == other.ChargePointId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ChargePointId, Status, FloorLevel, LastUpdated, LocationId);
        }
    }
}