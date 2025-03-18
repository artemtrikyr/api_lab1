using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceJournalApi.Middlewares;

public class UserIdValidationActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var recordId = context.RouteData.Values["id"]?.ToString();

        if (string.IsNullOrEmpty(recordId) || !IsValidRecordId(recordId))
        {
            context.Result = new BadRequestObjectResult("Invalid record ID");
        }

        base.OnActionExecuting(context);
    }

    private bool IsValidRecordId(string recordId)
    {
        return int.TryParse(recordId, out int id) && id > 0;
    }
}
