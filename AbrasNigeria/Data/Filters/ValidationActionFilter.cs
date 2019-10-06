using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Filters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{

        //    var modelState = context.ModelState;

        //    if (!modelState.IsValid)
        //    {
        //        List<ModelError> errors = modelState
        //            .Where(ms => ms.Value.Errors.Count > 0)
        //            .SelectMany(ms => ms.Value.Errors).ToList();

        //        //foreach(var models in modelState)
        //        //{
        //        //    foreach(var error in models.Value.Errors)
        //        //    {
        //        //        errors.Add(error.ErrorMessage);
        //        //    }
        //        //}

        //        context.Result = new BadRequestObjectResult(errors);
        //    }

        //    base.OnActionExecuting(context);
        //}


    }
}
