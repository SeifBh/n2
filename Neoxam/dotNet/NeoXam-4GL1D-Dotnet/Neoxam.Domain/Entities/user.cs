namespace Neoxam.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.user")]
    public partial class user
    {
        public user(string first_name)
        {
            first_name = first_name;
        }

        public user()
        {
        }

        [Required]
        [StringLength(31)]
        public string DTYPE { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(255)]
        public string mail_address { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public int phone_number { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        public DateTime? hiring_date { get; set; }


        public float? Risk_rate { get; set; }

        [Column(TypeName = "bit")]
        public bool? editable { get; set; }

        [StringLength(255)]
        public string path_image { get; set; }

        [StringLength(255)]
        public string CV_PDF_Path { get; set; }

        [StringLength(255)]
        public string CV_TXT_Path { get; set; }

        [StringLength(255)]
        public string Linkedin_account_link { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string High_school { get; set; }

        public int? métier_Id { get; set; }

        public int? fiche_candidat_id { get; set; }

       
    }


}
