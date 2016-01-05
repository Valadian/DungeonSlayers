using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DungeonSlayers.Utils
{
    public static class SelectListUtil
    {
        //public static IEnumerable<KeyValuePair<String, int>> AsKeyValuePairs(this Enum enumeration)
        //{
        //    var values = enumeration.GetType().GetEnumValues().OfType<int>();
        //    return values.Select(v => new KeyValuePair<String, int>(Enum.GetName(enumeration.GetType(), v), v));

        //}
        //public static IEnumerable<SelectListItem> AsChoices(this Enum enumeration)
        //{
        //    return enumeration.AsKeyValuePairs().Select(kv => new SelectListItem() { Text = kv.Key, Value = kv.Value.ToString()});
        //}
        public static IEnumerable<SelectListItem> Of<T>(bool valueStrings = false)
        {
            Type t = typeof(T);
            if (t.IsEnum)
            {
                return from Enum e in Enum.GetValues(t)
                     select new SelectListItem(){ Text = e.ToString(), Value = valueStrings?e.ToString():Convert.ChangeType(e, e.GetTypeCode()).ToString() };
            }
            return null;
        }
    }
}