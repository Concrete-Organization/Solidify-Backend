﻿using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Specification.CategorySpecifications
{
    public class CategorySpecifications : BaseSpecification<Category>
    {
        public CategorySpecifications(int id): base(c=>c.Id == id)
        {
            GetIncludes();
        }

        public CategorySpecifications(CategorySpecificationsParameters args)
            : base(
                  c =>
                  string.IsNullOrEmpty(args.SearchedPhrase) || EF.Functions.Like(c.Name.ToLower(), $"%{args.SearchedPhrase.ToLower()}%")
         )  
        {
            GetIncludes();

            AddSortAsc(c => c.Name);
            
            AddPagination(args.PageSize,args.PageSize * (args.PageNumber - 1));
        }
        private void GetIncludes()
        {
            AddIncludes(c => c.Products);
            AddIncludes($"{nameof(Category.Products)}.{nameof(Product.Brand)}");
        }
    }
}
