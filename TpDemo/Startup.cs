using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TpDemo.DAL.EFContext;
using Microsoft.EntityFrameworkCore;
using TpDemo.DAL.Repositories;
using TpDemo.DAL.Entities;
using TpDemo.DAL.UnitOfWork;
using TpDemo.BLL.TourEditService;
using TpDemo.BLL.TourCatalogueService;
using TpDemo.BLL.TourCatalogueService.SearchOptions;
using AutoMapper;



namespace TpDemo
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
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });

            var connection = @"Server=(localdb)\mssqllocaldb;Database=TpDemo;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(connection));

            services.AddScoped<IRepository<Tour>, TourRepository>();
            services.AddScoped<IRepository<Role>, RoleRepository>();
            services.AddScoped<IRepository<TourBooking>, TourBookingRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITourEditService, TourEditService>();
            services.AddScoped<ITourCatalogueService, TourCatalogueService>();
            services.AddScoped<TourSearchModel, TourSearchModel>();

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
