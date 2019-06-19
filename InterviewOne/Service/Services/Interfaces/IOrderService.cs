using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IOrderService
    {

        Task SaveOrderItemsAsync(List<OrderItem> orderItems);


    }
}
