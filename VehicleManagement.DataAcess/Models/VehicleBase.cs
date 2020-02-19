using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleManagement.DataAcess.Entities
{
    public abstract class VehicleBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Title { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
    }
}
