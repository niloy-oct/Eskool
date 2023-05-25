using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eskool.Models
{
    public class LoginInfo
    {
        public string UserName { get; set; }      
        public string LegacyID { get; set; }
        public string FullName { get; set; }
        public string DesignationCode { get; set; }
        public string CellPhone { get; set; }
        public string permissionLevel { get; set; }
        public string UserPassword { get; set; }
    }
}