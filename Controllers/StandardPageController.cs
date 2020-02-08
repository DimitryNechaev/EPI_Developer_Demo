using AlloyDemo.Controllers;
using AlloyDemo.Models.Pages;
using AlloyDemo.Models.Pages;
using EPiServer;
using System.Web.Mvc;

namespace AlloyDemo.Controllers
{
    public class StandardPageController : PageControllerBase<StandardPage>
    {
        public StandardPageController(IContentLoader loader) : base(loader)
        {
        }

        public ActionResult Index(StandardPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}