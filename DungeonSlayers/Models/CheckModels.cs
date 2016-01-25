using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonSlayers.Models
{
    public class Check : NamedIdentifiable
    {
        public string DataBinding { get; set; } = "";
        public string PrettyBinding { get; set; } = "";
        public string Tooltip { get; set; }
    }
}