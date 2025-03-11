using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;
using Solidify.Domain.Specification.CategorySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Specification.BrandSpecifications
{
    public class BrandSpecifications : BaseSpecification<Brand>
    {
        public BrandSpecifications(int id) : base(x => x.Id == id)
        {
            GetIncludes();
        }

        public BrandSpecifications()
        {
            GetIncludes();
        }

        public BrandSpecifications(BrandSpecificationsParameters args)
           : base(
                p => (string.IsNullOrEmpty(args.SearchedPhrase)
                || EF.Functions.Like(p.Name.ToLower(), $"%{args.SearchedPhrase.ToLower()}%"))
                )
        {
            GetIncludes();

            if (!string.IsNullOrEmpty(args.SortBy))
            {
                var sortByLower = args.SortBy.ToLower();

                var columnSelectors = new Dictionary<string, Expression<Func<Brand, object>>>()
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
            AddIncludes(x => x.Products);
            AddIncludes($"{nameof(Brand.Products)}.{nameof(Product.Category)}");

        }
    }
}
