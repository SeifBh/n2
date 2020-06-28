namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.meeting")]
    public partial class meeting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string Place { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        public int? directeur_Id { get; set; }
    }
}
