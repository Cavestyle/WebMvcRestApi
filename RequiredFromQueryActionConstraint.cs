using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace OpendorseWebMvc
{
    // Create new ActionContraint using endpoint parameter
    public class RequiredFromQueryActionConstraint : IActionConstraint
    {
        private readonly string _parameter;

        public RequiredFromQueryActionConstraint(string parameter)
        {
            _parameter = parameter;
        }

        // Used a high number to be safe so mine is last
        public int Order => 999;

        // Check if parameter (?artistName in my case) is present after endpoint [Route("api/[controller]")]. If true, hit controller
        public bool Accept(ActionConstraintContext context)
        {
            if (!context.RouteContext.HttpContext.Request.Query.ContainsKey(_parameter))
                return false;

            return true;
        }
    }
}
