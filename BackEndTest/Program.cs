using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Infrastructure.ConnectionConfig;
using Infrastructure.Repositories;

namespace BackEndTest;

internal class Program
{
    private static void Main(string[] args)
    {
        IConnectionStringProvider connection = new ConnectionStringProvider();

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
