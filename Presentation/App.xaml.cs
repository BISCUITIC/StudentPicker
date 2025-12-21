using Application.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Interfaces;
using Presentation.Services.Dialogs;
using Presentation.Services.Factories;
using Presentation.Services.Interfaces;
using Presentation.ViewModels;
using Presentation.Views;
using System.IO;
using System.Windows;

namespace Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private readonly IHost _host;

    public IHost AppHost => _host;

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

                        services.AddScoped<IStudentService, StudentService>();
                        services.AddScoped<IGroupService, GroupService>();

                        services.AddTransient<AddStudentDialogFactory>();
                        services.AddTransient<UpdateStudentDialogFactory>();

                        services.AddTransient<IAddStudentDialogService, AddStudentDialogService>();
                        services.AddTransient<IUpdateStudentDialogService, UpdateStudentDialogService>();

                        services.AddTransient<StudentDialogViewModel>();
                        services.AddScoped<StudentsViewModel>();
                        services.AddScoped<GroupsViewModel>();
                        services.AddScoped<MainViewModel>();

                        services.AddTransient<IStudentDialog, StudentDialog>();

                        services.AddSingleton<MainWindow>();
                    }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {        
        MainWindow window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();  
        base.OnStartup(e);
    }
    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();        
        base.OnExit(e);
    }
}
