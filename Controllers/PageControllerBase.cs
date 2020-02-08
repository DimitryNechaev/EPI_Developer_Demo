using System.Web.Mvc;
using AlloyDemo.Business;
using AlloyDemo.Models.Pages;
using AlloyDemo.Models.ViewModels;
using EPiServer.Web.Mvc;
using EPiServer.Shell.Security;
using EPiServer;
using AlloyDemo.Models.ViewModels;
using EPiServer.Core;
using EPiServer.Filters;
using System.Linq;
using AlloyDemo.Business.ExtensionMethods;

namespace AlloyDemo.Controllers
{
    /// <summary>
    /// All controllers that renders pages should inherit from this class so that we can
    /// apply action filters, such as for output caching site wide, should we want to.
    /// </summary>
    public abstract class PageControllerBase<T> : PageController<T>, IModifyLayout
        where T : SitePageData
    {
        protected readonly IContentLoader loader;

        public PageControllerBase(IContentLoader loader)
        {
            this.loader = loader;
        }

        protected EPiServer.ServiceLocation.Injected<UISignInManager> UISignInManager;

        /// <summary>
        /// Signs out the current user and redirects to the Index action of the same controller.
        /// </summary>
        /// <remarks>
        /// There's a log out link in the footer which should redirect the user to the same page.
        /// As we don't have a specific user/account/login controller but rely on the login URL for
        /// forms authentication for login functionality we add an action for logging out to all
        /// controllers inheriting from this class.
        /// </remarks>
        public ActionResult Logout()
        {
            UISignInManager.Service.SignOut();
            return RedirectToAction("Index");
        }

        public virtual void ModifyLayout(LayoutModel layoutModel)
        {
            var page = PageContext.Page as SitePageData;
            if (page != null)
            {
                layoutModel.HideHeader = page.HideSiteHeader;
                layoutModel.HideFooter = page.HideSiteFooter;
            }
        }

        protected IPageViewModel<TPage> CreatePageViewModel<TPage>(TPage currentPage) where TPage : SitePageData
        {
            var viewmodel = PageViewModel.Create(currentPage);

            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            viewmodel.MenuPages = FilterForVisitor.Filter(
                loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewmodel.Section = currentPage.ContentLink.GetSection();

            return viewmodel;
        }

    }
}
