using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models.Buffet.Cliente;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TrabalhoPWA.Controllers;
using TrabalhoPWA.Models.Acesso;
using Usuario = Buffet.Controllers.Usuario;

namespace Buffet
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
            services.AddControllersWithViews();

            //Adicionando o Banco de Dados:
            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("BuffetDb")));

            //ADicionando o identity passando a classe acesso/usuario e acesso/role
            //OBS: para usar o método AddEntityFrameWorkStores é necessário baixar o pacote Microsoft.AspNetCore.Identity.EntityFrameworkCore (nuget)
            //Passar o banco de dados no parâmetro (DatabaseContext)
            //OBS: na classe DatabaseContext é necessário herdar a classe IdentityDbContext passando o User, Role, chaveprimária

            services.AddIdentity<User, Role> (
                options =>
                {
                    options.User.RequireUniqueEmail = true; //exigindo que só possa ter um cadastro por email
                    // options.Password.RequiredLength = 6; //requirindo uma senha com pelo menos 8 digitos
                }
            ).AddEntityFrameworkStores<DatabaseContext>();
            
            //Configurando cookies
            services.ConfigureApplicationCookie(
                options =>
                {
                    options.LoginPath = "/Usuario/Login";  //rota para direcionar caso tente acessar uma page não permitida
                }
            );

            services.AddTransient<AcessoService>();
            services.AddTransient<ClienteService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            //Informar para usar a autenticacao
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Public}/{action=Login}/{id?}");
            });
        }
    }
}