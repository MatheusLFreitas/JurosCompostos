using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Filters;
using JurosCompostos.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JurosCompostos
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        private readonly IHostingEnvironment _hostingEnv;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IArredondamentoService, ArredondamentoTruncado>();
            services.AddScoped<IJurosCompostosService, CalculadoraJurosCompostos>();

            services
                .AddSwaggerGen(c =>
                 {
                     c.SwaggerDoc("1.0.0", new Info
                     {
                         Version = "1.0.0",
                         Title = "Softplan JurosCompostos",
                         Description = "Softplan JurosCompostos (ASP.NET Core 2.0)",
                         Contact = new Contact()
                         {
                             Name = "Swagger Codegen Contributors",
                             Url = "https://github.com/swagger-api/swagger-codegen",
                             Email = "matheus.linorp@gmail.com"
                         },
                         TermsOfService = ""
                     });
                     c.CustomSchemaIds(type => type.FriendlyId(true));
                     c.DescribeAllEnumsAsStrings();
                     c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                     //TODO: Verificar porque remove a barra da chamada a requisicao no try it out.
                     //c.DocumentFilter<BasePathFilter>("/");
                     c.OperationFilter<GeneratePathParamsValidationFilter>();
                 });
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

            app.UseHttpsRedirection()
               .UseDefaultFiles()
               .UseStaticFiles()
               .UseMvc()
               .UseSwagger()
               .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Softplan JurosCompostos");
                });
        }
    }
}
