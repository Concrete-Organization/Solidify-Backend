using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Brands.Queries.GetBandQuery
{
    public class GetBrandQuery : PaginatedQuery
    {
        [FromRoute]
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
