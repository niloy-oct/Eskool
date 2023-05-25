using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskool.Models
{
    [Table("InvSet_ProductInfo")]
    public class Product_Details
    {
        [Key]
        public string PCd { get; set; }
        public string PNm { get; set; }
        public char PTpCd { get; set; }
        public char PsTpCd { get; set; }
        public char MTpCd { get; set; }
        public decimal TrdPrice { get; set; }
        public decimal Vat { get; set; }
        public decimal MRP { get; set; }
        public string PacSiz { get; set; }
        public decimal CellAmt { get; set; }
        public decimal CellPer { get; set; }
        public decimal BonCelQty { get; set; }
        public decimal BonQty { get; set; }
        public char Status { get; set; }
        public char PCatCd { get; set; }
        public decimal PurRate { get; set; }
        public string SupCd { get; set; }
        public char clamestatus { get; set; }
        public string IsCamp { get; set; }
        public int MinQty { get; set; }
        public string Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}