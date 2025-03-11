using Solidify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Specification.BrandSpecifications
{
    public class BrandSpecificationsParameters
    {
        public string? SearchedPhrase { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
