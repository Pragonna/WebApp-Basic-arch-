
using AutoMapper;
using Core.Application.Repositories.OrderDetailsRepositories;
using Core.Application.Repositories.OrderRepositories;
using Core.Application.Repositories.ProductRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.OrderDtos;
using Core.Domain.Entities;

namespace Core.Business.BusinessManager.OrderBusinessManager
{
    public class OrderManager(IOrderRepository orderRepository,
                              OrderBusinessRules orderBusinessRules,
                              IOrderDetailsRepository orderDetailsRepository,
                              IProductRepository productRepository) : IOrderManager
    {
        public async Task<OrderListDto> CreateOrder(OrderAddDto orderAddDto)
        {
            await orderBusinessRules.OrderProductsCanNotBeNull(orderAddDto.Products);
            await orderBusinessRules.OrderPriceMustBeGreatThanZero(orderAddDto.Price);

            OrderDetails createdOrder = await orderDetailsRepository.AddAsync(new(
                orderAddDto.Price,
                orderAddDto.ShippingAddress,
                orderAddDto.PostalCode));

            foreach (var product in orderAddDto.Products)
                await orderRepository.AddAsync(new(createdOrder.Id, product.Id));

            return  CustomMappedOrderListDto(createdOrder);
        }

        private OrderListDto CustomMappedOrderListDto(OrderDetails orderDetails)
        {
            OrderListDto orderListDto = new()
            {
                Id = orderDetails.Id,
                Price = orderDetails.Price,
                ShippingAddress = orderDetails.ShippingAddress,
                PostalCode = orderDetails.PostalCode
            };
            var orders = orderRepository.GetList(x => x.OrderId == orderDetails.Id).ToList();
            foreach (var order in orders)
            {
                var product = productRepository.GetById(order.ProductId);
                orderListDto.Products.Add(product);
            }
            return orderListDto;
        }
        public IEnumerable<OrderListDto> ListOrders()
        {
            IEnumerable<OrderDetails> orders = orderBusinessRules.CheckOrderExistsInDb();
            foreach (var order in orders)
            {
                yield return CustomMappedOrderListDto(order);
            }
        }
        // .Remove
        // .Update

    }
}
