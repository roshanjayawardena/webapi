using AutoMapper;
using Common.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extention
{
    public static class ObjectExtention
    {

        public static Request<TTo> MapRequestObject<TFrom, TTo>(this Request<TFrom> value, int id)
        {
            return new Request<TTo>()
            {
                TenantId = value.TenantId,
                UserId = value.UserId,
                Item = Mapper.Map<TTo>(value.Item),
                Id = id
            };
        }
        public static Request<TTo> MapRequestObject<TFrom, TTo>(this Request<TFrom> value, TTo item)
        {
            return new Request<TTo>()
            {
                TenantId = value.TenantId,
                UserId = value.UserId,
                Item = item
            };
        }

        public static Request<TTo> MapRequestObject<TFrom, TTo>(this Request<TFrom> value)
        {
            return new Request<TTo>()
            {
                TenantId = value.TenantId,
                UserId = value.UserId,
                Item = Mapper.Map<TTo>(value.Item),                
                Id = 0
            };
        }

        public static TTo MapObject<TFrom, TTo>(this TFrom value)
        {
            return Mapper.Map<TTo>(value);
        }

        public static IEnumerable<TTo> MapListObject<TFrom, TTo>(this IEnumerable<TFrom> values)
        {
            return values.Select(x => Mapper.Map<TTo>(x)).ToList();
        }
    }
}
