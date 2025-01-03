using Bank.Domain.Core.Contracts.AppService;
using Bank.Domain.Core.Contracts.Repository;
using Bank.Domain.Core.Contracts.Service;
using Bank.Endpoint.RazorPages;
using Bank.Services.AppServices;
using Bank.Services.Services;
using HW_Week15.DAL.Repositories;
 static void Main(string[] args)
{
    CreateHostBuilder(args).Build().Run();
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureServices(services =>
            {

                services.AddRazorPages();
                services.AddScoped<ICardService, CardService>();  
                services.AddScoped<ICardRepository, CardRepository>();  
                services.AddScoped<ITransactionService, TransactionService>();  



            });

            webBuilder.Configure(app =>
            {
                var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

              
                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

            
             

                
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                });
            });
        });






