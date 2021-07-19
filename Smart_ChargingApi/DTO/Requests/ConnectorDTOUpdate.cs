using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.DTO.Requests
{
    //later with dto's
    public class ConnectorDTOUpdate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value equal/bigger than {1}")]
        public float Max_Current { get; set; } = 1;

        [Required(ErrorMessage = "Please enter a value Charge Station Id")]
        public int? ChargeStationsId { get; set; }
    }
}
