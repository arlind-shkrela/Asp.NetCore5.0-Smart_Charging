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


        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Please enter a value equal/bigger than {1} and less than {5}")]
        public int ConnectorId { get; set; }

        public virtual Connector Connector { get; set; }


    }
}
