using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace backend {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup() {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            string conn = Configuration["Connection"];
            var serverVersion = ServerVersion.AutoDetect(conn);

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(conn, serverVersion));
            services.AddSpaStaticFiles(configuration:options => { options.RootPath = "wwwroot"; });
            services.AddControllers();
            services.AddCors(options => {
                options.AddPolicy("VueCorsPolicy", builder => {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https://localhost:5001");
                });
            });

            services.AddAuthentication().AddJwtBearer();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("VueCorsPolicy");

            dbContext.Database.EnsureCreated();
						
            app.UseAuthentication();
            app.UseMvc();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSpaStaticFiles();
            app.UseSpa(configuration: builder => {
                if (env.IsDevelopment()) {
                    builder.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });
        }
    }
}
