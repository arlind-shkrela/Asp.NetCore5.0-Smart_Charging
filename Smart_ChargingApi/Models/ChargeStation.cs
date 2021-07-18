using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Models
{
    public class ChargeStation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
