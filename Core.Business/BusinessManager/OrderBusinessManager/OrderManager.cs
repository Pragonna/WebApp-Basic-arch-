
using AutoMapper;
using Core.Application.Repositories.OrderDetailsRepositories;
using Core.Application.Repositories.OrderRepositories;
using Core.Business.BusinessRules;
using Core.Business.Dtos.OrderDtos;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.BusinessManager.OrderBusinessManager
{
    public class OrderManager(IOrderDetailsRepository orderDetailsRepository,
                              IOrderRepository orderRepository,
                              OrderBusinessRules orderBusinessRules,
                              IMapper mapper) : IOrderManager
    {

        public async Task<OrderListDto> CreateOrder(OrderCreateDto orderCreateDto)
        {
            await orderBusinessRules.OrderDetailsMembersCanNotBeNullOrEmpty(orderCreateDto.ShippingAddress,
                                                                      orderCreateDto.PostalCode,
                                                                      orderCreateDto.Price);

            await orderBusinessRules.CheckProductExistsInDb(orderCreateDto.Products);

            var mappedOrderDetail = mapper.Map<OrderDetails>(orderCreateDto);
            var createdOrderDetail = await orderDetailsRepository.AddAsync(mappedOrderDetail);

            foreach (var product in orderCreateDto.Products)
                await orderRepository.AddAsync(new Order(createdOrderDetail.Id, product.Id));

            return await GetOrder(createdOrderDetail, orderCreateDto.Products);

        }

        public async Task<IEnumerable<OrderListDto>> GetAllOrders()
        {
            return QueryForAllOrders();
        }
        private IEnumerable<OrderListDto> QueryForAllOrders()
        {
            var context = orderRepository.Context;
            var orderListDtos = new List<OrderListDto>();

            IEnumerable<OrderQueryDto> orderQueryDtos = (IEnumerable<OrderQueryDto>)from order in context.Orders
                                                                                    join orderDetails in context.OrderDetails on order.OrderId equals orderDetails.Id
                                                                                    join product in context.Products on order.ProductId equals product.Id
                                                                                    select new OrderQueryDto
                                                                                    {
                                                                                        OrderDetails = new OrderDetailsDto
                                                                                        {
                                                                                            Id = orderDetails.Id,
                                                                                            ShippingAddress = orderDetails.ShippingAddress,
                                                                                            PostalCode = orderDetails.PostalCode,
                                                                                            Price = orderDetails.Price,
                                                                                        },
                                                                                        Product = new ProductListDto
                                                                                        {
                                                                                            Id = product.Id,
                                                                                            ProductName = product.ProductName,
                                                                                            CategoryId = product.CategoryId,
                                                                                            Price = product.Price,
                                                                                            Stock = product.Stock
                                                                                        }
                                                                                    };

            foreach (var dto in orderQueryDtos.ToList())
            {
                var tempOrderListDto = orderListDtos.FirstOrDefault(c => c.Id == dto.OrderDetails.Id);
                if (tempOrderListDto == null)
                {
                    var products = new List<ProductListDto>();
                    products.Add(dto.Product);
                    orderListDtos.Add(new OrderListDto
                    {
                        Id = dto.OrderDetails.Id,
                        ShippingAddress = dto.OrderDetails.ShippingAddress,
                        PostalCode = dto.OrderDetails.PostalCode,
                        Price = dto.OrderDetails.Price,
                        Products = products
                    });
                }
                else
                {
                    orderListDtos.First(x => x.Id == dto.OrderDetails.Id).Products.Add(dto.Product);
                }
            }

            return orderListDtos;
        }
        private async Task<OrderListDto> GetOrder(OrderDetails orderDetails, IList<ProductListDto> products)
        {
            var orderListDto = new OrderListDto()
            {
                Id = orderDetails.Id,
                ShippingAddress = orderDetails.ShippingAddress,
                PostalCode = orderDetails.PostalCode,
                Price = orderDetails.Price,
            };

            foreach (var product in products)
                orderListDto.Products.Add(product);

            return orderListDto;
        }
    }
}
