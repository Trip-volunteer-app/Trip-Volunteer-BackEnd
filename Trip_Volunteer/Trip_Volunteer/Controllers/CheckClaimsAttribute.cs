using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Trip_Volunteer.API.Controllers
{
    public class CheckClaimsAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _claimType;
        private readonly string[] _claimValues;

        public CheckClaimsAttribute(string claimType, params string[] claimValues)
        {
            _claimType = claimType;
            _claimValues = claimValues;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userClaims = context.HttpContext.User.Claims;
            var hasValidRole = userClaims.Any(claim => claim.Type == _claimType && _claimValues.Contains(claim.Value));

            if (!hasValidRole)
            {
                context.Result = new ForbidResult();
            }
        }
    }

}



//public class CheckClaimsAttribute : Attribute, IAuthorizationFilter
//{
//    private readonly string _claimName;
//    private readonly string _claimValue;
//    public CheckClaimsAttribute(string claimName, string claimValue)
//    {
//        _claimName = claimName;
//        _claimValue = claimValue;
//    }
//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
//        if (!context.HttpContext.User.HasClaim(_claimName, _claimValue))
//        {
//            context.Result = new ForbidResult();
//        }
//    }
//}



//[CheckClaimsAttribute("Roleid", "1", "2")]
