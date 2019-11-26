using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ICatalogo, Catalogo>();
            //services.AddTransient<IRelatorio, Relatorio>();
            // O AddTransient<> faz com que para cada chamada no metódo GetServices() sempre seja criado uma nova instância dos services.

            //services.AddScoped<ICatalogo, Catalogo>();
            //services.AddScoped<IRelatorio, Relatorio>();
            // O AddScoped<> faz com que para cada requisição feita no navegador, as instâncias sejam geradas uma única vez.

            var catalogo = new Catalogo();

            services.AddSingleton<ICatalogo>(catalogo);
            services.AddSingleton<IRelatorio>(new Relatorio(catalogo));
            // O AddSingleton<> faz com que sempre que a aplicação esteja rodando, independente da requisição, sempre trabalhemos com a mesma instância.

            // Utilizamos do mecanismo de injeção de dependências para não precisarmos intanciar nossas classes.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();
            // Injeção de dependência.

            app.Run(async (context) =>
            {
                await relatorio.Imprimir(context);
            });
        }
    }
}
