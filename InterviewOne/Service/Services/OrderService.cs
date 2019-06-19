using AutoMapper;
using Common.Enums;
using Domain;
using Domain.Order;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService: IOrderService
    {

        private readonly MyContext _mycontext;
        private readonly IMapper _mapper;

        public OrderService(MyContext myContext, IMapper mapper)
        {
            _mapper = mapper;
            _mycontext = myContext;
        }


        public async Task SaveOrderItemsAsync(List<OrderItem> orderItems)
        {
            try
            {
                var orderDomain = new Order
                {
                    CustomerId = 1,
                    OrderedDate = DateTime.Now,
                    CreatedById = 1,
                    CreatedOn = DateTime.Now,
                    RecordStatus = RecordStatus.Active
                };
                await _mycontext.Order.AddAsync(orderDomain);
                await _mycontext.SaveChangesAsync();

         
                foreach (var item in orderItems)
                {
                    var product = await _mycontext.Product.FirstOrDefaultAsync(w => w.Id == item.ProductId && w.RecordStatus == RecordStatus.Active);
                    if (product != null)
                    {

                        var orderItemDomain = new OrderDetail
                        {
                            ProductId = item.ProductId,
                            Qty = item.Qty,
                            Amount = product.Price * item.Qty,
                            Discount = item.Discount,
                            OrderId = orderDomain.OrderId

                        };
                        orderItemDomain.CreatedOn = DateTime.Now;
                        orderItemDomain.CreatedById = 1;
                        orderItemDomain.RecordStatus = RecordStatus.Active;
                        await _mycontext.OrderDetail.AddAsync(orderItemDomain);
                    }
                   

                }

                await _mycontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }


        }
}
