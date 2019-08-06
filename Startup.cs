using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CodePeople.Model;
namespace CodePeople
{
    public class Startup
    {
        public IConfiguration Configuration {get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkNpgsql()
             .AddDbContext<PersonContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DB")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,PersonContext PersonContext )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            PersonContext.Database.Migrate();
            app.UseMvc();
        }
    }
}
