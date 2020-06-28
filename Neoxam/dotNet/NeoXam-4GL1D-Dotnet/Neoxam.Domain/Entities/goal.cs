namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.goal")]
    public partial class goal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public float Progress_rating { get; set; }

        public DateTime? deadline { get; set; }

        public int? tache_Id { get; set; }
    }
}
