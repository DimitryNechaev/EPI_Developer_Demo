using AlloyDemo.Models.Pages;
using AlloyDemo.Models.ViewModels;
using AlloyDemo.Models.Pages;
using EPiServer.Core;
using System.Collections.Generic;

namespace AlloyDemo.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        StartPage StartPage { get; }
        IEnumerable<SitePageData> MenuPages { get; }
        IContent Section { get; set; }

        LayoutModel Layout { get; set; }
    }
}
