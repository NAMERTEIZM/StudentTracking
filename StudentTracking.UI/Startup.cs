using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentTracking.BLL.Manager;
using StudentTracking.BLL.Mapper;
using StudentTracking.DAL.Helper;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.DAL.Repositories.Concrete;
using StudentTracking.DAL.UnitOfWork;
using StudentTracking.UI.Extensions;
using StudentTracking.UI.Models.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConnectionHelper.SetConfiguration(Configuration);
            services.AddControllersWithViews();
            services.AddScoped<QuestionManager>();
            services.AddScoped<ClassManager>();
            services.AddScoped<StudentManager>();
            services.AddScoped<ProjectManager>();
            services.AddScoped<ReportManager>();
            services.AddScoped<ExamManager>();
            services.AddScoped<StatusManager>();            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyMapper>();
            services.AddScoped<UniqueEmailFilter>();
            //services.AddMapperExtension();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
