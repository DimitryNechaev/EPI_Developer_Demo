using AlloyDemo.Models.POCOs;
using EPiServer.Core;
using EPiServer.PlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyDemo.Models.Properties
{
    [PropertyDefinitionTypePlugIn(
        DisplayName = "List of people i.e. IList<Person>",
        Description = "An editable list of Person instances.")]
    public class PropertyPersonList : PropertyList<Person>
    {
    }
}