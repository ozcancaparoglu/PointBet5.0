using Common.Enums;
using System.Collections.Generic;

namespace Common.Models
{
    public class FilterModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<FilterItem> Filters { get; set; }
    }

    public class FilterItem
    {
        public string Field { get; set; }
        public FilterOperator Operator { get; set; }
        public object Value { get; set; }
    }
}
