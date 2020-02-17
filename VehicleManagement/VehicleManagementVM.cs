using System;
using VehicleManagement.DataAcess.Entities;

namespace VehicleManagement
{
    public class VehicleManagementVM
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class VehicleManagementModel
    {        
        public int ID { get; set; }
        public String Title { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public String Engine { get; set; }
        public String VinNumber { get; set; }        
        public int Seats { get; set; }
        public int SpecificationId { get; set; }
        public int VehicleType { get; }
        public int Doors { get; set; }

        public int BodyType { get; set; }
        
    }
}
