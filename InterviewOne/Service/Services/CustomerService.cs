using AutoMapper;
using Common.Enums;
using Common.Extention;
using Common.HelperMethods;
using Domain;
using Domain.Customer;
using Microsoft.EntityFrameworkCore;
using Service.Bo;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
   public class CustomerService:ICustomerService
    {

        private readonly MyContext _mycontext; 

        public CustomerService(MyContext myContext) {

            _mycontext = myContext;          
        }

        public async Task Create(CustomerBo request)
        {
            try
            {
                var entity = request.MapObject<CustomerBo, Customer>();
                entity.RecordStatus = RecordStatus.Active;
                await _mycontext.Customer.AddAsync(entity);
                await _mycontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }             
          
        }

        public async Task Update(CustomerBo request)
        {
            try
            {
                var entity = request.MapObject<CustomerBo, Customer>();
                _mycontext.Customer.Update(entity);
                await _mycontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }



        public async Task Delete(int id)
        {
            try
            {
                var entity = await _mycontext.Customer.FirstOrDefaultAsync(w => w.Id == id);
                if (entity != null)
                {
                    entity.RecordStatus = RecordStatus.Inactive;
                    entity.EditedOn = DateTime.UtcNow;
                    _mycontext.Entry(entity).State = EntityState.Modified;

                    await _mycontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }        

        }

        public async Task<PageList<CustomerBo>> Read(int skip, int take, string searchTerm)
        {
            try
            {
                if (searchTerm == null)
                {
                    searchTerm = string.Empty;
                }

                var result = _mycontext.Customer.AsNoTracking().Where(p => p.FirstName.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase) && p.RecordStatus == RecordStatus.Active).AsQueryable();

                var itemcount = await result.CountAsync();
                result = (take != 0) ? result.Skip(skip).Take(take) : result;
                var empList = await result.ToListAsync();


                return new PageList<CustomerBo>
                {
                    Skip = skip,
                    Take = take,
                    Items = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerBo>>(empList),
                    TotalRecodeCount = itemcount
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CustomerBo> Read(int id)
        {
            var result = await _mycontext.Customer.FirstOrDefaultAsync(w => w.Id == id && w.RecordStatus == RecordStatus.Active);
            var model = result.MapObject<Customer, CustomerBo>();
            return model;

        }

        public Task<List<KeyValuePair<int, string>>> ReadKeyValue(Search request)
        {
            throw new NotImplementedException();
        }

       
    }
}
