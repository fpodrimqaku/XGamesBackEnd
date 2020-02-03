using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using XGames.Data;
using XGames.Repositories.RepositoryInterfaces;
using XGames.Repositories;
using XGames.BusinessLogic;
using XGames.BusinessLogic.BusinessLogicInterfaces;
using XGames.Services.Time;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace XGames
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
             services.AddControllers();



             services.AddSingleton<IDateTime, SystemDateTime>();
             services.AddControllersWithViews();
             services.AddDbContextPool<XGamesContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("XGamesContext")));
            
             services.AddSignalR();
             services.AddAutoMapper(typeof(Startup));
           

             services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
             services.AddTransient(typeof(ICartRepository), typeof(CartRepository));
             services.AddTransient(typeof(IGameRepository), typeof(GameRepository));
             services.AddTransient(typeof(IGamePictureRepository), typeof(GamePictureRepository));
             services.AddTransient(typeof(ILineItemRepository), typeof(LineItemRepository));
            
            
             services.AddTransient(typeof(IBaseBLL<>), typeof(BaseBLL<>));
             services.AddTransient(typeof(ICartBLL), typeof(CartBLL));
             services.AddTransient(typeof(IGameBLL), typeof(GameBLL));
             services.AddTransient(typeof(IGamePictureBLL), typeof(GamePictureBLL));
             services.AddTransient(typeof(ILineItemBLL), typeof(LineItemBLL));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
