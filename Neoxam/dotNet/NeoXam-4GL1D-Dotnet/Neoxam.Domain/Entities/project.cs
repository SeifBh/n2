namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.project")]
    public partial class project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Duration { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? client_Id { get; set; }

        public int? team_leader_Id { get; set; }
    }
}
