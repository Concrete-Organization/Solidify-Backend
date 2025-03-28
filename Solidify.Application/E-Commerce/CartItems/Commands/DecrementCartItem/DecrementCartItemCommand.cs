﻿using MediatR;
using Solidify.Application.Common.Dtos;

namespace Solidify.Application.E_Commerce.CartItems.Commands.DecrementCartItem
{
    public class DecrementCartItemCommand(string id) : IRequest<GeneralResponseDto>
    {
        public string Id { get; } = id;
    }
}
