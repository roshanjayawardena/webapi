using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services.Interfaces;

namespace InterviewOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public OrderController(IProductService productService,IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }


        [HttpGet]
        [Route("getAllProducts")]
        public async Task<IActionResult> getAllProducts() {

            try
            {
                var result = await _productService.GetVarietyKeyValuePairAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadById(int id)
        {
            try
            {
                return Ok(await _productService.Read(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("AddOrderItems")]
        public async Task<IActionResult> AddOrderItems([FromBody] List<OrderItem> orderItems) {

            try
            {
                await _orderService.SaveOrderItemsAsync(orderItems);
                return Ok();

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }





    }
}