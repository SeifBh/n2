namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.extra_hours")]
    public partial class extra_hours
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "bit")]
        public bool Approved { get; set; }

        public DateTime? Date { get; set; }

        public int Hours_number { get; set; }

        public int? employe_Id { get; set; }
    }
}
