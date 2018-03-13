using Chapter24_MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter24_MvcModels.Infrastructure
{
    public class AddressSummaryBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            AddressSummary result = (AddressSummary)bindingContext.Model ?? new AddressSummary();
            result.City = GetValue(bindingContext, nameof(AddressSummary.City));
            result.Country = GetValue(bindingContext, nameof(AddressSummary.Country));

            return result;
        }

        private string GetValue(ModelBindingContext bindingContext, string propertyName)
        {
            propertyName = (bindingContext.ModelName == "" ? "" : bindingContext.ModelName + ".") + propertyName;

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(propertyName);
            if (result == null || result.AttemptedValue == "")
            {
                return "<Not Specified>";
            }
            else
            {
                return (string)result.AttemptedValue;
            }
        }
    }
}