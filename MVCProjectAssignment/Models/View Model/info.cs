using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectAssignment.Models.View_Model
{
    public class info
    {
    }

    public class Members
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }

    public class Vehicles
    {
        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }
        public string VehicleStatus { get; set; }

        public int MemberId { get; set; }
    }

    public class Payments
    {
        public int MemberId { get; set; }
        public int VehicleId { get; set; }
        public float Amount { get; set; }
    }
}