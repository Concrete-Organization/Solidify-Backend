using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solidify.Application.Common;
using Solidify.Application.Common.Dtos;
using Solidify.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Categories.Queries
{
    public class GetCategoryQuery :PaginatedQuery
    {
        [FromRoute]
        public int Id { get; set; } 
        public int? BrandId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
