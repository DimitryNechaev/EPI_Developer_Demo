using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlloyDemo.Models.Blocks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using AlloyDemo.Models.Properties;
using EPiServer.Shell.ObjectEditing;
using AlloyDemo.Business.SelectionFactories;

namespace AlloyDemo.Models.Pages
{
    /// <summary>
    /// Used to present a single product
    /// </summary>
    [SiteContentType(
        GUID = "17583DCD-3C11-49DD-A66D-0DEF0DD601FC",
        GroupName = Global.GroupNames.Products)]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-product.png")]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        IncludeOn = new[] { typeof(StartPage) })]
    public class ProductPage : StandardPage, IHasRelatedContent
    {
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            Theme = "theme1";
        }

        [SelectOne(SelectionFactoryType = typeof(ThemeSelectionFactory))]
        [Display(Name = "Color theme",
            GroupName = SystemTabNames.Content,
            Order = 310)]
        public virtual string Theme { get; set; }

        [CultureSpecific]
        [Display(Name = "Unique selling points",
            GroupName = SystemTabNames.Content,
            Order = 320)]
        [Required]
        [UIHint(Global.SiteUIHints.StringsCollection)]
        public virtual IList<string> UniqueSellingPoints { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 330)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(IContentData) },new[] { typeof(JumbotronBlock) })]
        public virtual ContentArea RelatedContentArea { get; set; }
    }
}
