namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.task")]
    public partial class task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Monitoring { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? employe_Id { get; set; }

        public int? projet_Id { get; set; }
    }
}
