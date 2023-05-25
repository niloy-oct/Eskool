using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eskool.ViewModels
{
    public class Compition_Product_ViewModel
    {
        public int id { get; set; }
        public List<SelectListItem> ComC { get; set; }
        public int? Code { get; set; }
        public string Compititor_Company { get; set; }
        [Required(ErrorMessage = "Product Information Required")]
        public string pname { get; set; }

        public string GenericName { get; set; }
        [Required(ErrorMessage = "Pack Size  Required")]
        public string CompititorPackSize { get; set; }

        public string brandCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Trade Price Required")]
        public decimal tradePrice { get; set; }
        public string BusinessNature { get; set; }

        //public IEnumerable<SelectListItem> GenName { get; set; }
    }
}