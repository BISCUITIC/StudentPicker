using Application.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Student;
using Application.UseCases.Student.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Interfaces;
using Presentation.Services.Dialogs;
using Presentation.Services.Dialogs.Factories;
using Presentation.Services.Dialogs.Interfaces;
using Presentation.Services.Factories;
using Presentation.ViewModels;
using Presentation.ViewModels.Dialogs;
using Presentation.ViewModels.Groups;
using Presentation.ViewModels.Students;
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
        var config = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json")
                         .Build();
        var connectionString = config.GetConnectionString("DefaultConnection");
        var options = new DbContextOptionsBuilder<ApplicationContext>()
                          .UseNpgsql(connectionString)
                          .Options;

        _host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {
                        services.AddSingleton(options);
                        services.AddDbContext<ApplicationContext>();

                        #region Services
                        services.AddScoped<IGroupRepository, GroupRepository>();
                        services.AddScoped<IStudentRepository, StudentRepository>();

                        services.AddScoped<IStudentService, StudentService>();
                        services.AddScoped<IGroupService, GroupService>();

                        services.AddScoped<IStudentPickerService, StudentPickerService>();
                        services.AddScoped<IRandomProvider, RandomChoiceProvider>();

                        services.AddScoped<IStudentApplicationService, StudentApplicationService>();
                        #endregion

                        #region DialogServices
                        services.AddTransient<IAddStudentDialogService, AddStudentDialogService>();
                        services.AddTransient<IUpdateStudentDialogService, UpdateStudentDialogService>();
                        services.AddTransient<IAddGroupDialogService, AddGroupDialogService>();
                        services.AddTransient<IUpdateGroupDialogService, UpdateGroupDialogService>();
                        #endregion

                        #region Factories
                        services.AddTransient<AddStudentDialogFactory>();
                        services.AddTransient<UpdateStudentDialogFactory>();
                        services.AddTransient<AddGroupDialogFactory>();
                        services.AddTransient<UpdateGroupDialogFactory>();
                        #endregion

                        #region UseCases
                        services.AddTransient<ILoadStudentsUseCase, LoadStudentsUseCase>();
                        services.AddTransient<IUpdateStudentUseCase, UpdateStudentUseCase>();
                        services.AddTransient<IDeleteStudentUseCase, DeleteStudentUseCase>();
                        services.AddTransient<IAddStudentUseCase, AddStudentUseCase>();
                        services.AddTransient<IPickStudentUseCase, PickStudentUseCase>();
                        #endregion

                        #region ViewModels
                        services.AddTransient<StudentDialogViewModel>();
                        services.AddTransient<GroupDialogViewModel>();

                        services.AddScoped<StudentsViewModel>();
                        services.AddScoped<GroupsViewModel>();
                        services.AddScoped<MainViewModel>();
                        #endregion

                        #region Dialogs
                        services.AddTransient<IStudentDialog, StudentDialog>();
                        services.AddTransient<IGroupDialog, GroupDialog>();
                        #endregion

                        services.AddSingleton<MainWindow>();
                    }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();
        base.OnStartup(e);
    }
}
