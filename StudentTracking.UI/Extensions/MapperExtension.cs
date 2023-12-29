using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StudentTracking.BLL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Extensions
{
    public static class MapperExtension
    {
        public static void AddMapperExtension(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            services.AddSingleton(config.CreateMapper());
        }
    }
}
