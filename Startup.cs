using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StoneTest.HostedServices;
using StoneTest.HostedServices.Implementations;
using StoneTest.Infrastructure;
using StoneTest.Infrastructure.DbModels;
using StoneTest.Infrastructure.Repositories;

namespace StoneTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<HttpClient>()
                .AddTransient<ICurrencyInfoReader, CbrCurrencyInfoReader>()
                .AddTransient<ICurrencyRepository, CurrencyRepository>()
                .AddTransient<ICurrencyRateRepository, CurrencyRateRepository>()
                .AddTransient<ICurrencyRatesUpdater, CurrencyRateUpdater>()
                .AddHostedService<CurrencyRateUpdateService>()
                .AddDbContext<StoneTestContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
                })
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //добавление возможности работы с кодировкой windows-1251
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
