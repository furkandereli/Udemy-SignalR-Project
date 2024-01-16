using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View(); 
        }
    }
}
