using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Models
{
    interface Icommon
    {
        string MakerID { get; set; }
        string MakerIP {get;set;}
        string cmp_code { get; set; }
        string citycode { get; set; }
        string citycode1 { get; set; }
        string cmpcode { get; set; } //companycode
        string cmpid { get; set; } //userid
    }
}