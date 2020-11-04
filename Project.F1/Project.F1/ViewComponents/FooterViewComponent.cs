using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project.F1.ViewComponents
{
    [ViewComponent(Name = "Footer")]
    public class FooterViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Footer");
        }

    }
}
