namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.penality")]
    public partial class penality
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Degree { get; set; }

        public DateTime? dateConseil { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public float total { get; set; }

        public int? employe_Id { get; set; }
    }
}
