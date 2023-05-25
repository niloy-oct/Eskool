using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskool.Models
{

    public class Internet_Access_OTPGenerators
    {
        [Key]
        public int ID { get; set; }
        public string EmployeeCode { get; set; }
        public string GuestName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int Duration { get; set; }
        public DateTime CreationTime { get; set; }
        public string Remarks { get; set; }
        public string GuestMobileNo { get; set; }
        public string Creator { get; set; }
    }
}