using Manilal_V5NG.Models;
using Manilal_V5NG.Utils;
using System.Security.Claims;
using System;
using System.Web;

namespace Manilal_V5NG.Utils
{
    public static class RetrieveClaimsPrinciple
    {
        //public static LoginInfo GetClaims() {

        //    ClaimsIdentity identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
        //    LoginInfo loginuser = new LoginInfo()
        //    {
        //        Guid = identity.FindFirst(OwnClaimTypes.Guid).Value,
        //        UserId = identity.FindFirst(OwnClaimTypes.Userid).Value
        //    };
        //    return loginuser;
        //}
        //public static LoginInfo GetClaimsOrder()
        //{

        //    ClaimsIdentity identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
        //    LoginInfo log = new LoginInfo()
        //    {
        //        Guid = Extensions.IfNullThenEmpty(Convert.ToString(identity.FindFirst(OwnClaimTypes.Guid).Value)),
        //        UserId = Extensions.IfNullThenEmpty(Convert.ToString(identity.FindFirst(OwnClaimTypes.Userid).Value)),
        //        Orderno = Extensions.IfNullThenEmpty(Convert.ToString(identity.FindFirst(OwnClaimTypes.Orderno).Value)),
        //        Ordstatus = Extensions.IfNullThenEmpty(Convert.ToString(identity.FindFirst(OwnClaimTypes.Ordstatus).Value))
        //    };
        //    return log;
        //}

    }
}