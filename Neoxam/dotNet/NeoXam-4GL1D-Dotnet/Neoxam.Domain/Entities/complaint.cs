namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.complaint")]
    public partial class complaint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public int Degree { get; set; }

        [StringLength(255)]
        public string Details { get; set; }

        public int Employee2 { get; set; }

        [Column(TypeName = "bit")]
        public bool IsVerified { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        public int? employee1_Id { get; set; }
    }
}
