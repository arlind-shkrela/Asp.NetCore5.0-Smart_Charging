using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Models
{
    public class Connector
    {
        [Key]
  
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value equal/bigger than {1}")]
        public float Max_Current { get; set; } = 1;

        public ICollection<ChargeStation> ChargeStations { get; set; }

    }
}
