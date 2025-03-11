using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Solidify.Domain.Entities.ECommerce;
using Solidify.Domain.Enums;

namespace Solidify.Domain.Specification.ProductSpecifications
{
    public class ProductsSpecification : BaseSpecification<Product>
    {
        public ProductsSpecification(string id) : base(p => p.Id == id)
        {
            GetIncludes();
        }

        public ProductsSpecification(ProductSpecificationParameters args) 
            : base(
                p =>
                    (!args.BrandId.HasValue || p.BrandId == args.BrandId) 
                    &&
                    (!args.CategoryId.HasValue || p.CategoryId == args.CategoryId)
                    &&
                    (!args.MinPrice.HasValue || p.Price >= args.MinPrice)
                    &&
                    (!args.MaxPrice.HasValue || p.Price <= args.MaxPrice)
                    &&
                    (string.IsNullOrEmpty(args.SearchedPhrase) || EF.Functions.Like(p.Name.ToLower(), $"%{args.SearchedPhrase.ToLower()}%"))
                )
        {
            GetIncludes();

            if (!string.IsNullOrEmpty(args.SortBy))
            {
                var sortByLower = args.SortBy.ToLower();

                var columnSelectors = new Dictionary<string, Expression<Func<Product, object>>>()
                {
                    {nameof(Product.Name).ToLower(), p => p.Name},
                    {nameof(Product.Price).ToLower(), p => p.Price},
                    {nameof(Product.Rate).ToLower(), p => p.Rate}
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
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Supplier);
            AddIncludes(p => p.Category);
            AddIncludes(p => p.Reviews);
        }
    }
}
