using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eskool.ViewModels
{
    public class OTPViewModel
    {
        public string EmployeeCode { get; set; }
        public string GuestName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int Duration { get; set; }
        public string Remarks { get; set; }
        public string GuestMobileNo { get; set; }
    }
}