namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.non_attendance")]
    public partial class non_attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        [Column(TypeName = "bit")]
        public bool Isjustified { get; set; }

        public int? employe_Id { get; set; }
    }
}
