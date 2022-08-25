namespace MVCProjectAssignment.Models.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int VehicleId { get; set; }

        public double AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        public virtual NURTWMember NURTWMember { get; set; }
    }
}
