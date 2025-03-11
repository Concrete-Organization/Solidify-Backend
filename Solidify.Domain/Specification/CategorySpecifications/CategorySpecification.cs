using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;
using Solidify.Domain.Specification.ProductSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Specification.CategorySpecifications
{
    public class CategorySpecification : BaseSpecification<Category>
    {
        public CategorySpecification(int id) : base(c => c.Id == id)
        {
            GetIncludes();
        }
        public CategorySpecification() 
        {
            GetIncludes();
        }



        public CategorySpecification(CategorySpecificationParameters args)
            : base(
                p => (string.IsNullOrEmpty(args.SearchedPhrase)
                || EF.Functions.Like(p.Name.ToLower(), $"%{args.SearchedPhrase.ToLower()}%"))
                )
        {
            GetIncludes();

            if (!string.IsNullOrEmpty(args.SortBy))
            {
                var sortByLower = args.SortBy.ToLower();

                var columnSelectors = new Dictionary<string, Expression<Func<Category, object>>>()
                {
                    {nameof(Category.Name).ToLower(), p => p.Name}
                };

                switch (args.SortDirection)
                {
                    case SortDirection.Ascending:
                        AddSortAsc(columnSelectors[sortByLower]);
                        break;
                    case SortDirection.Descending:
                        AddSortDesc(columnSelectors[sortByLower]);
                        break;
                }
            }
            else
            {
                AddSortAsc(p => p.Name);
            }

            AddPagination(args.PageSize, (args.PageNumber - 1) * args.PageSize);
        }

        private void GetIncludes()
        {
            AddIncludes(c => c.Products);
        }

    }
}
