using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MLCMS.Models
{
    public class UpdateShipmentViewModel
    {
        [Editable(false)]
        public int ShipId { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string ShippingType { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public string ShippingDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string ArrivalDate { get; set; }
        [Required]
        public string Status { get; set; }
    }
}