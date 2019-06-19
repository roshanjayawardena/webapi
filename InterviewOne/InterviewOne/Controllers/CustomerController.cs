using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Extention;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Bo;
using Service.Models;
using Service.Services.Interfaces;

namespace InterviewOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _employeeService;

        public CustomerController(ICustomerService employeeService) {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CustomerViewModel employeeViewModel) {

            try
            {
                employeeViewModel.CreatedOn = DateTime.Now;
                employeeViewModel.CreatedById = 1;
                var item = employeeViewModel.MapObject<CustomerViewModel, CustomerBo>();
                await _employeeService.Create(item);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]CustomerViewModel employeeViewModel) {

            try
            {
                employeeViewModel.EditedOn = DateTime.Now;
                employeeViewModel.EditedById = 1;
                var item = employeeViewModel.MapObject<CustomerViewModel, CustomerBo>();
                await _employeeService.Update(item);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpGet]
        public async Task<ActionResult> Read(int skip, int take, string search=null ,string orderBy = null)
        {
            try
            {
                return Ok(await _employeeService.Read(skip, take, search));
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Something went wrong while getting staff list" });
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadById(int id)
        {
            try
            {
                return Ok(await _employeeService.Read(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.Delete(id);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while deleting staff, try again" });
            }
        }


    }
}