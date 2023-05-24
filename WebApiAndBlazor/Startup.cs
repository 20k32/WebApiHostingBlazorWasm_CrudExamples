
namespace WebApiAndBlazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            services.AddCors();
            services.AddRazorPages();

            services.AddScoped<HttpClient>(serviceProvider => new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7091/")
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                /*app.UseSwagger();
                app.UseSwaggerUI();*/
            }
            app.UseCors(config => config.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseRouting();

            app.UseBlazorFrameworkFiles();
            
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints
                (endpoints =>
                {
                    endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");

                    endpoints.MapFallbackToFile("index.html");
                });
        }
    }
}
