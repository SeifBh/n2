using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neoxam.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Place { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Start_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime? End_date { get; set; }

    }
}