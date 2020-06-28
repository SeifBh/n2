namespace Neoxam.Domain.Entities
{
    using Enumerations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.holiday")]
    public partial class holiday
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "bit")]
        public bool Accepted { get; set; }

        public int Duration { get; set; }

        public DateTime? End_date { get; set; }

        public DateTime? Start_date { get; set; }

        public holiday_type Type { get; set; }

        public int? employe_Id { get; set; }
    }
}
