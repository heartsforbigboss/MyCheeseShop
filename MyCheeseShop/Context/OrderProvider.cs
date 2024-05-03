﻿using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class OrderProvider
    {
        public async Task CreateOrder(User user, IEnumerable<CartItem> items)
        {
            // Create a new order
            var order = new Order
            {
                User = user,
                Items = items.Select(item => new OrderItem
                {
                    Cheese = item.Cheese,
                    Quantity = item.Quantity,
                }).ToList(),
                Created = DateTime.Now,
                Status = OrderStatus.Placed
            };
        
            // Add order to database
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        private readonly DatabaseContext _context;
    }
}
