using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public float Capacity { get; set; } = 0;



        public ICollection<ChargeStation> ChargeStations { get; set; }

    }
}
