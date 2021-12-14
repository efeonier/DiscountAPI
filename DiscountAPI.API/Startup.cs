using System;
using DiscountAPI.Application.Services;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;
using DiscountAPI.Infrasturcture.Context;
using DiscountAPI.Infrasturcture.Repositories;
using DiscountAPI.Infrasturcture.UnitOfWorks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;



namespace DiscountAPI.API
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
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("SqlConStr"),
                    o => { o.MigrationsAssembly("DiscountAPI.Infrasturcture"); });
            });
            services.AddAutoMapper(typeof(Startup));
            
            services.AddHealthChecks();
            services.AddLogging().AddCors();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerTypeService, CustomerTypeService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "DiscountAPI.API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiscountAPI.API v1"));
            }

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        NoStore = true,
                        NoCache = true,
                        MustRevalidate = true,
                        MaxAge = TimeSpan.FromSeconds(0),
                        Private = true,
                    };
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("Pragma", "no-cache");
                await next();
            });

            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseRedirectValidation(t => t.AllowSameHostRedirectsToHttps(44361));
            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseCsp(opts => opts
                .BlockAllMixedContent()
                .ScriptSources(s => s.Self())
                .ScriptSources(s => s.UnsafeEval())
                .ScriptSources(s => s.UnsafeInline())
                .StyleSources(s => s.UnsafeInline())
                .StyleSources(s => s.Self()));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseEndpoints(endpoints =>
            {
                // registration of health endpoints see https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    AllowCachingResponses = false,
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}