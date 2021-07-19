using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        [Required(ErrorMessage = "Please enter a value Charge Station Id")]
        public int? ChargeStationsId { get; set; }

        public ICollection<ChargeStation> ChargeStations { get; set; }

    }
}
