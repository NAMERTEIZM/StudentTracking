using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.BLL.Mapper
{
    public  class MyMapper : Profile
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
                //cfg.CreateMap<TSource, TDestination>().ReverseMap();
            });

            var mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
