using AutoMapper;
using Common.Enums;
using Common.Extention;
using Domain;
using Domain.Order;
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
    public class ProductService : IProductService
    {

        private readonly MyContext _mycontext;
        private readonly IMapper _mapper;

        public ProductService(MyContext myContext, IMapper mapper)
        {
            _mapper = mapper;
            _mycontext = myContext;
        }

        public async Task<IEnumerable<ProductBo>> GetVarietyKeyValuePairAsync()
        {
            try
            {
                var query = _mycontext.Product.Where(w => w.RecordStatus == Common.Enums.RecordStatus.Active).AsQueryable();
                var result = await query.AsNoTracking().ToListAsync();
                var model = _mapper.Map<List<ProductBo>>(result);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }       
           
        }

        public async Task<ProductBo> Read(int id)
        {
            var result = await _mycontext.Product.FirstOrDefaultAsync(w => w.Id == id && w.RecordStatus == RecordStatus.Active);
            var model = result.MapObject<Product, ProductBo>();
            return model;

        }


    }
}
