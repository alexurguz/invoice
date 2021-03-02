using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Invoice.Core.CustomEntities;
using Invoice.Core.Exceptions;
using Invoice.Core.Interfaces.Repository;
using Invoice.Core.Interfaces.UnitOfWork;
using Invoice.Core.Interfaces.UseCase;
using Invoice.Core.UseCase;
using Invoice.Infrastructure.Data;
using Invoice.Infrastructure.Filters;
using Invoice.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Invoice.Api
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
            // Add AutoMapper for mapper DTOs with models
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(options => {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options => {

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;// Destroy loop reference in objects

            }).ConfigureApiBehaviorOptions(options => {
               // options.SuppressModelStateInvalidFilter = true;
            });
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            // Use the string connection configured on the appsettings.json
            services.AddDbContext<InvoiceDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("InvoiceApi"))
            );

            // Dependency Injection UseCase
            services.AddTransient<ISalesInvoiceUseCase, SalesInvoiceUseCaseImpl>();
            services.AddTransient<IProductUseCase, ProductUseCaseImpl>();
            services.AddTransient<IUserUseCase, UserUseCaseImpl>();

            // Dependency Injection Repository
            services.AddTransient<ISalesInvoiceRepository, SalesInvoiceRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Dependency Injection UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Register a global filter for the controllers
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
