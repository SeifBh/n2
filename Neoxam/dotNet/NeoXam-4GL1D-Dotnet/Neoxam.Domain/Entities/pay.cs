namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.pay")]
    public partial class pay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime? Date { get; set; }

        [Column(TypeName = "bit")]
        public bool Paye { get; set; }

        public int? employe_Id { get; set; }
    }
}
