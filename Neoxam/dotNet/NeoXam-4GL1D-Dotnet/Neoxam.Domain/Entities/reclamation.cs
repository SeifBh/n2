namespace Neoxam.Domain.Entities
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        Technique,
        Financiére,
        Autre
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusS
    {
        EnCours,
        CLOTURE
       
    }


    [Table("neoxamdb.reclamation")]
    public partial class reclamation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Category category { get; set; }

        [AllowHtml]
        [StringLength(255)]
        public string description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public StatusS status { get; set; }

        [DisplayFormat(DataFormatString ="MMMM dd, yyyy")]
        public DateTime dateReclamation { get; set; }
        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]

        public string path_file { get; set; }

        public bool archivable { get; set; }
        [StringLength(255)]
        public string readableRec { get; set; }
        public int? employe_Id { get; set; }
    }
}
