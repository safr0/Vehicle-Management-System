using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleManagement.DataAcess.Entities
{
    public enum VehicleType
    {
        Car,
        Bike,
        Boat,
        Caravan
    }
    public enum BodyType
    {
        HatchBack,
        Sedan,
        SUV,
        Wagon,
        Ute
    }

    public class VehicleSpecification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecificationId { get; set; }
        public VehicleType VehicleType { get; }
    }

    public class CarSpecification : VehicleSpecification
    {
        public int Doors { get; set; }
        public String Engine { get; set; }
        public BodyType BodyType { get; set; }
    }

    public class BoatSpecification : VehicleSpecification
    {
        public string HullType { get; set; }
        new VehicleType VehicleType = VehicleType.Boat;
    }

}
