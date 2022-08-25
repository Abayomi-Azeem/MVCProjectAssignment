namespace MVCProjectAssignment.Models.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NURTWVehicle
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleMake { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleModel { get; set; }

        [Required]
        [StringLength(5)]
        public string VehicleStatus { get; set; }

        public virtual NURTWMember NURTWMember { get; set; }
    }
}
