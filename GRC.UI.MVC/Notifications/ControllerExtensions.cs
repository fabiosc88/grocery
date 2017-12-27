using System.Web.Mvc;

namespace GRC.UI.MVC.Notifications
{
    public static class ControllerExtensions
    {
        public static ToastMessage AddToastMessage(this Controller controller, string message, ToastType toastType = ToastType.Info, string title = null)
        {
            Toastr toastr = controller.TempData["Toastr"] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(title, message, toastType);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }
    }
}