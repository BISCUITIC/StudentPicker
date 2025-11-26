using Application.Interfaces;
using Application.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ViewModels;
using System.IO;
using System.Windows;

namespace Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private readonly IHost _host;

    public App()
    {
        IConfigurationRoot connection = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();
        _host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {
                        services.AddSingleton<IConfigurationRoot>(connection);
                        services.AddDbContext<ApplicationContext>();

                        services.AddScoped<IGroupRepository, GroupRepository>();
                        services.AddScoped<IStudentRepository, StudentRepository>();

                        services.AddScoped<GroupProvider>();

                        services.AddScoped<GroupsViewModel>();

                        services.AddSingleton<MainWindow>();
                    }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {        
        MainWindow window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();  
        base.OnStartup(e);
    }
    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();        
        base.OnExit(e);
    }
}
