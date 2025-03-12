using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
public static class DIConfiguration{
    public static IServiceProvider GetServiceProvider(){
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddDbContext<Context>(options =>
           options.UseNpgsql("Host=ep-holy-salad-a8m2hg5z-pooler.eastus2.azure.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_6XrNMvb4SPLk"));
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<ISpecieService, SpecieService>();
                services.AddScoped<IAnimalService, AnimalService>();
                services.AddScoped<ICustomerService, CustomerService>();
                services.AddScoped<IAppointmentService, AppointmentService>();
                services.AddScoped<IMedicalRecordService, MedicalRecordService>();

            }).Build();
        var score = host.Services.CreateScope();
        return score.ServiceProvider;
    }
}