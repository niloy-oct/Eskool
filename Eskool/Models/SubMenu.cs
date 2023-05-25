using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskool.Models
{

    [Table("MARC_sub_menu")]
    public class SubMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sub_menu_id { get; set; }
        public int menu_id { get; set; }
        public string display_name { get; set; }
        public string form_name { get; set; }
        public string icon { get; set; }
   
    }
}