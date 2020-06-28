namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.high_school")]
    public partial class high_school
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name1 { get; set; }

        [StringLength(255)]
        public string Name2 { get; set; }

        [StringLength(255)]
        public string Name3 { get; set; }
    }
}
