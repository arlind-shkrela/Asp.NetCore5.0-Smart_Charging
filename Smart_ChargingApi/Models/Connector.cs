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
        public int Max_Current_Amps { get; set; }
    }
}
