using AlloyDemo.Controllers;
using AlloyDemo.Models.Pages;
using AlloyDemo.Models.Pages;
using EPiServer;
using System.Web.Mvc;

namespace AlloyDemo.Controllers
{
    public class ProductPageController : PageControllerBase<ProductPage>
    {
        public ProductPageController(IContentLoader loader) : base(loader)
        {
        }

        public ActionResult Index(ProductPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}