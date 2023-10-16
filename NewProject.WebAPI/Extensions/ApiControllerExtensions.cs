using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using VendorView.Shared;
using FluentValidation.Results;

namespace VendorView.WebApi.Extensions
{

    public static class ApiControllerExtensions
    {
        public static IActionResult AppOk(this ControllerBase controller, OperationResult result)
        {
            return controller.Ok(new { success = result.Success, data = result.Payload, message = result.Message });
        }
        //public static IActionResult AppSuccess(this ControllerBase controller, dynamic data)
        //{
        //    return controller.Ok(new { success = true, data = data });
        //}
        public static IActionResult AppSuccess(this ControllerBase controller, dynamic data, string message = "تمت العملية بنجاح!.")
        {
            return controller.Ok(new { success = true, data = data, message = message });
        }

        public static IActionResult AppFailed(this ControllerBase controller, dynamic data)
        {
            return controller.Ok(new { success = false, data = data });
        }

        public static IActionResult AppFailed(this ControllerBase controller, string message = "عفواً حدث خطأ أثناء تنفيذ طلبك", dynamic data = null)
        {
            return controller.Ok(new { success = false, data = data, message = message });
        }
        public static IActionResult AppDeleteFailed(this ControllerBase controller, string message = "عفوا لا يمكن حذف هذا العنصر , هناك بيانات مرتبطة به", dynamic data = null)
        {
            return controller.Ok(new { success = false, data = data, message = message });
        }

        public static IActionResult AppNotFound(this ControllerBase controller, string msg = "العنصر المطلوب غير موجود")
        {
            return controller.Ok(new { success = false, message = msg });
        }

        public static IActionResult AppInvalidModel(this ControllerBase controller, ModelStateDictionary modelState)
        {
            var msg = string.Join(',', modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
            return controller.Ok(new { success = false, message = msg });
        }

        public static IActionResult ValidationErrors(this ControllerBase controller, List<ValidationFailure> ValidationErrors)
        {
            var errors = new Dictionary<string, string>();
            foreach (var error in ValidationErrors)
            {
                errors[error.PropertyName] = error.ErrorMessage;
            }
            return controller.AppFailed(data: errors);
        }
    }
}
