using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskool.Models
{
    [Table("SupportNature")]
    public class SupportNature
    {
        public int SupportNatureID { get; set; }
        public string SupportNatureName { get; set; }
    }
}