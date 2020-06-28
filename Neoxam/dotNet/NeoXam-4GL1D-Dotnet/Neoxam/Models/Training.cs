using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neoxam.Models
{
    public class Training
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Start_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? End_date { get; set; }

        public string Former { get; set; }

        public string Place { get; set; }

        public int Price { get; set; }

    }
}