using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndTest;

internal class Program
{
    private static void Main(string[] args)
    {
        IConfigurationRoot connection = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .Build();

        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<IConfigurationRoot>(connection);
        services.AddDbContext<ApplicationContext>();

        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        var provider = services.BuildServiceProvider();

        var groupProvider = provider.GetRequiredService<IGroupRepository>();
        var studentProvider = provider.GetRequiredService<IStudentRepository>();

        Group group = groupProvider.GetById(1) ?? throw new Exception();
        List<Student> students = studentProvider.GetAllByGroup(group);

        foreach (Student student in students)
        {
            Console.WriteLine(student.FullName);
        }
    }
}
