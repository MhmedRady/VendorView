﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using VendorView.Shared;

namespace VendorView.API
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
        public static IActionResult AppSuccess(this ControllerBase controller, dynamic data, string message = "Data done successfully!")
        {
            return controller.Ok(new { success = true, data, message });
        }
        
        public static IActionResult AppDeleteSuccess(this ControllerBase controller, dynamic data, string message = Constanties.SUCCESS_DELETED)
        {
            return controller.Ok(new { success = true, data, message });
        }

        public static IActionResult AppFailed(this ControllerBase controller, dynamic data)
        {
            return controller.Ok(new { success = false, data });
        }

        public static IActionResult AppFailed(this ControllerBase controller, string message = Constanties.APPFAILED, dynamic data = null)
        {
            return controller.Ok(new { success = false, data, message });
        }
        public static IActionResult AppDeleteFailed(this ControllerBase controller, string message = Constanties.FAILED_DELETED, dynamic data = null)
        {
            return controller.Ok(new { success = false, data, message });
        }

        public static IActionResult AppNotFound(this ControllerBase controller, string msg = Constanties.NOTFOUND)
        {
            return controller.Ok(new { success = false, message = msg });
        }

        public static IActionResult AppInvalidModel(this ControllerBase controller, ModelStateDictionary modelState)
        {
            var msg = string.Join(',', modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
            return controller.Ok(new { success = false, message = msg });
        }
    }
}
