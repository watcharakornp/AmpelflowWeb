using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmpelflowWeb.Models
{
    public class cGetDataSignIn
    {
        public string  username { get; set; }
        public string password { get; set; }
        public string  macaddress { get; set; }
        public int  isremember { get; set; }
    }
}