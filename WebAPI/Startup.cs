using BLL.Contracts;
using BLL.Implementation;
using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Implemetations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            // BLL
            services.Add(new ServiceDescriptor(typeof(IPersonCreateService), typeof(PersonCreateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPersonGetService), typeof(PersonGetService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPersonUpdateService), typeof(PersonUpdateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPhoneNumberGetService), typeof(PhoneNumberGetService),
                ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IOperatorCreateService), typeof(OperatorCreateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOperatorGetService), typeof(OperatorGetService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOperatorUpdateService), typeof(OperatorUpdateService),
                ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IOperatorDataAccess), typeof(OperatorDataAccess),
                ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPersonDataAccess), typeof(PersonDataAccess),
                ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPhoneNumberDataAccess), typeof(PhoneNumberDataAccess),
                ServiceLifetime.Transient));

            // DB Contexts
            services.AddDbContext<OperatorDirectoryContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("PersonDirectory")));
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}