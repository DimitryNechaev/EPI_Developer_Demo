using AlloyDemo.Controllers;
using AlloyDemo.Models.Pages;
using AlloyDemo.Models.Pages;
using AlloyDemo.Models.ViewModels;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace AlloyDemo.Controllers
{
    [TemplateDescriptor(Inherited = false)]
    public class ProductPagePartialController : PartialContentController<ProductPage>
    {
        public ProductPagePartialController() : base()
        {
        }

        public override ActionResult Index(ProductPage currentPage)
        {
            var viewmodel = PageViewModel.Create(currentPage);
            return PartialView(viewmodel);
        }
    }
}