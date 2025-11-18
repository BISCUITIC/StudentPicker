using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace BackEndTest;

internal class Program
{
    private static void Main(string[] args)
    {
        IConfigurationRoot connection = new ConfigurationBuilder()
                          .AddJsonFile("appsettings.json")
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .Build(); ;

        using (ApplicationContext context = new ApplicationContext(connection))
        {
            IGroupRepository groupProvider = new GroupRepository(context);
            IStudentRepository studentProvider = new StudentRepository(context);

            Group group = groupProvider.GetById(1) ?? throw new Exception();
            List<Student> students = studentProvider.GetAllByGroup(group);

            foreach (Student student in students)
            {
                Console.WriteLine(student.FullName);
            }
        }
    }
}
