using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Entities;
using WebApp.Middlewares;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            // addsingleton deseydik her request icin ilk olusturulan productservice nesnesi kullanilirdi
            // addscoped dedigimizde her request icin yeni nesne olusturulur
            // addtransient dersek addscoped gibi calisir, farki soyle, addscoped dediginde
            // ornegin a client'i productcontroller'i cagirdiginda 
            // bir productservice nesnesi olusturulur, ayni anda bir cagri daha yaparsa ayni nesneden bir tane daha olusturulur
            // boylece ilk requestinde bir degisiklik olursa ikinci requestine de ayni degisiklik yansimis olur.
            // addtransient dersen ayni ornek icin iki request icin iki nesne olusturulur.
            // productcontroller iki productservice istiyormus gibi dusunursek tek pc cagrisi icin iki ps nesnesi olusturulur
            services.AddScoped<IProductDal, EFProductDal>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();


            services.AddDbContext<CustomIdentityDBContext>(
                options => options.UseSqlServer(@"Data Source=APARLAN\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True"));

            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDBContext>().AddDefaultTokenProviders();

            services.AddMvc();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //app.UseStaticFiles();
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath); // custom middleware yazdik, bootstrap gibi uygulamalari arayuz projesinden kullanabilmek icin.

            //app.UseIdentity();

            app.UseAuthentication();
            app.UseSession();

            app.UseMvcWithDefaultRoute();
        }
    }
}
