using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateMatch.Common.Options;
using CandidateMatch.Data.Context;
using CandidateMatch.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CandidateMatch
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Registering the Dependency Injections
            
            services.AddScoped<IJobAPIContext, JobAPIContext>();
            services.AddScoped<ICandidateAPIContext, CandidateAPIContext>();
            services.AddScoped<ICandidateMatcher, CandidateMatcher>();
            services.AddSingleton<IJobAdderApiOptions,JobAdderApiOptions>();
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
