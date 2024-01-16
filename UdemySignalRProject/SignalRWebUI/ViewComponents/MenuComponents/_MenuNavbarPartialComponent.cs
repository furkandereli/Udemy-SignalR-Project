using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
