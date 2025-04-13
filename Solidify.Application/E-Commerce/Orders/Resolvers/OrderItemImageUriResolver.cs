using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Http;
using Solidify.Application.E_Commerce.Orders.Dtos;
using Solidify.Domain.Entities.ECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Application.E_Commerce.Orders.Resolvers
{
    public class OrderItemImageUriResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null || source.Product == null || string.IsNullOrEmpty(source.Product.ImageUri))
                return string.Empty;

            var baseUri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            return $"{baseUri}/Uploads/ProductImages/{source.Product.ImageUri}";
        }
    }
}
