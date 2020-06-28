namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.candidate_sheet")]
    public partial class candidate_sheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string CV_PDF_PATH { get; set; }

        [StringLength(255)]
        public string CV_TXT_Path { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birth_date { get; set; }

        [StringLength(255)]
        public string diploma { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(255)]
        public string linkedin_account_link { get; set; }

        [StringLength(255)]
        public string mail_address1 { get; set; }

        [StringLength(255)]
        public string mail_address2 { get; set; }

        [StringLength(255)]
        public string phone_number { get; set; }

        public int? ecole_Id { get; set; }
    }
}
