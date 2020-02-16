using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleManagement.DataAcess.Entities
{    
    public class Car: VehicleBase
    {
        
        public string Title { get; set; }
        public string VinNumber { get; set; }
        public VehicleSpecification Specs { get; set; }
        public int Seats { get; set; }
    }

    public class Boat : VehicleBase
    {
        public string Title { get; set; }
        public string VinNumber { get; set; }
        public VehicleSpecification Specs { get; set; }
        public string HullType { get; set; }
    }
}
