using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace WebMvcRestApi
{
    // Create new attribute inheriting FromQueryAttribute, IParameterModelConvention
    public class RequiredFromQueryAttribute : FromQueryAttribute, IParameterModelConvention
    {
        // Add my new RequiredFromQueryActionConstraint to the parameters model to be used on my endpoint
        public void Apply(ParameterModel parameter)
        {
            if (parameter.Action.Selectors != null && parameter.Action.Selectors.Any())
            {
                parameter.Action.Selectors.Last().ActionConstraints.Add(new RequiredFromQueryActionConstraint(parameter.BindingInfo?.BinderModelName ?? parameter.ParameterName));
            }
        }
    }
}
