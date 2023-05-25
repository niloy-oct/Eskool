using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskool.Models
{

    [Table("MARC_menu")]
    public class Menu
    {
        [Key]
        public int menu_id { get; set; }
        public string menu_details { get; set; }
        public string menu_form { get; set; }
        public string menue_icon { get; set; }

    }
}