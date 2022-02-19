#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InlamningsupgiftApi;
using InlamningsupgiftApi.Models.Entities;
using InlamningsupgiftApi.Models;
using InlamningsupgiftApi.Filter;

namespace InlamningsupgiftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[UseApiKey]
    public class OrderController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var items = new List<Order>();
            
            foreach (var item in await _context.Orders.ToListAsync()) {
                var orderedProducts = await _context.OrderedProducts
                    .Where(op => op.OrderId == item.Id)
                    .Select(op => new OrderedProducts(op.ProductId, op.Quantity)).ToListAsync();

                var productsInOrder = await _context.Products
                    .Where(p => orderedProducts.Select(op => op.ProductId).Contains(p.Id)).ToListAsync();
                var totalSum = (double)productsInOrder.Zip(orderedProducts, (a, b) => a.Price * b.Quantity).Sum();
                items.Add(new Order(item.Id, item.OrderTime, item.Status, item.CustomerId, orderedProducts, totalSum));
            }


            return items;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);

            if (orderEntity == null)
            {
                return NotFound();
            }

            var orderedProducts = await _context.OrderedProducts
                .Where(op => op.OrderId == orderEntity.Id)
                .Select(op => new OrderedProducts(op.ProductId, op.Quantity)).ToListAsync();

            var productsInOrder = await _context.Products
                .Where(p => orderedProducts.Select(op => op.ProductId).Contains(p.Id)).ToListAsync();
            var totalSum = (double)productsInOrder.Zip(orderedProducts, (a, b) => a.Price * b.Quantity).Sum();

            return new Order(orderEntity.Id, orderEntity.OrderTime, orderEntity.Status, orderEntity.CustomerId, orderedProducts, totalSum);
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEntity(int id, OrderUpdateModel model)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
                return NotFound();

            Order.Status = model.Status;
            _context.Entry(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrderEntity(OrderCreateModel model)
        {
            var order = new OrderEntity(model.CustomerId);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();


            foreach (var product in model.Products)
            {
                var prod = await _context.Products.FindAsync(product.ProductId);
                if(prod is null || prod.Deleted)
                {
                    return NotFound($"Kunde inte hitta product med ID {product.ProductId}");
                }
                var productOrdered = new OrderedProductsEntity(order.Id, product.ProductId, product.Quantity);
                _context.OrderedProducts.Add(productOrdered);

            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("PostOrderEntity", new { id = order.Id }, new Order(order.Id, order.OrderTime, order.Status, order.CustomerId, model.Products));
        }

        private bool OrderEntityExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
