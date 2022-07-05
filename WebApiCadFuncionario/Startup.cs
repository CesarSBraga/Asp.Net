using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCadFuncionario.Models;

using Microsoft.EntityFrameworkCore;
using WebApiCadFuncionario.Services;
using Microsoft.OpenApi.Models;

namespace WebApiCadFuncionario
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
            /*vamos configurar a injeção de dependência para o nosso contexto criar o objeto
             de banco de dados. Para isso precisamos importar o namespace abaixo:
             * using Microsoft.EntityFrameworkCore;
            */
            services.AddDbContext<FuncContexto>(
                x => x.UseSqlServer(
                Configuration.GetConnectionString("ConexaoDB")));


            //Vamos adicionar uma injeção de dependência do tipo SCOPED, que entregará
            // a nova request recebido um escopo unico de uma instância da interface 
            // IFuncionarioService
            services.AddScoped<IFuncionarioService, FuncionarioService>();


            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IMPACTA TECNOLOGIA API",
                    Version = "v1",
                    Description = "API GERADA NA AULA",
                    Contact = new OpenApiContact
                    {
                        Name = "Marcio Rodriguez",
                        Email = string.Empty,
                        Url = new Uri("https://impacta.com.br/"),
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

        // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
        c.RoutePrefix = string.Empty;
            });


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


