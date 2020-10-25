using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaxShop.Delta;
using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MaxShop.Delta.Repository;
using MaxShop.Delta.Models;

namespace MaxShop
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup (IConfiguration configuration)
        {
            _configuration = configuration;
            //_confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllPhones, PhoneRepository>();
            services.AddTransient<IPhonesCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(v => ShopCart.GetCart(v));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoint.MapControllerRoute("categoryFitler", "Phone/{action}/{category?}", defaults: new {Controller="Phone", action="List"  });
            });

            app.UseStatusCodePages();

            using (var scope = app.ApplicationServices.CreateScope())
            {
             AppDbContent   content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DbObjects.CreateStartedTablesDb(content);
            }
        }
    }
}
