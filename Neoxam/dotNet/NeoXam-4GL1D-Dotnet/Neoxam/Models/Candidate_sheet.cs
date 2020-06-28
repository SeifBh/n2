using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Neoxam.Models
{
    public class Candidate_sheet
    {
        public int id { get; set; }
        public string CV_PDF_PATH { get; set; }
        public string CV_TXT_Path { get; set; }
        public string address { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string birth_date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string linkedin_account_link { get; set; }
        public string mail_address1 { get; set; }
        public string mail_address2 { get; set; }
        public string phone_number { get; set; }

    }
}