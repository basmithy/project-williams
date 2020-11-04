using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project.F1.ViewComponents
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Header");
        }

    }
}
