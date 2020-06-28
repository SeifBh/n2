namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.training")]
    public partial class training
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? End_date { get; set; }

        [StringLength(255)]
        public string Former { get; set; }

        public int Max_participants { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Place { get; set; }

        public int Price { get; set; }

        public DateTime? Start_date { get; set; }
    }
}
