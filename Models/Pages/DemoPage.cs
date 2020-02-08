using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlloyTraining.Models.POCOs;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AlloyDemo.Models.Pages
{
    [ContentType(DisplayName = "DemoPage", GUID = "308405a2-7c06-4323-bae7-c19f54722b5e", Description = "")]
    public class DemoPage : PageData
    {
        public virtual IList<Person> People { get; set; }
    }
}