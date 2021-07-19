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
        [Display(Name= "Name")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public float Capacity { get; set; } = 1;


        public ICollection<ChargeStation> ChargeStations { get; set; }

    }
}
